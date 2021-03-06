﻿namespace csLEES
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TLPmain = new System.Windows.Forms.TableLayoutPanel();
            this.btnRun = new System.Windows.Forms.Button();
            this.TLPlayers = new System.Windows.Forms.TableLayoutPanel();
            this.layerChart = new LiveCharts.WinForms.CartesianChart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.LayerLV = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numWavelength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numRes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RunProgress = new System.Windows.Forms.ProgressBar();
            this.bgWorkerRun = new System.ComponentModel.BackgroundWorker();
            this.TLPmain.SuspendLayout();
            this.TLPlayers.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWavelength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRes)).BeginInit();
            this.SuspendLayout();
            // 
            // TLPmain
            // 
            this.TLPmain.ColumnCount = 2;
            this.TLPmain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.29095F));
            this.TLPmain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.70904F));
            this.TLPmain.Controls.Add(this.btnRun, 1, 1);
            this.TLPmain.Controls.Add(this.TLPlayers, 0, 0);
            this.TLPmain.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.TLPmain.Controls.Add(this.RunProgress, 0, 1);
            this.TLPmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPmain.Location = new System.Drawing.Point(0, 0);
            this.TLPmain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPmain.Name = "TLPmain";
            this.TLPmain.RowCount = 2;
            this.TLPmain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.05882F));
            this.TLPmain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.94118F));
            this.TLPmain.Size = new System.Drawing.Size(688, 483);
            this.TLPmain.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(520, 422);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(166, 59);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "GO 》";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // TLPlayers
            // 
            this.TLPlayers.ColumnCount = 2;
            this.TLPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPlayers.Controls.Add(this.layerChart, 1, 0);
            this.TLPlayers.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.TLPlayers.Controls.Add(this.LayerLV, 0, 0);
            this.TLPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPlayers.Location = new System.Drawing.Point(2, 2);
            this.TLPlayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPlayers.Name = "TLPlayers";
            this.TLPlayers.RowCount = 2;
            this.TLPlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TLPlayers.Size = new System.Drawing.Size(514, 416);
            this.TLPlayers.TabIndex = 1;
            // 
            // layerChart
            // 
            this.layerChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerChart.Location = new System.Drawing.Point(259, 2);
            this.layerChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layerChart.Name = "layerChart";
            this.layerChart.Size = new System.Drawing.Size(253, 370);
            this.layerChart.TabIndex = 1;
            this.layerChart.TabStop = false;
            this.layerChart.Text = "Layer structure";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 376);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(253, 38);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 19);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(62, 2);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 19);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Remove";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // LayerLV
            // 
            this.LayerLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerLV.HideSelection = false;
            this.LayerLV.Location = new System.Drawing.Point(2, 2);
            this.LayerLV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LayerLV.Name = "LayerLV";
            this.LayerLV.Size = new System.Drawing.Size(253, 370);
            this.LayerLV.TabIndex = 3;
            this.LayerLV.UseCompatibleStateImageBehavior = false;
            this.LayerLV.View = System.Windows.Forms.View.List;
            this.LayerLV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LayerLV_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numWavelength, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numRes, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(520, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(166, 416);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wavelength";
            // 
            // numWavelength
            // 
            this.numWavelength.Location = new System.Drawing.Point(71, 18);
            this.numWavelength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numWavelength.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numWavelength.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numWavelength.Name = "numWavelength";
            this.numWavelength.Size = new System.Drawing.Size(63, 20);
            this.numWavelength.TabIndex = 1;
            this.numWavelength.Value = new decimal(new int[] {
            670,
            0,
            0,
            0});
            this.numWavelength.ValueChanged += new System.EventHandler(this.numWavelength_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Resolution";
            // 
            // numRes
            // 
            this.numRes.Location = new System.Drawing.Point(71, 42);
            this.numRes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numRes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRes.Name = "numRes";
            this.numRes.Size = new System.Drawing.Size(63, 20);
            this.numRes.TabIndex = 4;
            this.numRes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRes.ValueChanged += new System.EventHandler(this.numRes_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "nm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "nm";
            // 
            // RunProgress
            // 
            this.RunProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunProgress.Location = new System.Drawing.Point(2, 422);
            this.RunProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RunProgress.Name = "RunProgress";
            this.RunProgress.Size = new System.Drawing.Size(514, 59);
            this.RunProgress.TabIndex = 3;
            // 
            // bgWorkerRun
            // 
            this.bgWorkerRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerRun_DoWork);
            this.bgWorkerRun.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerRun_ProgressChanged);
            this.bgWorkerRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerRun_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 483);
            this.Controls.Add(this.TLPmain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "csLEES";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.TLPmain.ResumeLayout(false);
            this.TLPlayers.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWavelength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPmain;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TableLayoutPanel TLPlayers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWavelength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private LiveCharts.WinForms.CartesianChart layerChart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListView LayerLV;
        private System.ComponentModel.BackgroundWorker bgWorkerRun;
        private System.Windows.Forms.ProgressBar RunProgress;
    }
}

