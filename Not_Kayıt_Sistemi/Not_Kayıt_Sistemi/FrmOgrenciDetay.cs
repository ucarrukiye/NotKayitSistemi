using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayıt_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        //Data Source=LAPTOP-TRU5HUGN;Initial Catalog=DbNotKayıt;Integrated Security=True//

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-TRU5HUGN;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERS where OGRNUMARA=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblSınav1.Text = dr[4].ToString();
                LblSınav2.Text = dr[5].ToString();
                LblSınav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();
            }
            baglanti.Close();

            if (LblDurum.Text=="True")
            {
                LblDurum.Text = "GEÇTİ";
            }
            else
            {
                LblDurum.Text = "KALDI";
            }
        }
    }
}
