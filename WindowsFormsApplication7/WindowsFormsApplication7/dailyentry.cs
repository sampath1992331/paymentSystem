using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class dailyentry : Form
    {
        public dailyentry()
        {
            InitializeComponent();
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

            //for tpacket1valuechange
            con.Open();
            OleDbCommand cmdtp1 = con.CreateCommand();
            cmdtp1.CommandType = CommandType.Text;
            cmdtp1.CommandText = "SELECT tpvalue1 FROM tpacktvalue1 ORDER BY ID DESC";
            OleDbDataReader drtp1 = cmdtp1.ExecuteReader();
            drtp1.Read();

            String tp1 = drtp1["tpvalue1"].ToString();
            checkBox1.Text = tp1;

            drtp1.Close();
            con.Close();
            //for tpacket2valuechange
            con.Open();
            OleDbCommand cmdtp2 = con.CreateCommand();
            cmdtp2.CommandType = CommandType.Text;
            cmdtp2.CommandText = "SELECT tpvalue2 FROM tpacktvalue2 ORDER BY ID DESC";
            OleDbDataReader drtp2 = cmdtp2.ExecuteReader();
            drtp2.Read();

            String tp2 = drtp2["tpvalue2"].ToString();
            checkBox2.Text = tp2;

            drtp2.Close();
            con.Close();
            //for f1value change
            con.Open();
            OleDbCommand cmdf1 = con.CreateCommand();
            cmdf1.CommandType = CommandType.Text;
            cmdf1.CommandText = "SELECT fvalue1 FROM settingf1 ORDER BY ID DESC";
            OleDbDataReader drf1 = cmdf1.ExecuteReader();
            drf1.Read();

            String f1 = drf1["fvalue1"].ToString();
            checkBoxF1.Text = f1;

            drf1.Close();
            con.Close();
            //for f2value change
            con.Open();
            OleDbCommand cmdf2 = con.CreateCommand();
            cmdf2.CommandType = CommandType.Text;
            cmdf2.CommandText = "SELECT fvalue2 FROM settingf2 ORDER BY ID DESC";
            OleDbDataReader drf2 = cmdf2.ExecuteReader();
            drf2.Read();

            String f2 = drf2["fvalue2"].ToString();
            checkBoxF2.Text = f2;





        }

        private void adddata_Click(object sender, EventArgs e)
        {
            
                
                if (tealeavetxtbx.Text != "" && cusidfind.Text != "")
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

                        OleDbCommand cmd = con.CreateCommand();
                        con.Open();


                        ///////////////////
                        double tealeaves = gettealeaves();

                        double totaltpacktvalue = gettotaltpacktvalue();
                        int cusid = getcusid();
                        double fertilizer = getfertilizer();
                        double f1value = fertilizer / 2;
                        string datetime = dateTimePicker1.Value.ToShortDateString();
                        double advance = getadvance();
                        double other = getother();

                        cmd.CommandText = "Insert into rawdata(tealeaves,f1value,cusid,date_,tpackt1value,advance,other,f2value)Values('" + tealeaves + "','" + f1value + "'," + cusid + ",'" + datetime + "','" + totaltpacktvalue + "','" + advance + "','" + other + "','" + f1value + "')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Submitted", "Congrats");
                        con.Close();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.ToString());

                    }


                }
                else
                {
                    MessageBox.Show("තේ දලු කිලෝ ප්‍රමානය ඇතුලත් කිරිම අනිවාර්‍ය වේ ,මග හැරිමට '0' ඇතුලත් කරන්න ");
                }

                
            

            

        }
     

        private double getother()
        {
            double advance = 0;
            if (othertxtbx.Text == "")
            {

                advance = 0;
            }
            else if (othertxtbx.Text != "")
            {

                advance = double.Parse(othertxtbx.Text);
            }
            return advance;
        }

        private double getadvance()
        {
            double advance = 0;
            if (advancetxtbx.Text == "") {

                advance = 0;
            }
            else if(advancetxtbx.Text!=""){

                advance = double.Parse(advancetxtbx.Text);
            }
            return advance;
        }

        private double getfertilizer()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            OleDbCommand cmdf1 = con.CreateCommand();
            cmdf1.CommandType = CommandType.Text;
            cmdf1.CommandText = "SELECT fvalue1 FROM settingf1 ORDER BY ID DESC";
            OleDbDataReader drf1 = cmdf1.ExecuteReader();
            drf1.Read();

            String f1 = drf1["fvalue1"].ToString();
            //checkBox1.Text = f1;

            drf1.Close();
            
            OleDbCommand cmdf2 = con.CreateCommand();
            cmdf2.CommandType = CommandType.Text;
            cmdf2.CommandText = "SELECT fvalue2 FROM settingf2 ORDER BY ID DESC";
            OleDbDataReader drf2 = cmdf2.ExecuteReader();
            drf2.Read();

            String f2 = drf2["fvalue2"].ToString();
            //checkBox3.Text = f2;

            drf1.Close();
            con.Close();
            double fertilizer2 = double.Parse(f2);
            double fertilizer1 = double.Parse(f1);
            
            try {
                double fer = 0;
                

                 if (checkBoxF1.Checked && checkBoxF2.Checked )
                {

                
                   
                    
                        double b = double.Parse(numofF2.Text);
                        double a = double.Parse(numofF1.Text);
                        fer = a * fertilizer1 + b * fertilizer2;
                    

                }
                else if (checkBoxF2.Checked)
                {


                    double b = double.Parse(numofF2.Text);
                    fer = b * fertilizer2;

                }

                else if(checkBoxF1.Checked){
                 double a = double.Parse(numofF1.Text);
                    fer = a*fertilizer1;
                }

                return fer;
            
            
            
            
            }

            catch (Exception E) { MessageBox.Show(E.ToString());

            return 0;
            }
        }   


        

        private double gettotaltpacktvalue()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            OleDbCommand cmdtp1 = con.CreateCommand();
            cmdtp1.CommandType = CommandType.Text;
            cmdtp1.CommandText = "SELECT tpvalue1 FROM tpacktvalue1 ORDER BY ID DESC";
            OleDbDataReader drtp1 = cmdtp1.ExecuteReader();
            drtp1.Read();

            String tp1 = drtp1["tpvalue1"].ToString();
            checkBox1.Text = tp1;
            drtp1.Close();
            con.Close();
            //for tpackt 2 value
            con.Open();
            OleDbCommand cmdtp2 = con.CreateCommand();
            cmdtp2.CommandType = CommandType.Text;
            cmdtp2.CommandText = "SELECT tpvalue2 FROM tpacktvalue2 ORDER BY ID DESC";
            OleDbDataReader drtp2 = cmdtp2.ExecuteReader();
            drtp2.Read();

            String tp2 = drtp2["tpvalue2"].ToString();


            checkBox2.Text = tp2;

            drtp2.Close();
            con.Close();

            try
            {




                double tpttl = 0;
                double tpp1 = Convert.ToDouble(tp1);
                double tpp2 = Convert.ToDouble(tp2);





                if (checkBox1.Checked && checkBox2.Checked)
                {
                    double a = Convert.ToDouble(numoftpckt1.Text);
                    double b = Convert.ToDouble(numoftpackt2.Text);
                    double c = a * tpp1;
                    double d = b * tpp2;
                    tpttl = c + d;


                }
                else if (checkBox1.Checked)
                {
                    double a = Convert.ToDouble(numoftpckt1.Text);
                    tpttl = tpp1 * a;

                }
                else if (checkBox2.Checked)
                {
                    double b = Convert.ToDouble(numoftpackt2.Text);
                    tpttl = tpp2 * b;
                }

                return tpttl;







            }

            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                return 0;
            }



        }

        private int getcusid()
        {

            int cusid = 0;
            if(cusidfind.Text==""){

                MessageBox.Show("Please Enter Customer ID");
                return cusid;
            }
            else if (cusidfind.Text != "")
            {
                cusid = Convert.ToInt16(cusidfind.Text);

                return cusid;
            }


            return cusid;
        }

        private double getf1value()
        {
            double temp = 0;
            if (numofF1.Text == "")
            {

                temp = 0;
            }
            else if (numofF1.Text != "")
            {

                temp = double.Parse(numofF1.Text);
            }

            return temp;
        }

        private double gettealeaves()
        {
            double tealeaves = 0;
            if (tealeavetxtbx.Text == "") {

                tealeaves = 0;
            }
            else if (tealeavetxtbx.Text != "") {

                tealeaves = double.Parse(tealeavetxtbx.Text);
            }

            return tealeaves;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "SELECT fname,contactnumber ,lname FROM userdetails where userid= " + cusidfind.Text + "";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                   String a = dr["lname"].ToString();
                    String b = dr["fname"].ToString();
                    String c = dr["contactnumber"].ToString();
                   // String d = dr["lastname"].ToString();

                    fnamesw.Text = b;
                    
                    cntctnumsw.Text = c;
                    lnamesw.Text = a;
                    dr.Close();
                }

                else
                {

                    MessageBox.Show("NO Valid Customer");

                }




                con.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tealeavetxtbx.Text = "";
            othertxtbx.Text = "";
            numofF1.Text = "";
            numofF2.Text = "";
            numoftpackt2.Text = "";
            numoftpckt1.Text = "";
            advancetxtbx.Text = "";
            checkBoxF1.Checked = false;
            checkBoxF2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h3 = new Home();
            h3.Show();
        }
    }
}
