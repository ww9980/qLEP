using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System.Numerics;

// theta angle should be in radian for all MathNet functions

namespace csLEES
{
    class ClassTMM
    {
        public Complex cSOL = new Complex((float)MathNet.Numerics.Constants.SpeedOfLight, (float)0);
        public Complex cPi = new Complex((float)MathNet.Numerics.Constants.Pi, (float)0);
        public Complex ij = new Complex((float)0, (float)1);
        private readonly Complex sinTheta;
        private readonly Complex cosTheta;
        public double theta_inc = 0;
        /// <summary>
        /// 规定 0 系 自由空间 即入射光源所在空间
        /// last 系 substrate
        /// </summary>
        public List<Layer> multilayer { set; get; }
        public ClassTMM(List<Layer> inmultilayer, double angle_inc)
        {
            multilayer = inmultilayer;
            theta_inc = angle_inc;
            sinTheta = new Complex((float)Trig.Sin(angle_inc), 0);
            cosTheta = new Complex((float)Trig.Cos(angle_inc), 0);
        }

        public Dictionary<double, double> Rs = new Dictionary<double, double>();
        public Dictionary<double, double> Ts = new Dictionary<double, double>();
        public Dictionary<double, double> Rp = new Dictionary<double, double>();
        public Dictionary<double, double> Tp = new Dictionary<double, double>();
        public Dictionary<double, double> Ephi = new Dictionary<double, double>();
        public Dictionary<double, double> Edelta = new Dictionary<double, double>();

        /// <summary>
        /// Snell calculates the incident angle at every interface throughout a multilayer stack. 
        /// 给定自由空间入射角、multilayer的n反射率列表后计算光线穿过各层时候的入射角。
        /// </summary>
        /// <param name="theta_inc">自由空间的入射角</param> 
        /// <param name="refractiveindexlist">各层反射率的list</param>
        /// <returns>光线穿过各层时候的入射角</returns>
        public List<double> Snell(double theta_inc, List<double> refractiveindexlist)
        {
            var numoflayer = refractiveindexlist.Count();
            List<double> thetalist = new List<double>(numoflayer);
            thetalist[0] = theta_inc;
            for (int i = 1;  i <= numoflayer; i++ )
            {
                thetalist[i] = Trig.Asin(refractiveindexlist[i - 1] / refractiveindexlist[i] * Trig.Sin(thetalist[i - 1]));
            }
            return thetalist;
        }
        public List<Complex> Snell(double theta_inc)
        {
            var numoflayer = multilayer.Count();
            List<Complex> thetalist = new List<Complex>();
            thetalist.Add(theta_inc);
            for (int i = 1; i < numoflayer; i++)
            {
                thetalist.Add(Trig.Asin(multilayer[i - 1].Ri / multilayer[i].Ri * Trig.Sin(thetalist[i - 1])));
            }
            return thetalist;
        }

        /// <summary>
        /// 组件Ds矩阵，图方便而已
        /// </summary>
        /// <param name="nvalue"> complex n value</param>
        /// <param name="cosThetaValue">complex costheta value</param>
        /// <returns>Matrix<Complex> Ds</returns>
        private Matrix<Complex> DsBuilder(Complex nvalue, Complex cosThetaValue)
        {
            Matrix<Complex> DsBuilding = Matrix<Complex>.Build.Dense(2, 2, 0);
            DsBuilding[0, 0] = 1;
            DsBuilding[0, 1] = 1;
            DsBuilding[1, 0] = nvalue * cosThetaValue;
            DsBuilding[1, 1] = -nvalue * cosThetaValue;
            return DsBuilding;
        }

