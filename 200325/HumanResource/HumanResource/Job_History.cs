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
    public partial class Job_History : Form
    {
        public Job_History()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int empNo = int.Parse(Tb_Employee_ID.Text.ToString());
            ICollection<DataMapper> histories = HrDAC.Instance.getHistory(empNo);
            listView1.Items.Clear();
            foreach(DataMapper data in histories)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = data.StringValue1;
                lvItem.SubItems.Add(data.StringValue2);
                lvItem.SubItems.Add(data.DateTimeValue1.ToShortDateString());
                lvItem.SubItems.Add(data.DateTimeValue2.ToShortDateString());
                listView1.Items.Add(lvItem);
            }
        }
    }
}

