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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");


                con.Open();
                DateTime now = DateTime.Now;
                String nowdate = now.ToString("MMMM");
                var fday = new DateTime(now.Year, now.Month, 1);
                var lday = fday.AddMonths(1).AddDays(-1);
                label3.Text = "Up to Now"+" ("+nowdate+")";
                OleDbCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT SUM(tealeaves) as totaltleave FROM rawdata WHERE date_ BETWEEN #" + fday + "# AND #" + lday + "#";

                OleDbDataReader dr = cmd1.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    String totaltleave = dr["totaltleave"].ToString();
                    ttltlvup2nw.Text = totaltleave;

                }
                else
                {

                    ttltlvup2nw.Text = "No Data Up to Now";
                }



                dr.Close();

                /* var today = DateTime.Today;
                 var month = new DateTime(today.Year,today.Month,1);
                 var first = month.AddMonths(-1);
                 var last = month.AddDays(-1);*/

                OleDbCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT SUM(advance) as totalad FROM rawdata WHERE date_ BETWEEN #" + fday + "# AND #" + lday + "#";

                OleDbDataReader dr2 = cmd2.ExecuteReader();

                dr2.Read();
                    String totalad = dr2["totalad"].ToString();
                    ttladvanceup2nw.Text = totalad.ToString();

       



                dr2.Close();

                /////////////////////////////
               OleDbCommand cmdareas = con.CreateCommand();
                cmdareas.CommandType = CommandType.Text;
                cmdareas.CommandText = "SELECT SUM(prevareas) as totalar FROM prevmonth WHERE date_ BETWEEN #" + fday + "# AND #" + lday + "#";

                OleDbDataReader drareas = cmdareas.ExecuteReader();

                drareas.Read();
                String totalar = drareas["totalar"].ToString();
                label5.Text = totalar.ToString();





                drareas.Close();


                ////////////////////////////
                String cmd = "SELECT cusid,prevareas FROM prevmonth where prevareas BETWEEN " + -1 + " AND " + -1000000 + " ";
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd, con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;


                ////////////////////////////for find maximum areaser
                OleDbCommand cmdprevareas = con.CreateCommand();
                cmdprevareas.CommandType = CommandType.Text;
                cmdprevareas.CommandText = "SELECT prevareas ,cusid FROM prevmonth WHERE prevareas= (SELECT min(prevareas) FROM prevmonth) ";
                OleDbDataReader drprev = cmdprevareas.ExecuteReader();
                drprev.Read();
                if (drprev.HasRows)
                {
                    String a = drprev["cusid"].ToString();
                    String prevareas = drprev["prevareas"].ToString();
                    
                    OleDbCommand cmdp = con.CreateCommand();
                    cmdp.CommandType = CommandType.Text;
                    cmdp.CommandText = "SELECT fname FROM userdetails WHERE userid="+a+" ";
                    OleDbDataReader drp = cmdp.ExecuteReader();
                    drp.Read();
                    String name = drp["fname"].ToString();

                    blname.Text = name;
                    blamount.Text = prevareas;


                }
                else
                {
                    blname.Text = "No Fertilizer For Prevmonth";

                }



                drprev.Close();



                //////////////////////////////////////////////////////






            }

            catch (Exception E) {
                MessageBox.Show("No Update to show Up to Now");
            }












        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration r = new registration();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            dailyentry d = new dailyentry();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            setting s = new setting();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            datacalculate d = new datacalculate();
            d.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Deleterecords dd = new Deleterecords();
            dd.Show();








        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
