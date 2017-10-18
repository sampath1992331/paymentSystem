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
    public partial class summary : Form
    {
        public summary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

            con.Open();
       

            OleDbCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT fname, contactnumber FROM userdetails where userid=" + textBox1.Text + "  ";
            OleDbDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                String a = dr["fname"].ToString();
                String b = dr["contactnumber"].ToString();

                name.Text = a;
                //contactsw2.Text = b;
                String comboboxvalue = comboBox1.Text;
                OleDbCommand cmdsum = con.CreateCommand();
                cmdsum.CommandType = CommandType.Text;
                cmdsum.CommandText = "SELECT tleaves, tpacket,advance,other,f1,f2,netbalance,increses,transport,tleavesvalue FROM sumary where cusid=" + textBox1.Text + " AND month_='"+comboboxvalue+"'";
                OleDbDataReader drsum = cmdsum.ExecuteReader();
                drsum.Read();
                if (drsum.HasRows)
                {
                    String tleaves = drsum["tleaves"].ToString();
                    String tpacket = drsum["tpacket"].ToString();
                    String advance = drsum["advance"].ToString();
                    String other = drsum["other"].ToString();
                    String f1 = drsum["f1"].ToString();
                    String f2 = drsum["f2"].ToString();
                    String netbalance = drsum["netbalance"].ToString();
                    String increses = drsum["increses"].ToString();
                    String transport = drsum["transport"].ToString();
                    String tleavesvalue = drsum["tleavesvalue"].ToString();


                    ttladvancesw2.Text = advance;
                    ttlothersw2.Text = other;
                    ttltpcktvaluesw2.Text = tpacket;
                    ttltleavesw2.Text = tleaves;
                    ttlf1sw2.Text = f1;
                    netbalancesw2.Text = netbalance;
                    prevfertilizersw2.Text = f2;
                    ttlincreasessw2.Text = increses;
                    ttltransportsw2.Text = transport;
                    ttltleavevalue.Text = tleavesvalue;
                    drsum.Close();
                }
                else {
                    MessageBox.Show("පෙන්වීමට වාර්තා නොමැත ");
                    ttladvancesw2.Text = "0";
                    ttlothersw2.Text = "0";
                    ttltpcktvaluesw2.Text = "0";
                    ttltleavesw2.Text = "0";
                    ttlf1sw2.Text = "0";
                    netbalancesw2.Text = "0";
                    prevfertilizersw2.Text = "0";
                    ttlincreasessw2.Text = "0";
                    ttltransportsw2.Text = "0";
                    ttltleavevalue.Text = "0";
                }


            }
            else
            {
                String m = textBox1.Text;
                MessageBox.Show(m + " " + "යන අංකය යටතේ ගිනුමක් නොමැත ,නැවත පරික්ශා කරන්න ");
                ttladvancesw2.Text = "0";
                ttlothersw2.Text = "0";
                ttltpcktvaluesw2.Text = "0";
                ttltleavesw2.Text = "0";
                ttlf1sw2.Text = "0";
                netbalancesw2.Text = "0";
                prevfertilizersw2.Text = "0";
                ttlincreasessw2.Text = "0";
                ttltransportsw2.Text = "0";
                ttltleavevalue.Text = "0";
            }



            dr.Close();
















        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            int cid = Convert.ToInt16(id);
            int newid = cid + 1;

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Database\teadb.accdb");

            con.Open();

            textBox1.Text = newid.ToString();
            OleDbCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT fname, contactnumber FROM userdetails where userid=" + newid+ "  ";
            OleDbDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
               // try
               // {
                    String a = dr["fname"].ToString();
                    String b = dr["contactnumber"].ToString();

                    name.Text = a;
                    //contactsw2.Text = b;
                    String comboboxvalue = comboBox1.Text;
                    OleDbCommand cmdsum = con.CreateCommand();
                    cmdsum.CommandType = CommandType.Text;
                    cmdsum.CommandText = "SELECT tleaves, tpacket,advance,other,f1,f2,netbalance,increses,transport,tleavesvalue FROM sumary where cusid=" + textBox1.Text + " AND month_='" + comboboxvalue + "'";
                    OleDbDataReader drsum = cmdsum.ExecuteReader();
                    drsum.Read();
                    if (drsum.HasRows)
                    {
                        String tleaves = drsum["tleaves"].ToString();
                        String tpacket = drsum["tpacket"].ToString();
                        String advance = drsum["advance"].ToString();
                        String other = drsum["other"].ToString();
                        String f1 = drsum["f1"].ToString();
                        String f2 = drsum["f2"].ToString();
                        String netbalance = drsum["netbalance"].ToString();
                        String increses = drsum["increses"].ToString();
                        String transport = drsum["transport"].ToString();
                        String tleavesvalue = drsum["tleavesvalue"].ToString();


                        ttladvancesw2.Text = advance;
                        ttlothersw2.Text = other;
                        ttltpcktvaluesw2.Text = tpacket;
                        ttltleavesw2.Text = tleaves;
                        ttlf1sw2.Text = f1;
                        netbalancesw2.Text = netbalance;
                        prevfertilizersw2.Text = f2;
                        ttlincreasessw2.Text = increses;
                        ttltransportsw2.Text = transport;
                        ttltleavevalue.Text = tleavesvalue;
                        drsum.Close();
                    }
                    else {

                        ttladvancesw2.Text = "0";
                        ttlothersw2.Text = "0";
                        ttltpcktvaluesw2.Text = "0";
                        ttltleavesw2.Text = "0";
                        ttlf1sw2.Text = "0";
                        netbalancesw2.Text = "0";
                        prevfertilizersw2.Text = "0";
                        ttlincreasessw2.Text = "0";
                        ttltransportsw2.Text = "0";
                        ttltleavevalue.Text = "0";

                        MessageBox.Show("වාර්තා කිසිවක් නැත ");
                    }
                //}//try ending bracket

              //  catch (Exception E) { E.ToString(); }



            }
            else
            {
                String m = textBox1.Text;
                MessageBox.Show(m + " " + "යන අංකය යටතේ ගිනුමක් නොමැත ,නැවත පරික්ශා කරන්න ");
            }



            dr.Close();



        }
    }
}
