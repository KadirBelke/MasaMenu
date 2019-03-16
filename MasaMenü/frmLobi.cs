using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasaMenü
{
    public partial class frmLobi : Form
    {
        public frmLobi()
        {
            InitializeComponent();
        }

        private void btnMasalar_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        
        }

        private void frmLobi_Load(object sender, EventArgs e)
        {

        }

        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            frmRaporlama frm = new frmRaporlama();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            frmGiris frm = new frmGiris();
            this.Close();
            frm.Show();
        }

        private void btnUrunAyarlari_Click(object sender, EventArgs e)
        {
            frmUrunAyarlari frm = new frmUrunAyarlari();
            this.Close();
            frm.Show();
        }

        private void btnKullaniciAyarlari_Click(object sender, EventArgs e)
        {

        }
    }
}
