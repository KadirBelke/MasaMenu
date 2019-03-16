using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MasaMenü
{
    public partial class frmRaporlama : Form
    {
        public frmRaporlama()
        {
            InitializeComponent();
        }
        private void getir()
        {
            string gun = dateTimePicker1.Value.ToString("dd");
            string ay = dateTimePicker1.Value.ToString("MM");
            string yil = dateTimePicker1.Value.ToString("yyyy");
            DateTime dt = DateTime.Now;
            string gun1 = dt.Day+"";
            string ay1 = dt.Month + "";
            string yil1 = dt.Year + "";

            lvHesap.Items.Clear();
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmdgetir = new MySqlCommand("select * from hesap where gun=" + gun + " and ay=" + ay + " and yil=" + yil, con);
            con.Open();
            MySqlDataReader dr = cmdgetir.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Total"].ToString());
                string saat = dr["saat"].ToString();
                string dakika = dr["dakika"].ToString();
                string saniye = dr["saniye"].ToString();
                item.SubItems.Add(saat + ":" + dakika + ":" + saniye);
                lvHesap.Items.Add(item);
            }
            con.Close();
            MySqlCommand cmdgun1 = new MySqlCommand("select sum(Total) from hesap where gun=" + gun1 + " and ay=" + ay1 + " and yil=" + yil1, con);
            con.Open();
            lblGK.Text = cmdgun1.ExecuteScalar().ToString();
            con.Close();
            MySqlCommand cmday1 = new MySqlCommand("select sum(Total) from hesap where ay=" + ay1 + " and yil=" + yil1, con);
            con.Open();
            lblAK.Text = cmday1.ExecuteScalar().ToString();
            con.Close();
            MySqlCommand cmdyil1 = new MySqlCommand("select sum(Total) from hesap where yil=" + yil1, con);
            con.Open();
            lblYK.Text = cmdyil1.ExecuteScalar().ToString();
            con.Close();

            MySqlCommand cmdsgun = new MySqlCommand("select sum(Total) from hesap where gun=" + gun + " and ay=" + ay + " and yil=" + yil, con);
            con.Open();
            lblSGK.Text = cmdsgun.ExecuteScalar().ToString();
            con.Close();
            MySqlCommand cmdsay = new MySqlCommand("select sum(Total) from hesap where ay=" + ay + " and yil=" + yil, con);
            con.Open();
            lblSAK.Text = cmdsay.ExecuteScalar().ToString();
            con.Close();
            MySqlCommand cmdsyil = new MySqlCommand("select sum(Total) from hesap where yil=" + yil, con);
            con.Open();
            lblSYK.Text = cmdsyil.ExecuteScalar().ToString();
            con.Close();
           


        }

        private void frmRaporlama_Load(object sender, EventArgs e)
        {
            getir();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getir();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmLobi frm = new frmLobi();
            this.Close();
            frm.Show();
        }
    }
}
