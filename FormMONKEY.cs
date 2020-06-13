using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace csLEES
{
    public partial class FormMONKEY : Form
    {
        public FormMONKEY()
        {
            InitializeComponent();
        }

        public void LoadMatXML()
        {
            List<Mat> MatList = new List<Mat>();
            XmlReader xmlReader = XmlReader.Create("C:\\1.Workspace\\1.projects\\202004LEP\\OptPropForED.xml");
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "ROW"))
                {
                    if (xmlReader.HasAttributes)
                    //Console.WriteLine(xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate"));
                    {
                        var RowMat = new Mat();
                        RowMat.MatName = xmlReader.GetAttribute("MaterialName");
                        RowMat.MatSymbol = xmlReader.GetAttribute("Symbol");
                        RowMat.Wavelength = Convert.ToDouble(xmlReader.GetAttribute("Wavelength"));
                        RowMat.Ri = new MathNet.Numerics.Complex32((float)Convert.ToDouble(xmlReader.GetAttribute("RI")), (float)Convert.ToDouble(xmlReader.GetAttribute("ExtCoeff")));
                    }
                }
                else
                {
                    MessageBox.Show("Cannot load material database, reinstall this program plz. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
