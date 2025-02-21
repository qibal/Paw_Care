using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PawCare.Controller;



namespace PawCare.View
{
    public partial class Home : Form
    {
        private C_home controller;

        public Home()
        {
            InitializeComponent();
            controller = new C_home();
            LoadTotalAnimals();
            LoadGenderData();
        }
        private void LoadTotalAnimals()
        {
            int totalAnimals = controller.GetTotalAnimals();
            counted_animal.Text = totalAnimals.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadGenderData()
        {
            Dictionary<string, int> genderCounts = controller.GetGenderCounts();

            // Clear any existing series
            genderPieChart.Series.Clear();

            // Create a new pie chart series
            Series series = new Series("Gender");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true; // Show data values as labels

            // Add data points to the series
            foreach (var gender in genderCounts)
            {
                series.Points.AddXY(gender.Key, gender.Value);
            }

            // Add the series to the chart
            genderPieChart.Series.Add(series);

            // Chart title
            genderPieChart.Titles.Clear();
            genderPieChart.Titles.Add("Total Animal By gender");
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void genderPieChart_Click(object sender, EventArgs e)
        {

        }
    }
}
