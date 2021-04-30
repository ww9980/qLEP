using System.Numerics;

namespace csLEES
{
    public interface ICloneable<T>
    {
        T Clone();
    }
    public class Layer : ICloneable<Layer>
    {
        public Layer() { }
        /// <summary>
        /// 建立新的layer层对象。name 名称，tk 层厚度，n 复折射率。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tk"></param>
        /// <param name="n"></param>
        public Layer(string name, double tk, Complex n)
        {
            Name = name;
            Thickness = tk;
            Ri = n;
        }
        public Layer(string name, double tk, Complex n, bool iso)
        {
            Name = name;
            Thickness = tk;
            Ri = n;
            Isotropic = iso;
        }

        public string Name { get; set; }
        public double Thickness { get; set; }
        public Complex Ri { get; set; }
        public bool Isotropic { get; set; } = false;

        public Layer Clone() => new Layer
        {
            Name = this.Name,
            Thickness = this.Thickness,
            Ri = this.Ri,
            Isotropic = this.Isotropic,
        };

        //public int IsSubstrate { set; get; }
        // 1 - substrate
        // 0 - normal layer in stack
        // 已替换使用double.PositiveInfinity表代air或sub
    }

}
