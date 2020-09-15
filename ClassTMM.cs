using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;

namespace csLEES
{
    class ClassTMM
    {
        public Complex32 SOL = new Complex32((float)MathNet.Numerics.Constants.SpeedOfLight,0);
        public Complex32 Pi = new Complex32((float)MathNet.Numerics.Constants.Pi,0);
        public Complex32 ij = new Complex32(0, 1);
        public ClassTMM(List<Layer> inmultilayer, double angle_inc)
        {
            multilayer = inmultilayer;
            sinTheta = new Complex32((float)MathNet.Numerics.Trig.Sin(angle_inc), 0);
            cosTheta = new Complex32((float)MathNet.Numerics.Trig.Cos(angle_inc), 0);
        }
        private readonly Complex32 sinTheta;
        private readonly Complex32 cosTheta;
        public List<Layer> multilayer { set; get; }
        private Layer substrate { set; get; }
        public Layer Substrate 
        {
            get { return substrate; }
            set { substrate = value; }
        }
        public double Rs { set; get; }
        public double Ts { set; get; }
        public double Rp { set; get; }
        public double Tp { set; get; }

        public int Solve(double wl)
        {
            var cwl = new Complex32((float)wl, 0);
            int nlayers = multilayer.Count;
            Matrix<Complex32> Dp = Matrix<Complex32>.Build.Dense(2, 2, 0);
            Matrix<Complex32> Ds = Matrix<Complex32>.Build.Dense(2, 2, 0);
            Matrix<Complex32> P = Matrix<Complex32>.Build.Dense(2, 2, 0);
            Matrix<Complex32> Mp = Matrix<Complex32>.Build.Dense(2, 2, 0); 
            Matrix<Complex32> Ms = Matrix<Complex32>.Build.Dense(2, 2, 0);


            Dp[0, 0] = 1;
            Dp[0, 1] = 1;
            Dp[1, 0] = cosTheta;
            Dp[1, 1] = - Dp[1, 0];

            Mp = Dp.Inverse();

            Ds[0, 0] = cosTheta;
            Ds[0, 1] = cosTheta;
            Ds[1, 0] = 1;
            Ds[1, 1] = -1;

            Ms = Ds.Inverse();


            List<Complex32> k = new List<Complex32>();
            List<Complex32> nl = new List<Complex32>();

            for (int ia = 0; ia < nlayers; ia++)
            {
                nl.Add(multilayer[ia].Ri);
                k.Add(2 * Pi * cwl *
                    multilayer[ia].Ri *
                    cosTheta
                    / SOL);
                P[0, 0] = MathNet.Numerics.Complex32.Exp(
                    ij *
                    k.Last() *
                    new MathNet.Numerics.Complex32((float)multilayer[ia].Thickness, 0) );
                P[0, 1] = 0;
                P[1, 0] = 0;
                P[1, 1] = P[0, 0] = MathNet.Numerics.Complex32.Exp(
                    - MathNet.Numerics.Complex32.ImaginaryOne *
                    k.Last() *
                    new MathNet.Numerics.Complex32((float)multilayer[ia].Thickness, 0));

                Ds[1, 0] = nl.Last() * cosTheta;
                Ds[1, 1] = -Ds[1, 0];
                Ms = P.Multiply(Ds.Inverse()).Multiply(Ds).Multiply(Ms);
                
                Dp[1, 0] = nl.Last();
                Dp[1, 1] = -Dp[1, 0];
                Mp = P.Multiply(Dp.Inverse()).Multiply(Dp).Multiply(Mp);
            }
            Ds[1, 0] = substrate.Ri * cosTheta;
            Ds[1, 1] = -Ds[1, 0];
            Ms = Ms.Multiply(Ds);


            Dp[1, 0] = substrate.Ri;
            Dp[1, 1] = -Dp[1, 0];
            Mp = Mp.Multiply(Dp);

            Rs = (Ms[1, 0] / Ms[0, 0]).Norm();
            Rs *= Rs;

            Ts = 1.0 / (Ms[0, 0].Norm());
            Ts *= Ts;

            Rp = (Mp[1, 0] / Mp[0, 0]).Norm();
            Rp *= Rp;

            Tp = 1.0 / (Mp[0, 0].Norm());
            Tp *= Tp;

            return 0;
        }
    }
}
