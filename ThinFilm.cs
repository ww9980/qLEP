using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csLEES
{
    class Layer
    {
        public Layer() 
        {

        }

        public string Name { get; set; }
        public double Thickness { get; set; }
        public MathNet.Numerics.Complex32 Ri { get; set; }

        public int IsSubstrate { set; get; }
        // 1 - substrate
        // 0 - normal layer in stack
    }

}
