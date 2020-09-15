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
using LiveCharts.Wpf;

namespace csLEES
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<Layer> layerstack = new List<Layer>();
        List<ListViewItem> LVI = new List<ListViewItem>();

        double resolution = 1.0;
        double wavelength = 670.0;

        List<Layer> etchedlayers = new List<Layer>();
        List<double> Rfrindex = new List<double>();
        int step = 0;
        List<int> stepList = new List<int>();
        List<double> solutionList = new List<double>();


        private void MainForm_Load(object sender, EventArgs e)
        {

            /*
            dataGridView.DataSource = layerstack;

            for (int i = 2; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].Visible = false;
            }
            */
            layerChart.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> { 0 },
                    DataLabels = true,
                    StackMode = StackMode.Values
                }
            };
            layerChart.AxisY.Add(new Axis
            {
                Title = "Thickness",
                LabelFormatter = value => value + " nm"
            });
            layerChart.AxisX.Add(new Axis
            {
                Title = "Layer Structure, \nthe bottom layer is considered the substrate",
                Labels = new[] { "" },
                Separator = DefaultAxes.CleanSeparator
            });
            layerChart.Hoverable = false;
            layerChart.DataTooltip = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd fa = new FormAdd();
            fa.ShowDialog();
            if (fa.AddedLayer != null)
            {
                layerstack.Add(fa.AddedLayer);
                var lvi = new ListViewItem(fa.AddedLayer.Name + ", " 
                    + fa.AddedLayer.Thickness.ToString() + " nm" );
                LayerLV.Items.Add(lvi);

                layerChart.Series.Add(new StackedColumnSeries
                {
                    Values = new ChartValues<double> { fa.AddedLayer.Thickness },
                    StackMode = StackMode.Values
                });
            }
            else
            {
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (LayerLV.SelectedItems == null)
            {
                return;
            }
            foreach (ListViewItem sitem in LayerLV.SelectedItems)
            {
                int ind = LayerLV.Items.IndexOf(sitem);
                layerstack.RemoveAt(ind);
                LayerLV.Items.Remove(sitem);
                layerChart.Series.RemoveAt(ind+1);
            }
        }

        private void LayerLV_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Insert)
            {
                btnAdd_Click(this, new EventArgs());
                return;
            }
            if (LayerLV.SelectedItems.Count == 0)
            {
                return;
            }
            int ind = LayerLV.SelectedItems[0].Index;
            if (e.KeyCode == Keys.PageDown)
            {
                if ( ind == LayerLV.Items.Count ) return;
                Layer layeritem = layerstack[ind];
                layerstack.RemoveAt(ind);
                layerstack.Insert(ind + 1, layeritem);
                ListViewItem lvi = LayerLV.Items[ind];
                LayerLV.Items.RemoveAt(ind);
                LayerLV.Items.Insert(ind + 1, lvi);
                var scs = layerChart.Series[ind + 1];
                layerChart.Series.RemoveAt(ind + 1);
                layerChart.Series.Insert(ind + 2, scs);

                return;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                if (ind == 0) return;
                Layer layeritem = layerstack[ind];
                layerstack.RemoveAt(ind);
                layerstack.Insert(ind - 1, layeritem);
                ListViewItem lvi = LayerLV.Items[ind];
                LayerLV.Items.RemoveAt(ind);
                LayerLV.Items.Insert(ind - 1, lvi);
                var scs = layerChart.Series[ind + 1];
                layerChart.Series.RemoveAt(ind + 1);
                layerChart.Series.Insert(ind , scs);
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnDel_Click(this, new EventArgs());
                return;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                btnRun_Click(this, new EventArgs());
            }
        }

        private void freeze_all(Control con, bool enable)
        {
            foreach (Control c in con.Controls)
            {
                freeze_all(c, enable);
            }
            con.Enabled = enable;
        }

        private void enable_con(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                enable_con(con.Parent);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (layerstack.Count <= 1)
            { 
                MessageBox.Show("The bottom layer is considered the substrate. " +
                        "There needs to be at least 1 layer other than the substrate to compute. " +
                        "\nModify the model and try again. ",
                      "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);
                return;
            }
            for (int ilayer = 0; ilayer < layerstack.Count; ilayer++)
            {
                if (layerstack[ilayer].Thickness <= resolution)
                {
                    MessageBox.Show("The etch resolution is smaller" +
                        "than one of the layers' thickness. " +
                        "\nReduce the resolution and try again. ",
                      "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            bgWorkerRun.RunWorkerAsync();
            freeze_all(this, false);
        }

        private void bgWorkerRun_DoWork(object sender, DoWorkEventArgs e)
        {
            // 把Layerstack改为深度拷贝否则扰乱第二次编辑和运行
            // 将layerstack逆序以符合 前面是top 后面是substrate 的计算规则
            var localLayerStack = new List<Layer>();
            foreach (var item in layerstack)
            {
                localLayerStack.Add(item);
            }
            localLayerStack.Reverse();

            Layer substrate = localLayerStack.Last();
            localLayerStack.RemoveAt(localLayerStack.Count - 1);
            for (int ilayer = 0; ilayer < localLayerStack.Count; ilayer++)
            {
                var currentlayer = localLayerStack[ilayer];
                //bgWorkerRun.ReportProgress(ilayer / layerstack.Count);
                while (currentlayer.Thickness > resolution)
                {
                    currentlayer.Thickness -= resolution;
                    etchedlayers.Add(currentlayer);
                    Rfrindex.Add(currentlayer.Ri.Real);
                    stepList.Add(step);
                    step++;
                    var TMM = new ClassTMM(localLayerStack, 0);
                    TMM.Substrate = substrate;
                    TMM.Solve(wavelength);
                    solutionList.Add(TMM.Rs);
                }
            }
        }

        private void bgWorkerRun_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RunProgress.Value = e.ProgressPercentage;
        }

        private void numRes_ValueChanged(object sender, EventArgs e)
        {
            resolution = (double)numRes.Value;
        }

        private void numWavelength_ValueChanged(object sender, EventArgs e)
        {
            wavelength = (double)numWavelength.Value;
        }

        private void bgWorkerRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var frmresult = new FormLEES(stepList, resolution, Rfrindex, solutionList);
            frmresult.ShowDialog();
            freeze_all(this, true);
        }
    }
}
