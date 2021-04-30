using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Charts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Helpers;


namespace csLEES
{
    public partial class FormLEES : Form
    {
        public FormLEES()
        {
            InitializeComponent();
        }

        public FormLEES(List<double> stepl, double stepsize, List<double> refindex, List<double> solution)
        {
            InitializeComponent();

            List<string> stepmakers = new List<string>();

            foreach (var step in stepl)
            {
                stepmakers.Add((step * stepsize).ToString());
            }

            TopPlot.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Refractive indes",
                    Values = refindex.AsChartValues()

                }
            };
            TopPlot.AxisX.Add(new Axis
            {
                Title = "Etch depth (nm) excluding substrate",
                Labels = stepmakers
            });
            BottomPlot.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "LEP intensity",
                    Values = solution.AsChartValues()

                }
            };
            BottomPlot.AxisX.Add(new Axis
            {
                Title = "Etch depth (nm) excluding substrate",
                Labels = stepmakers
            });
        }

        private void FormLEES_Load(object sender, EventArgs e)
        {

        }
    }
}
