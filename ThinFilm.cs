using System.Numerics;

namespace csLEES
{
    class Layer
    {
        public Layer() { }
        public Layer(string name, double tk, Complex n)
        {
            Name = name;
            Thickness = tk;
            Ri = n;
        }

        public string Name { get; set; }
        public double Thickness { get; set; }
        public Complex Ri { get; set; }
        public bool Isotropic { get; set; } = false;

        //public int IsSubstrate { set; get; }
        // 1 - substrate
        // 0 - normal layer in stack
    }

}
