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
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
        }

        private void frmMasalar_Load(object sender, EventArgs e)
        {
            cBaglanti bgl = new cBaglanti();
            Button[] btn = { btnMasa1, btnMasa2, btnMasa3, btnMasa4, btnMasa5, btnMasa6, btnMasa7, btnMasa8, btnMasa9, btnMasa10, btnMasa11, btnMasa12, btnMasa13, btnMasa14, btnMasa15 };
            MySqlConnection con = new MySqlConnection(bgl.baglanti);
            
            for (int i = 0; i < 15; i++)
            {
                MySqlCommand cmd = new MySqlCommand("select * from siparis where masa_id=" + i + "", con);
                con.Open();
                MySqlDataReader drCmd = cmd.ExecuteReader();
                if (drCmd.Read())
                {
                    btn[i].BackColor = Color.Green;
                }
                else
                {
                    btn[i].BackColor = Color.Red;
                }
                con.Close();
            }
            
            MySqlCommand cmdm = new MySqlCommand("select * from masalar", con);
            con.Open();
            MySqlDataReader dr = cmdm.ExecuteReader();
            List<cTable> tbl = new List<cTable>();
            while (dr.Read())
            {
                cTable masa = new cTable();
                masa.Id = Convert.ToInt32(dr["id"]);
                masa.Adi = dr["adi"].ToString();

                tbl.Add(masa);
            }

        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa1.Name;
            cBilgilendirme._buttonText = btnMasa1.Text;
            cBilgilendirme._buttonId = 0;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa15_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa15.Name;
            cBilgilendirme._buttonText = btnMasa15.Text;
            cBilgilendirme._buttonId = 14;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa14_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa14.Name;
            cBilgilendirme._buttonText = btnMasa14.Text;
            cBilgilendirme._buttonId = 13;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa13_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa13.Name;
            cBilgilendirme._buttonText = btnMasa13.Text;
            cBilgilendirme._buttonId = 12;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa12_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa12.Name;
            cBilgilendirme._buttonText = btnMasa12.Text;
            cBilgilendirme._buttonId = 11;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa11_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa11.Name;
            cBilgilendirme._buttonText = btnMasa11.Text;
            cBilgilendirme._buttonId = 10;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa10.Name;
            cBilgilendirme._buttonText = btnMasa10.Text;
            cBilgilendirme._buttonId = 9;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa9.Name;
            cBilgilendirme._buttonText = btnMasa9.Text;
            cBilgilendirme._buttonId = 8;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa8.Name;
            cBilgilendirme._buttonText = btnMasa8.Text;
            cBilgilendirme._buttonId = 7;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa7.Name;
            cBilgilendirme._buttonText = btnMasa7.Text;
            cBilgilendirme._buttonId = 6;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa6.Name;
            cBilgilendirme._buttonText = btnMasa6.Text;
            cBilgilendirme._buttonId = 5;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa5.Name;
            cBilgilendirme._buttonText = btnMasa5.Text;
            cBilgilendirme._buttonId = 4;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa4.Name;
            cBilgilendirme._buttonText = btnMasa4.Text;
            cBilgilendirme._buttonId = 3;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa3.Name;
            cBilgilendirme._buttonText = btnMasa3.Text;
            cBilgilendirme._buttonId = 2;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();

            cBilgilendirme._buttonName = btnMasa2.Name;
            cBilgilendirme._buttonText = btnMasa2.Text;
            cBilgilendirme._buttonId = 1;
            this.Close();
            frm.ShowDialog();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmLobi frm = new frmLobi();
            this.Close();
            frm.Show();

        }
    }
}