        /// <summary>
        /// 组件Dp矩阵，图方便而已
        /// </summary>
        /// <param name="nvalue"> complex n value</param>
        /// <param name="cosThetaValue">complex costheta value</param>
        /// <returns>Matrix<Complex> Ds</returns>
        private Matrix<Complex> DpBuilder(Complex nvalue, Complex cosThetaValue)
        {
            Matrix<Complex> DBuilding = Matrix<Complex>.Build.Dense(2, 2, 0);
            DBuilding[0, 0] = cosThetaValue;
            DBuilding[0, 1] = cosThetaValue;
            DBuilding[1, 0] = nvalue;
            DBuilding[1, 1] = -nvalue;
            return DBuilding;
        }

        /// <summary>
        /// 求解单个波长、isotropic材质中的s和p偏振分别的透反射
        /// </summary>
        /// <param name="wl">波长</param>
        /// <returns>void</returns>
        public void SolveSingleWl(double wl)
        {
            var cwl = new Complex(wl, 0);
            int nlayers = multilayer.Count;
            Matrix<Complex> Dp = Matrix<Complex>.Build.Dense(2, 2, 0);
            Matrix<Complex> Ds = Matrix<Complex>.Build.Dense(2, 2, 0);
            Matrix<Complex> P = Matrix<Complex>.Build.Dense(2, 2, 0);
            Matrix<Complex> Mp = Matrix<Complex>.Build.Dense(2, 2, 0); 
            Matrix<Complex> Ms = Matrix<Complex>.Build.Dense(2, 2, 0);

            var thetabylayer = Snell(theta_inc);

            List<Complex> k = new List<Complex>();

            for (int i = 0; i < nlayers; i++)
            {
                k.Add(2 * cPi * multilayer[i].Ri / cwl * Trig.Cos(thetabylayer[i]) );
            }

            Ds = DsBuilder(multilayer[0].Ri, cosTheta);

            Ms = Ds.Inverse();

            Dp = DpBuilder(multilayer[0].Ri, cosTheta);

            Mp = Dp.Inverse();

            for (int ia = 1; ia < nlayers; ia++)
            {
                Ds = DsBuilder(multilayer[ia].Ri, Trig.Cos(thetabylayer[ia]));
                Dp = DpBuilder(multilayer[ia].Ri, Trig.Cos(thetabylayer[ia]));

                var phi = k[ia] * multilayer[ia].Thickness;

                P[0, 0] = Complex.Exp(ij * phi);
                P[0, 1] = 0;
                P[1, 0] = 0;
                P[1, 1] = Complex.Exp(-ij * phi);

                Ms = Ms * Ds * P * Ds.Inverse();
                Mp = Mp * Dp * P * Dp.Inverse();
            }

            Ds = DsBuilder(multilayer[nlayers].Ri, Trig.Cos(thetabylayer[nlayers]));
            Ms *= Ds;

            Dp = DpBuilder(multilayer[nlayers].Ri, Trig.Cos(thetabylayer[nlayers]));
            Mp *= Dp;

            var refS = (Ms[1, 0] / Ms[0, 0]);
            Rs.Add( wl, Complex.Abs(refS) * Complex.Abs(refS));
            var refp = (Mp[1, 0] / Mp[0, 0]);
            Rp.Add( wl, Complex.Abs(refp) * Complex.Abs(refp));

            var trS = 1.0 / (Ms[0, 0]);
            //trS = (multilayer.Last().Ri * Trig.Cos(thetabylayer.Last()) / multilayer[0].Ri * cosTheta) * trS.Magnitude;
            Ts.Add(wl, Complex.Abs(trS) * Complex.Abs(trS));
            var trP = 1.0 / (Mp[0, 0]);
            //trP = (multilayer.Last().Ri * Trig.Cos(thetabylayer.Last()) / multilayer[0].Ri * cosTheta) * trP.Magnitude;
            Tp.Add(wl, Complex.Abs(trP) * Complex.Abs(trP));

            Ephi.Add(wl, Trig.Atan(Complex.Abs(refp / refS)));
            Edelta.Add(wl, (-refp/refS).Phase);

            return;
        }
    }
}
