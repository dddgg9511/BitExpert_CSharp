using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimpleWindow
{
    class MyForm : Form
    {
        Button button = new Button();
        
        public MyForm()
        {
            button.Text = "Click Me!";
            button.Left = 100;
            button.Top = 50;
            button.Click += (object sender, EventArgs e) =>
              {
                  MessageBox.Show("딸깍!");
              };
            this.Text = "Form & Control";
            this.Height = 150;

            this.Controls.Add(button);
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.Click += new EventHandler((sender, eventArgs) =>
              {
                  Application.Exit();
              });
            Application.Run(form);

        }
    }
}
