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
using System.IO.Ports;
using System.Threading;

namespace MasaMenü
{
    public partial class frmSiparis : Form
    {
        
        public frmSiparis()
        {
            InitializeComponent();
        }
        public delegate void DelegateStandardPattern();
        private void SetTextStandardPattern()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateStandardPattern(SetTextStandardPattern));
                return;
            }
        }
        private void tutar()
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            cTable masa = new cTable();
            MySqlCommand cmd = new MySqlCommand("select SUM(u.fiyati) from urunler u, siparis s where s.masa_id=" + cBilgilendirme._buttonId + " and u.id=s.urun_id ", con);
            con.Open();
            label2.Text = cmd.ExecuteScalar() + "₺";
            double total = 0;
            for (int i = 0; i < lvSiparis.Items.Count; i++)
            {
                if (lvSiparis.Items[i].Checked)
                {
                    total += Convert.ToDouble((lvSiparis.Items[i].SubItems[2].Text).Replace(".", ","));
                }
            }
            label4.Text = total + "₺";
        }
        private void grid()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateStandardPattern(grid));
            }
            else
            {
                tutar();
                label2.Text = "0₺";
                lblMasa.Text = cBilgilendirme._buttonText;
                cBaglanti bgl = new cBaglanti();
                MySqlConnection connet = new MySqlConnection(bgl.baglanti);
                MySqlCommand kmt = new MySqlCommand("select * from kategori", connet);
                List<cKategori> ktgr = new List<cKategori>();
                connet.Open();
                MySqlDataReader drKategori = kmt.ExecuteReader();
                while (drKategori.Read())
                {
                    cKategori kt = new cKategori();
                    kt.Id = Convert.ToInt32(drKategori["Id"]);
                    kt.adi = drKategori["adi"].ToString();

                    ktgr.Add(kt);
                }
                cmbKatagori.DataSource = ktgr;
                cmbKatagori.DisplayMember = "adi";
                connet.Close();
                MySqlCommand cmd = new MySqlCommand("select u.id,u.adi,u.fiyati from urunler u, siparis s where s.masa_id=" +cBilgilendirme._buttonId + " and u.id=s.urun_id ", connet);
                connet.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["id"].ToString());
                    item.SubItems.Add(dr["adi"].ToString());
                    item.SubItems.Add(dr["fiyati"].ToString());
                    lvSiparis.Items.Add(item);
                }
                tutar();

            }
        }

        private void frmSiparis_Load(object sender, EventArgs e)
        {
            grid();
        }

        private void cmbKatagori_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvUrunler.Items.Clear();
            cBaglanti bgl = new cBaglanti();
            MySqlConnection connet = new MySqlConnection(bgl.baglanti);
            MySqlCommand kmt = new MySqlCommand("select * from urunler where kId=" + (cmbKatagori.SelectedItem as cKategori).Id + "",connet);
            List<cUrunler> urn = new List<cUrunler>();
            connet.Open();
            MySqlDataReader drUrunler = kmt.ExecuteReader(); 
            while (drUrunler.Read())
            {
                ListViewItem item = new ListViewItem(drUrunler["id"].ToString());
                item.SubItems.Add(drUrunler["adi"].ToString());
                item.SubItems.Add(drUrunler["fiyati"].ToString());

                lvUrunler.Items.Add(item);

                cUrunler urun = new cUrunler();
                urun.Id = Convert.ToInt32(drUrunler["id"]);
                urun.kId = Convert.ToInt32(drUrunler["kId"]);
                urun.Adi = drUrunler["adi"].ToString();
                urun.fiyat = Convert.ToSingle(drUrunler["fiyati"]);

                urn.Add(urun);
            }
            
        }

        private void lvUrunler_MouseClick(object sender, MouseEventArgs e)
        {
            txtUrun.Text = lvUrunler.SelectedItems[0].SubItems[1].Text;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            //cBilgilendirme tab = new cBilgilendirme();
            cUrunler urun = new cUrunler();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            con.Open();
            for (int i = 0; i <Convert.ToInt32(ndAdet.Value); i++)
            {
                string no = lvUrunler.SelectedItems[0].SubItems[0].Text;
                string adi = lvUrunler.SelectedItems[0].SubItems[1].Text;
                string fiyati = lvUrunler.SelectedItems[0].SubItems[2].Text;

                MySqlCommand kmt = new MySqlCommand("insert into siparis(masa_id,urun_id) values(" +cBilgilendirme._buttonId+","+no+")", con);
                kmt.ExecuteNonQuery();

                string[] row = { no, adi, fiyati };
                ListViewItem item = new ListViewItem(row);
                lvSiparis.Items.Add(item);
            }
            txtUrun.Text = "";
            ndAdet.Value = 1;
            tutar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lvSiparis.Items.Clear();
            grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        }

        private void lvSiparis_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            tutar();
        }
        private void hTarih(float Ttl)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection baglanti = new MySqlConnection(bgl.baglanti);

            DateTime tarh = DateTime.Now;
            int gun = tarh.Day;
            int ay = tarh.Month;
            int yil = tarh.Year;
            int saat = tarh.Hour;
            int dakika = tarh.Minute;
            int saniye = tarh.Second;

            MySqlCommand kmtIns = new MySqlCommand("ınsert into hesap(Total,gun,ay,yil,saat,dakika,saniye) values(@ttl," + gun + "," + ay + "," + yil + ","+saat+","+dakika+","+saniye+")", baglanti);
            kmtIns.Parameters.Add("@ttl", MySqlDbType.Float);
            kmtIns.Parameters["@ttl"].Value = Ttl;
            baglanti.Open();
            kmtIns.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection baglanti = new MySqlConnection(bgl.baglanti);
            MySqlCommand kmtTtl = new MySqlCommand("select sum(u.fiyati) from urunler u, siparis s where s.masa_id=" + cBilgilendirme._buttonId + " and u.id=s.urun_id", baglanti);
            baglanti.Open();
            float Ttl = Convert.ToSingle(kmtTtl.ExecuteScalar());
            baglanti.Close();

            hTarih(Ttl);

            MySqlCommand kmtdel = new MySqlCommand("delete from siparis where masa_id=" + cBilgilendirme._buttonId, baglanti);
            baglanti.Open();
            kmtdel.ExecuteNonQuery();
            baglanti.Close();

            lvSiparis.Items.Clear();
            grid();

        }

        private void btnSHesap_Click(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            float Ttl = 0;
            for (int i = 0; i < lvSiparis.Items.Count; i++) {
                if (lvSiparis.Items[i].Checked)
                {
                    MySqlCommand cmdTtl = new MySqlCommand("select u.fiyati from urunler u, siparis s where s.masa_id=" + cBilgilendirme._buttonId + " and u.id=s.urun_id and u.id=" + lvSiparis.Items[i].SubItems[0].Text, con);
                    con.Open();
                    Ttl += Convert.ToSingle((cmdTtl.ExecuteScalar().ToString()).Replace('.',','));
                    con.Close();

                    MySqlCommand cmdDelete = new MySqlCommand("delete  from siparis where masa_id=" + cBilgilendirme._buttonId + " and urun_id=" + lvSiparis.Items[i].SubItems[0].Text + " order by urun_id limit 1 ", con);
                    con.Open();
                    cmdDelete.ExecuteNonQuery();
                    con.Close();
                }
            }
            hTarih(Ttl);
            lvSiparis.Items.Clear();
            grid();
        }
    }
}
