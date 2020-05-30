using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csLEES
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        internal Layer AddedLayer { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tMatName.Text == "" ||
                tThickness.Text == "" ||
                tN.Text == "" ||
                tK.Text == "")
            {
                MessageBox.Show("Fill all fields and try again.",
                  "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1);

                return;
            }
            AddedLayer = new Layer();
            AddedLayer.Name = tMatName.Text;
            double th;
            double.TryParse(tThickness.Text, out th);

            AddedLayer.Thickness = th;
            float n, k;
            float.TryParse(tN.Text, out n);
            float.TryParse(tK.Text, out k);

            AddedLayer.Ri = new MathNet.Numerics.Complex32(n, k);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
