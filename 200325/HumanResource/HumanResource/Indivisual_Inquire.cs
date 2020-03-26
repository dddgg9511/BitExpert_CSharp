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
    public partial class Indivisual_Inquire : Form
    {
        public Indivisual_Inquire()
        {
            InitializeComponent();
        }

        private void BTN_INQUIRY_Click(object sender, EventArgs e)
        {
            Employee emp = HrDAC.Instance.GetEmployee(long.Parse(Tb_Emp_ID.Text));
            Tb_Emp_Fname.Text = emp.First_name;
            Tb_Emp_Lname.Text = emp.Last_name;
            Tb_Emp_Email.Text = emp.Email;
            Tb_Emp_Number.Text = emp.Phone_number;
            Tb_Emp_HireDate.Text = emp.Hire_date.ToShortDateString();
            Tb_Emp_JID.Text = emp.Job_id;
            Tb_Emp_Salary.Text = emp.Salary.ToString();
            Tb_Emp_Commission.Text = emp.Commission.ToString();
            Tb_Emp_DID.Text = (emp.Department_ID == "0") ? "없음" : emp.Department_ID;
            Tb_Emp_MID.Text = (emp.Manager_ID=="0") ? "없음" : emp.Manager_ID;
        }
    }
}
