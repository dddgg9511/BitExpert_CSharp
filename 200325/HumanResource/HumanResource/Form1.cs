using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResource
{
    public partial class Form1 : Form
    {
        Indivisual_Inquire indivisual_Inquire;
        All_Inquire All_Inquire;
        Job_History job_History;
        Data_GridView data_GridView;
        public Form1()
        {
            InitializeComponent();
            indivisual_Inquire = new Indivisual_Inquire();
            All_Inquire = new All_Inquire();
            job_History = new Job_History();
            data_GridView = new Data_GridView();
        }

        private void Menu_Inq_Indi_Employee_Click(object sender, EventArgs e)
        {

            indivisual_Inquire.ShowDialog();
        }

        private void Menu_Inq_All_Employee_Click(object sender, EventArgs e)
        {
            All_Inquire.ShowDialog();

        }

        private void 직무이력ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            job_History.ShowDialog();
        }

        private void 조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data_GridView.ShowDialog();
        }
    }
}
