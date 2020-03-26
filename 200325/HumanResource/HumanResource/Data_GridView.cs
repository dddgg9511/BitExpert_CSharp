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
    public partial class Data_GridView : Form
    {
        public Data_GridView()
        {
            InitializeComponent();
        }

        private void Data_GridView_Load(object sender, EventArgs e)
        {
            DataSet dataSet = HrDAC.Instance.getInfo();
            dataGridView_Locations.DataSource = dataSet.Tables["Locations"];
            dataGridView_Jobs.DataSource = dataSet.Tables["Jobs"];
        }
    }
}
