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
    public partial class datacalculate : Form
    {
        public datacalculate()
        {
            InitializeComponent();
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            OleDbCommand cmdtransport = con.CreateCommand();
            cmdtransport.CommandType = CommandType.Text;
            cmdtransport.CommandText = "SELECT transportrate FROM settingtransportrate ORDER BY ID DESC";
            OleDbDataReader drtransport = cmdtransport.ExecuteReader();
            drtransport.Read();

            float transportrate = Convert.ToSingle(drtransport["transportrate"].ToString());

            trnsportratesw.Text = transportrate.ToString();

            drtransport.Close();
           
            //////////////////////////////
            OleDbCommand cmdt = con.CreateCommand();
            cmdtransport.CommandType = CommandType.Text;
            cmdtransport.CommandText = "SELECT trate FROM settingtrate ORDER BY ID DESC";
            OleDbDataReader drtvalue = cmdtransport.ExecuteReader();
            drtvalue.Read();

            float trate = Convert.ToSingle(drtvalue["trate"].ToString());



            drtvalue.Close();
            
            tleavesrate.Text = trate.ToString();





        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
           {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

                con.Open();
                string datetime01 = dateTimePicker1.Value.ToShortDateString();
                string datetime02 = dateTimePicker2.Value.ToShortDateString();
               
                 OleDbCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "SELECT fname, contactnumber FROM userdetails where userid=" + textBox1.Text + "  ";
                    OleDbDataReader dr = cmd1.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        String a = dr["fname"].ToString();
                        String b = dr["contactnumber"].ToString();

                        fnamesw2.Text = a;
                        contactsw2.Text = b;

                    }
                    else
                    {
                        String m = textBox1.Text;
                        MessageBox.Show(m + " " + "is not a valid customer");
                    }



                    dr.Close();


                //////////////////////////////////////////////////////////
                    
                    OleDbCommand cmdpf = con.CreateCommand();
                    cmdpf.CommandType = CommandType.Text;
                    cmdpf.CommandText = "SELECT f2 FROM prevmonthf2 WHERE cusid =" + textBox1.Text + "  ORDER BY ID DESC ";
                    OleDbDataReader drpf = cmdpf.ExecuteReader();
                    drpf.Read();
                    if (drpf.HasRows)
                    {
                        String a = drpf["f2"].ToString();

                        prevfertilizersw2.Text = a;


                    }
                    else
                    {
                        prevfertilizersw2.Text = "0";

                    }
                    drpf.Close();
                    //////////////////////////////////
                    OleDbCommand cmdprevareas = con.CreateCommand();
                    cmdprevareas.CommandType = CommandType.Text;
                    cmdprevareas.CommandText = "SELECT prevareas FROM prevmonth WHERE cusid="+textBox1.Text+" ORDER BY ID DESC ";
                    OleDbDataReader drprev = cmdprevareas.ExecuteReader();
                    drprev.Read();
                    if (drprev.HasRows)
                    {
                        String a = drprev["prevareas"].ToString();

                        prevareassw2.Text = a;


                    }
                    else
                    {
                        prevareassw2.Text = "0";

                    }



                    drprev.Close();


                ////////////////////////////////////////////

                   










                    //for total tealeaves


                    //string datetime3 = dateTimePicker1.Value.ToShortDateString();
                   // string datetime2 = dateTimePicker2.Value.ToShortDateString();
                    //for last month
                    var today = DateTime.Today;
                    var month = new DateTime(today.Year, today.Month, 1);
                    var first = month.AddMonths(-1);
                    var last = month.AddDays(-1);
                   ////////////////////////////////////////////////////////////////
                    DateTime now = DateTime.Now;
                    String nowdate = first.ToString("MMMM");
                  //  String nowdate2 = first.ToString("Y");
                    var fday = new DateTime(now.Year, now.Month, 1);
                    var lday = fday.AddMonths(1).AddDays(-1);
                    
               /////year 
                    string myDate = datetime01;
                    DateTime date = Convert.ToDateTime(myDate);
                    int year = date.Year;
                    showyear.Text = year.ToString();
                       label4.Text =   nowdate ;
                    
                ////////////////////////////////////////////////////////////////////////
                    OleDbCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT SUM(tealeaves) as totaltleave FROM rawdata WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + first + "# AND #" + last + "#";
                    OleDbDataReader drt = cmd2.ExecuteReader();
                    float totaltleave;     
               if (drt.HasRows)
                    {
                        drt.Read();


                        totaltleave = float.Parse(drt["totaltleave"].ToString());
                        ttltleavesw2.Text = totaltleave.ToString();

                        drt.Close();
                    }
                    else { ttltleavesw2.Text = "0";
                    totaltleave = 0;
               }
                //for transportrate
                    OleDbCommand cmdtransport = con.CreateCommand();
                    cmdtransport.CommandType = CommandType.Text;
                    cmdtransport.CommandText = "SELECT transportrate FROM settingtransportrate ORDER BY ID DESC";
                    OleDbDataReader drtransport = cmdtransport.ExecuteReader();
                    drtransport.Read();

                    float transportrate = Convert.ToSingle(drtransport["transportrate"].ToString());



                    drtransport.Close();
                    float totaltransportvalue = totaltleave * transportrate;
                    ttltransportsw2.Text = totaltransportvalue.ToString();
                //for totaltvalue

                    OleDbCommand cmdt = con.CreateCommand();
                    cmdtransport.CommandType = CommandType.Text;
                    cmdtransport.CommandText = "SELECT trate FROM settingtrate ORDER BY ID DESC";
                    OleDbDataReader drtvalue = cmdtransport.ExecuteReader();
                    drtvalue.Read();

                    float trate = Convert.ToSingle(drtvalue["trate"].ToString());



                    drtvalue.Close();
                    float totaltleavevalue = totaltleave * trate;
                    ttltleavevalue.Text = totaltleavevalue.ToString();
                /////////////////////////////////////////////////////////////////////////

                   //totaladvance

                    float totaladvance;
                    totaladvance = float.Parse(advanceM());
                    ttladvancesw2.Text = advanceM();
                    
                  ////////////////////////////////////////
                //total tpackt
                    OleDbCommand cmdtpacket = con.CreateCommand();
                    cmdtpacket.CommandType = CommandType.Text;
                    cmdtpacket.CommandText = "SELECT SUM(tpackt1value) as totaltpacket FROM rawdata WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                    OleDbDataReader drtpacket = cmdtpacket.ExecuteReader();
                    drtpacket.Read();


                    float totaltpacket = float.Parse(drtpacket["totaltpacket"].ToString());
                    ttltpcktvaluesw2.Text = totaltpacket.ToString();

                    drtpacket.Close();
                /////////////////////////////////////
                //fertilizer for thise month

                    OleDbCommand cmdfvalue2 = con.CreateCommand();
                    cmdfvalue2.CommandType = CommandType.Text;
                    cmdfvalue2.CommandText = "SELECT SUM(f1value) as totalfvalue2 FROM rawdata WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                   OleDbDataReader drfvalue2 = cmdfvalue2.ExecuteReader();
                    drfvalue2.Read();


                    float totalfvalue2 = Convert.ToSingle(drfvalue2["totalfvalue2"].ToString());
                    ttlf1sw2.Text = totalfvalue2.ToString();

                    drfvalue2.Close();

                //////////////////////total Othevalue/////////
                    OleDbCommand cmdother = con.CreateCommand();
                    cmdother.CommandType = CommandType.Text;
                    cmdother.CommandText = "SELECT SUM(other) as totalother FROM rawdata WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                    OleDbDataReader drother = cmdother.ExecuteReader();
                    drother.Read();


                    float totalother = Convert.ToSingle(drother["totalother"].ToString());
                    ttlothersw2.Text = totalother.ToString();

                    drother.Close();




                ///////////////////////////////////////
                //total increass

                    double prevf = double.Parse(prevfertilizersw2.Text);
                    double preareas = double.Parse(prevareassw2.Text);



                double totalincreases = totaladvance+totalfvalue2+totaltransportvalue+totaltpacket+prevf-preareas;
                ttlincreasessw2.Text = totalincreases.ToString();
                double netbalance = totaltleavevalue - totalincreases;
                netbalancesw2.Text = netbalance.ToString();
               ////////
                double totalareas = -preareas + prevf;
                ttlareassw2.Text = totalareas.ToString();


                String cmd = "SELECT date_,tealeaves,advance,f1value ,tpackt1value,other FROM rawdata where cusid=" + textBox1.Text + "AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd, con);
                DataTable dt = new DataTable();

                
               
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
               

              if(dt==null){ MessageBox.Show("මෙම ගිනුම් අංකයට සහ දිනයන්ට අදාලව පෙන්විමට වාර්තා නොමැත "); }
               ////total prevmonth areas

               
               

            }

          catch (Exception E) { MessageBox.Show(E.ToString(),"වාර්තා  නොමැත "); }






        }









        private String advanceM()
        {
            String advance=null;
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            OleDbCommand cmdadvance = con.CreateCommand();
            cmdadvance.CommandType = CommandType.Text;
            cmdadvance.CommandText = "SELECT SUM(advance) as totaladvance FROM rawdata WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";

            OleDbDataReader dradvance = cmdadvance.ExecuteReader();
      
            if (dradvance.HasRows==true)
            {
               
                dradvance.Read();
                String ab = dradvance["totaladvance"].ToString();
                return ab;
                dradvance.Close();
                
                //ttladvancesw2.Text = totaladvance.ToString();
            }


            else if (!dradvance.HasRows)
            {
               advance = "0";
                return advance;
               // ttladvancesw2.Text = "0";
            }


            return advance;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            summary();
            String a = fnamesw2.Text;
            int x = 0;
            DialogResult result = MessageBox.Show(a+"ගේ ශේෂය ඉදිරි මසට ගෙනයාමට අවශ්‍යද ?", "ශේෂය ගෙන යාම ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con1.Open();
                OleDbCommand cmdcheck = con1.CreateCommand();
                OleDbCommand cmdcheckf2 = con1.CreateCommand();
                cmdcheck.CommandType = CommandType.Text;
                cmdcheck.CommandText = "SELECT fname FROM prevmonth WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
               cmdcheckf2.CommandText = "SELECT fname FROM prevmonthf2 WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                OleDbDataReader drcheck = cmdcheck.ExecuteReader();
               OleDbDataReader drf2 = cmdcheckf2.ExecuteReader();


               drcheck.Read();
               drf2.Read();
                
                if (drf2.HasRows || drcheck.HasRows) {
                  
                  //  String checkvalue = drcheck["fname"].ToString();
                    MessageBox.Show("ඉටු කල නොහැක ,මේම කාල සීමාව තුල අදාළ ගිනුමේ ශේෂයයන් ඉදිරියට ගෙන ගොස් ඇත ");
                    
                
                }
               

                
             
                else
                try
                {
                    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                    con.Open();
                    OleDbCommand cmdfvalue2 = con.CreateCommand();
                    cmdfvalue2.CommandType = CommandType.Text;
                    cmdfvalue2.CommandText = "SELECT SUM(f1value) as totalfvalue2 FROM rawdata WHERE cusid =" + textBox1.Text + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                    OleDbDataReader drfvalue2 = cmdfvalue2.ExecuteReader();
                    drfvalue2.Read();


                    float totalfvalue2 = Convert.ToSingle(drfvalue2["totalfvalue2"].ToString());
                    ttlf1sw2.Text = totalfvalue2.ToString();
                    string datetime2 = dateTimePicker2.Value.ToShortDateString();
                    drfvalue2.Close();
                    string code = "ss";
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into prevmonthf2(f2,date_,cusid,fname)Values(" + totalfvalue2 + ",#" + datetime2 + "#," + textBox1.Text + ",'" +code+ "')";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(fnamesw2.Text + "ගේ පොහොර වාරිකය ඊලග මාසය සදහා සාර්ථකව ඇතුලත් කරන ලදි .", "පොහොර වාරිකය");
                                      

                    double netb = double.Parse(netbalancesw2.Text);
                    if (netb < 0)
                    {
                        string ss = "s";
                        OleDbCommand cmdprev = con.CreateCommand();
                        cmdprev.CommandText = "Insert into prevmonth(prevareas,date_,cusid,fname)Values(" + netb + ",#" + dateTimePicker1.Value.ToString() + "#," + textBox1.Text + ",'"+ss+"')";
                        cmdprev.Connection = con;
                        cmdprev.ExecuteNonQuery();
                        MessageBox.Show(fnamesw2.Text+"ගේ සියලු හිග මුදල් ඉදිරියට ගෙන ගියා .", "හිග මුදල් ");

                    }

                    con.Close();







                }
                catch (Exception E) { MessageBox.Show(E.ToString()); }
                drcheck.Close();
                drf2.Close();
            }

            else if (result == DialogResult.No) {

                MessageBox.Show("ශේෂය ඉදිරියට ගෙන යාම අවලංගු කරන ලදි ");
            
            }
        }
        //get summury for month
        private void summary()
        {

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
            con.Open();
            OleDbCommand cmdsummary = con.CreateCommand();
            cmdsummary.CommandType = CommandType.Text;
            cmdsummary.CommandText = "insert into sumary(tleaves,tpacket,advance,f1,f2,month_,cusid,netbalance,increses,date_,year_,tleavesvalue,transport) Values(" + ttltleavesw2.Text + "," + ttltpcktvaluesw2.Text + "," + ttladvancesw2.Text + "," + ttlf1sw2.Text + "," + ttlf1sw2.Text + ",'" + label4.Text + "'," + textBox1.Text + "," + netbalancesw2.Text + "," + ttlincreasessw2.Text + ",#" + dateTimePicker2.Value.ToShortDateString() + "#,"+showyear.Text+","+ttltleavevalue.Text+","+ttltransportsw2.Text+")";
            cmdsummary.ExecuteNonQuery();



            con.Close();
            
           





        }



        /*public void autosave() {
            int id=1;
            while (id < 50)
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con.Open();
                OleDbCommand cmdfvalue2 = con.CreateCommand();
                cmdfvalue2.CommandType = CommandType.Text;
                cmdfvalue2.CommandText = "SELECT SUM(f1value) as totalfvalue2 FROM rawdata WHERE cusid =" + id + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                OleDbDataReader drfvalue2 = cmdfvalue2.ExecuteReader();
                drfvalue2.Read();


                float totalfvalue2 = Convert.ToSingle(drfvalue2["totalfvalue2"].ToString());
                ttlf1sw2.Text = totalfvalue2.ToString();
                string datetime2 = dateTimePicker2.Value.ToShortDateString();
                drfvalue2.Close();
                OleDbCommand cmdinsert = con.CreateCommand();
                cmdinsert.CommandType = CommandType.Text;
                cmdinsert.CommandText = "Insert into prevmonthf2(cusid,f2)Values('" + id + "'," + totalfvalue2 + ")";

                id = id + 1;
            }
        
        
        }

        */
        private void datacalculate_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h2 = new Home();
            h2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int id = 1;
            while (id < 3)
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");
                con.Open();
                OleDbCommand cmdfvalue2 = con.CreateCommand();
                cmdfvalue2.CommandType = CommandType.Text;
                cmdfvalue2.CommandText = "SELECT SUM(f1value) as totalfvalue2 FROM rawdata WHERE cusid =" + id + " AND date_ BETWEEN #" + dateTimePicker1.Value.ToShortDateString() + "# AND #" + dateTimePicker2.Value.ToShortDateString() + "#";
                OleDbDataReader drfvalue2 = cmdfvalue2.ExecuteReader();
                drfvalue2.Read();


                float totalfvalue2 = Convert.ToSingle(drfvalue2["totalfvalue2"].ToString());
                //ttlf1sw2.Text = totalfvalue2.ToString();
                string datetime2 = dateTimePicker2.Value.ToShortDateString();
                drfvalue2.Close();
                OleDbCommand cmdinsert = con.CreateCommand();
                cmdinsert.CommandType = CommandType.Text;
                cmdinsert.CommandText = "Insert into prevmonthf2(cusid,f2)Values('" + id + "'," + totalfvalue2 + ")";

                id = id + 1;
            }






        }

        private void button5_Click(object sender, EventArgs e)
        {
            summary s = new summary();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

           
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb"); 
                OleDbCommand delcmd = new OleDbCommand();
                if (dataGridView1.Rows.Count > 1 && i != dataGridView1.Rows.Count - 1)
                {
                      delcmd.CommandText = "DELETE FROM rawdata WHERE ID=" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "";
                      con.Open();
                      delcmd.Connection = con;
                      delcmd.ExecuteNonQuery();
                      con.Close();
                      dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Index);
                      MessageBox.Show("Row Deleted");
                }

}
            
            
            
               
                

                
            
            
            
            





        }

     
    }

