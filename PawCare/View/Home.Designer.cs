namespace PawCare.View
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.counted_animal = new System.Windows.Forms.Label();
            this.counted_peralatan = new System.Windows.Forms.Label();
            this.genderPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.genderPieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Hewan";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Peralatan";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // counted_animal
            // 
            this.counted_animal.AutoSize = true;
            this.counted_animal.Location = new System.Drawing.Point(33, 43);
            this.counted_animal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.counted_animal.Name = "counted_animal";
            this.counted_animal.Size = new System.Drawing.Size(13, 13);
            this.counted_animal.TabIndex = 2;
            this.counted_animal.Text = "0";
            this.counted_animal.Click += new System.EventHandler(this.counted_animal_Click);
            // 
            // counted_peralatan
            // 
            this.counted_peralatan.AutoSize = true;
            this.counted_peralatan.Location = new System.Drawing.Point(147, 43);
            this.counted_peralatan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.counted_peralatan.Name = "counted_peralatan";
            this.counted_peralatan.Size = new System.Drawing.Size(13, 13);
            this.counted_peralatan.TabIndex = 3;
            this.counted_peralatan.Text = "0";
            // 
            // genderPieChart
            // 
            chartArea2.Name = "ChartArea1";
            this.genderPieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.genderPieChart.Legends.Add(legend2);
            this.genderPieChart.Location = new System.Drawing.Point(288, 12);
            this.genderPieChart.Name = "genderPieChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.genderPieChart.Series.Add(series2);
            this.genderPieChart.Size = new System.Drawing.Size(185, 150);
            this.genderPieChart.TabIndex = 4;
            this.genderPieChart.Text = "chart1";
            this.genderPieChart.Click += new System.EventHandler(this.genderPieChart_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 351);
            this.Controls.Add(this.genderPieChart);
            this.Controls.Add(this.counted_peralatan);
            this.Controls.Add(this.counted_animal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.genderPieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label counted_animal;
        private System.Windows.Forms.Label counted_peralatan;
        private System.Windows.Forms.DataVisualization.Charting.Chart genderPieChart;
    }
}