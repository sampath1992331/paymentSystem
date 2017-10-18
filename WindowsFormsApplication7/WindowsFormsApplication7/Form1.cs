using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();













        }

        private void button1_Click(object sender, EventArgs e)
        {
            registration reg = new registration();
            reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dailyentry da = new dailyentry();
            da.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setting set = new setting();
            set.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            datacalculate dat = new datacalculate();
            dat.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {


          /*  string uname = username.Text;
            string pw = password.Text;

            string realuname = "suranga";
            string realpw = "123456";

            if (uname == realuname && pw == realpw) {*/
                
                 

               this.Hide();
        Home home = new Home();
        home.Show();

            
           /* }

            else {

                MessageBox.Show("Your User Name Or Password Not Matched");
            
            }*/




        }
    }
}
