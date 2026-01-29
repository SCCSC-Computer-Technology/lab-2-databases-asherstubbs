using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Stubbs_Lab_2
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        public void Load(DataTable table)
        {
            dgvReport.DataSource = table;
        }
    }
}
