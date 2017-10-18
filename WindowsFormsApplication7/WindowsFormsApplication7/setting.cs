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
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            try
            {
                con.Open();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                double trate = Convert.ToDouble(settingtpv1.Text);
                DateTime datetime = DateTime.Now;
                //dateTimePicker1.Text = datetime.ToString();

                cmd.CommandText = "INSERT INTO tpacktvalue1(tpvalue1) VALUES('" + trate + "')";
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("You Successfully Change the Transport Rate as RS: " + " " + trate);
                }
                else
                {
                    MessageBox.Show("Please Enter The Valid Value");
                }

                con.Close();
            }
            catch (Exception E) { MessageBox.Show(E.ToString(), "Something Is Wrong"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            try
            {
                con.Open();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                double trate = Convert.ToDouble(settingtpv2.Text);
                DateTime datetime = DateTime.Now;
                dateTimePicker1.Text = datetime.ToString();

                cmd.CommandText = "INSERT INTO tpacktvalue2(tpvalue2) VALUES('" + trate + "')";
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("You Successfully Change the Transport Rate as RS: " + " " + trate);
                }
                else
                {
                    MessageBox.Show("Please Enter The Valid Value");
                }

                con.Close();
            }
            catch (Exception E) { MessageBox.Show(E.ToString(), "Something Is Wrong"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con.Open();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                double trate = Convert.ToDouble(settingtransportrate.Text);
                DateTime datetime = DateTime.Now;
                dateTimePicker1.Text = datetime.ToString();

                cmd.CommandText = "INSERT INTO settingtransportrate(transportrate,date_) VALUES('" + trate + "','" + datetime + "')";
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("You Successfully Change the Tea Rate as RS: " + " " + trate + " For The" + " " + datetime);
                }
                else
                {
                    MessageBox.Show("Please Enter The Valid Value");
                }

                con.Close();
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con.Open();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                double trate = Convert.ToDouble(settingtearate.Text);
                DateTime datetime = DateTime.Now;
                dateTimePicker1.Text = datetime.ToString();

                cmd.CommandText = "INSERT INTO settingtrate(trate,date_) VALUES('" + trate + "','" + datetime + "')";
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("You Successfully Change the Tea Rate as RS: " + " " + trate + " For The" + " " + datetime);
                }
                else
                {
                    MessageBox.Show("Please Enter The Valid Value");
                }

                con.Close();
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con.Open();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                double trate = Convert.ToDouble(settingf1.Text);
                DateTime datetime = DateTime.Now;
                dateTimePicker1.Text = datetime.ToString();

                cmd.CommandText = "INSERT INTO settingf1(fvalue1,date_) VALUES('" + trate + "','" + datetime + "')";
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("You Successfully Change the Tea Rate as RS: " + " " + trate + " For The" + " " + datetime);
                }
                else
                {
                    MessageBox.Show("Please Enter The Valid Value");
                }

                con.Close();
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con.Open();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                double trate = Convert.ToDouble(settingf2.Text);
                DateTime datetime = DateTime.Now;
                dateTimePicker1.Text = datetime.ToString();

                cmd.CommandText = "INSERT INTO settingf2(fvalue2,date_) VALUES('" + trate + "','" + datetime + "')";
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("You Successfully Change the Tea Rate as RS: " + " " + trate + " For The" + " " + datetime);
                }
                else
                {
                    MessageBox.Show("Please Enter The Valid Value");
                }

                con.Close();
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }
    }
}
