using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace kalkan_hotel
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NE4GIVP\\SQLEXPRESS;Initial Catalog=kalkanhotel;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "select * from AdminGiris where Kullanici = @KullaniciAdi AND Sifre = @Sifresi";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@Sifresi", TxtSifre.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }

            baglanti.Close();

        }

    }
}
