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
using ClassLibrary1;
using System.IO;
namespace Interface
{
    public partial class Filters : Form
    {
        ProcessInfoStorage pis;
        public Filters( ProcessInfoStorage piss)
        {
            InitializeComponent();
            pis = piss;
            foreach (var item in pis)
                FiltersGrid.Rows.Add(item.CategoryName, item.CategoryDuration);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (var fs = new StreamWriter(DateTime.Now.ToString(),true))
            {
                foreach (var item in pis)
                {
                    fs.Write(item.ToString());
                }
                
            }

        }

        private void FiltersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
