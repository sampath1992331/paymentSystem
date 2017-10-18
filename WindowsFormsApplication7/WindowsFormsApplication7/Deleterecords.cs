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
    public partial class Deleterecords : Form
    {
        public Deleterecords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            string datetime01 = dateTimePicker1.Value.ToShortDateString();
            
            String cmd = "SELECT date_,tealeaves,advance,f1value ,tpackt1value,other FROM rawdata where cusid=" + textBox1.Text + "AND date_ = #" + datetime01 + "# ";
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;


            

            
           
            OleDbCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT fname,lname, contactnumber FROM userdetails where userid=" + textBox1.Text + "  ";
            OleDbDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                String a = dr["fname"].ToString();
                String b = dr["contactnumber"].ToString();
                String c = dr["lname"].ToString();

                fnamesw.Text = a;
                cntactsw.Text = b;
                lnamesw.Text = c;

            }
            else
            {
                String m = textBox1.Text;
                MessageBox.Show(m + " " + "is not a valid customer");
            }



            dr.Close();


                



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            string datetime01 = dateTimePicker1.Value.ToShortDateString();
            cmd.CommandText = "delete * from rawdata where cusid = " + textBox1.Text + " and date_ =#"+datetime01+"#";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted", "Congrats");


            con.Close();
        }

        private void Deleterecords_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h5 = new Home();
            h5.Show();
        }
    }
}
