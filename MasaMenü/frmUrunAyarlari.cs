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
    public partial class frmUrunAyarlari : Form
    {
        public frmUrunAyarlari()
        {
            InitializeComponent();
        }

        private void lvKategori_MouseClick(object sender, MouseEventArgs e)
        {
            txtSil.Text = lvKategori.SelectedItems[0].SubItems[0].Text;
        }
        private void gridK()
        {
        ;
           
            txtSil.Text = "";
            lvKategori.Items.Clear();
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);

            MySqlCommand cmd1 = new MySqlCommand("select * from kategori", con);
            con.Open();
            MySqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cmb1.Items.Add(dr1["adi"]);
            }
            con.Close();
            MySqlCommand cmd = new MySqlCommand("select * from kategori", con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["adi"].ToString());
                lvKategori.Items.Add(item);
            }
            con.Close();
        }
       
        private string cozum(string a)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("select * from kategori where Id=" + a, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                a= dr["adi"].ToString();
            }
            con.Close();
            return a;

        }

        private void gridU()
        {
            lvUrunler.Items.Clear();
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand kmt = new MySqlCommand("select * from kategori", con);
            List<cKategori> ktgr = new List<cKategori>();
            con.Open();
            MySqlDataReader drKategori = kmt.ExecuteReader();
            while (drKategori.Read())
            {
                cKategori kt = new cKategori();
                kt.Id = Convert.ToInt32(drKategori["Id"]);
                kt.adi = drKategori["adi"].ToString();

                ktgr.Add(kt);
            }
            con.Close();

            
            MySqlCommand cmd = new MySqlCommand("select * from urunler", con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ListViewItem item = new ListViewItem(dr["id"].ToString());
                item.SubItems.Add(dr["adi"].ToString());
                item.SubItems.Add(dr["fiyati"].ToString());
                item.SubItems.Add(cozum(dr["kId"].ToString()));
                
                //int a = Convert.ToInt32(dr["kId"]);
                //con.Close();
                //MySqlCommand cmda = new MySqlCommand("select adi from kategori where Id=" + a, con);
                //con.Open();
                //MySqlDataReader dra = cmda.ExecuteReader();
                //con.Close();
                //string b = dra.ToString();
                //item.SubItems.Add(b);
                lvUrunler.Items.Add(item);
            }
            con.Close();
        }

        private void frmUrunAyarlari_Load(object sender, EventArgs e)
        {
            
            gridK();
            gridU();
            
        }

        private void btnGEkle_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("insert into kategori(adi) values('" + txtKategori.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            gridK();
        }

        private void btnKGuncelle_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("update kategori set adi='" + txtKategori.Text + "' where adi='" + txtSil.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            gridK();
        }

        private void btnGSil_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("delete from kategori where adi='" + txtSil.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            gridK();
        }
        //#############################################################################################################################
        private void lvUrunler_MouseClick(object sender, MouseEventArgs e)
        {
            txtAd2.Text = lvUrunler.SelectedItems[0].SubItems[1].Text;
            txtfiyat2.Text = lvUrunler.SelectedItems[0].SubItems[2].Text;
            txtKt.Text = lvUrunler.SelectedItems[0].SubItems[3].Text;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("select * from kategori where adi='" + cmb1.SelectedItem+"'", con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            string id="";
            while (dr.Read())
            {
                id = dr["id"].ToString();
            }
            con.Close();
            MySqlCommand cmd1 = new MySqlCommand("insert into urunler(kId,adi,fiyati) values('" + id + "','" + txtAd1.Text + "','" + txtfiyat1.Text + "')",con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            gridU();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("select id from kategori where adi='" + cmb1.SelectedItem+"'", con);
            con.Open();
            string id = cmd.ExecuteReader().ToString();
            con.Close();
            MySqlCommand cmd1 = new MySqlCommand("select id from kategori where adi='" + txtKt.Text+"'", con);
            con.Open();
            string id1 = cmd1.ExecuteReader().ToString();
            con.Close();
            MySqlCommand cmd2 = new MySqlCommand("update urunler set adi='" + txtAd1.Text + "' and fiyati='" + txtfiyat1.Text + "' and kId='" + id + "' where adi='" + txtAd2.Text + "' and fiyati='" + txtfiyat2.Text + "' and kId='" + id1+"'", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            gridU();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            MySqlCommand cmd = new MySqlCommand("select id from kategori where adi='" + cmb1.SelectedItem+"'", con);
            con.Open();
            string id = cmd.ExecuteReader().ToString();
            con.Close();
            MySqlCommand cmd1= new MySqlCommand("delete from urunler where adi='"+txtAd2.Text+"' and fiyati='"+txtfiyat2.Text+"' and kId='"+id+"'", con);
            con.Open();
            cmd1.ExecuteNonQuery();
            gridU();

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmLobi frm = new frmLobi();
            this.Close();
            frm.Show();
        }
    }
}
