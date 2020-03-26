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
    public partial class All_Inquire : Form
    {
        public All_Inquire()
        {
            InitializeComponent();
        }

        private void All_Inquire_Load(object sender, EventArgs e)
        {
            ICollection<Employee> employees = HrDAC.Instance.GetEmployeeList();
            listView1.Columns[0].TextAlign = HorizontalAlignment.Center;
            foreach(Employee emp in employees)
            {
                ListViewItem listViewItem = new ListViewItem(emp.Employee_id.ToString());
                listViewItem.SubItems.Add(emp.First_name + " " + emp.Last_name);
                listViewItem.SubItems.Add(emp.Phone_number);
                listViewItem.SubItems.Add(emp.Hire_date.ToShortDateString());
                listViewItem.SubItems.Add(emp.Salary.ToString());
                listView1.Items.Add(listViewItem);
            }
        }
    }
}
