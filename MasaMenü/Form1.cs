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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pass = txtPass.Text;

            cBaglanti con = new cBaglanti();
            MySqlConnection connect = new MySqlConnection(con.baglanti);
            MySqlCommand cmd = new MySqlCommand("select * from personel where pName='" + name + "' and pPass='" + pass+"'", connect);
            connect.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                frmLobi lobi = new frmLobi();
                lobi.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Ad veya Şifre!");
            }
        }
    }
}
