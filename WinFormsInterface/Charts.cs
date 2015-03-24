using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using TimeTrackLibrary.Interfaces;
namespace WinFormsInterface
{
    public partial class Charts : Form
    {
        IProcessSessionRepository _repo;
        public Charts( IProcessSessionRepository repo)
        {
            InitializeComponent();
            _repo = repo;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
        }

        private void FiltersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void ClearChart()
        { 
            foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

        }
        private void Filters_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==true)
            {
               //ClearChart();
                chart1.Series[0].Points.Clear();
                
                //FiltersGrid.Rows.Clear();
                foreach (var item in _repo.Get())
                {
                
                }

            }
        }

        private void Filters_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
