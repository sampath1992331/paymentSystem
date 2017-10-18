using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            
            String cmd = "SELECT userid,fname,lname,contactnumber FROM userdetails ";
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           

        }

        private void save_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
               
                OleDbCommand cmdcheck = con1.CreateCommand();
                con1.Open();
                cmdcheck.CommandText = "SELECT fname, contactnumber FROM userdetails where userid=" + userid.Text + "  ";
                OleDbDataReader drcheck = cmdcheck.ExecuteReader();
               
                if (drcheck.HasRows) {
                  
                  // String a = drcheck["fname"].ToString();
                    MessageBox.Show("there exist user");
                }

                else
                {
                    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

                    OleDbCommand cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = "Insert into userdetails(fname,lname,contactnumber,userid)Values('" + fname.Text + "','" + lname.Text + "','" + contactnum.Text + "','" + userid.Text + "')";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Submitted", "Congrats");

                    OleDbCommand cmd1 = con.CreateCommand();
                    double a = 0;

                    cmd1.CommandText = "Insert into prevmonth(prevareas,cusid)Values(" + a + ",'" + userid.Text + "')";
                    cmd1.Connection = con;
                    cmd1.ExecuteNonQuery();
                    OleDbCommand cmd2 = con.CreateCommand();
                    cmd2.CommandText = "Insert into prevmonthf2(f2,cusid)Values(" + a + ",'" + userid.Text + "')";
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();

                    con.Close();

                }
            
            
            
            
            }
            catch(Exception E){
                MessageBox.Show(E.ToString());
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h1 = new Home();
            h1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fname.Text = "";
            lname.Text = "";
            contactnum.Text = "";
            userid.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "delete * from userdetails where userid = " + userid.Text + " ";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted", "Congrats");

               
                con.Close();

            }

            catch (Exception E) { E.ToString(); }



        }
    }
}
