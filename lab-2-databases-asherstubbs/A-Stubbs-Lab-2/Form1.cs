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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(cbSort.SelectedItem != null)
            {
                if(cbSort.SelectedItem.ToString() == "Population ASC")
                {
                    DataTable report = this.cityTableAdapter.PopASCTable();
                    Report window = new Report();
                    window.Load(report);
                    window.ShowDialog();
                }
                if(cbSort.SelectedItem.ToString() == "Population DESC")
                {
                    DataTable report = this.cityTableAdapter.PopDESCTable();
                    Report window = new Report();
                    window.Load(report);
                    window.ShowDialog();
                }
                if(cbSort.SelectedItem.ToString() == "City Alphabetical")
                {
                    DataTable report = this.cityTableAdapter.AlphaTable();
                    Report window = new Report();
                    window.Load(report);
                    window.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Must select a sort type!");
                return;
            }
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            if(cbPop.SelectedItem != null )
            {
                if (cbPop.SelectedItem.ToString() == "Total")
                {
                    MessageBox.Show("Total population in all cities is: " + this.cityTableAdapter.TotalPop());
                }
                if(cbPop.SelectedItem.ToString() == "Average")
                {
                    MessageBox.Show("Average population for all cities is: "+this.cityTableAdapter.AvgPop());
                }
                if(cbPop.SelectedItem.ToString() == "Highest")
                {
                    DataTable report = this.cityTableAdapter.MaxTable();
                    Report window = new Report();
                    window.Load(report);
                    window.ShowDialog();
                }
                if(cbPop.SelectedItem.ToString() == "Lowest")
                {
                    DataTable report = this.cityTableAdapter.MinTable();
                    Report window = new Report();
                    window.Load(report);
                    window.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Must select population type!");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbPop.SelectedItem = null;
            cbSort.SelectedItem = null;
        }
    }
}
