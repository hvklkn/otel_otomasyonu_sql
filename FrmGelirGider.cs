using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace kalkan_hotel
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NE4GIVP\\SQLEXPRESS;Initial Catalog=kalkanhotel;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int personel1;
            if (int.TryParse(textBox1.Text, out personel1))
            {
                LblPersonelMaas.Text = (personel1 * 1500).ToString();
            }
            else
            {
                // Kullanıcıdan geçerli bir sayısal giriş alınamadı
                // Hata durumunu kullanıcıya bildirme veya varsayılan değeri atama gibi bir işlem yapabilirsiniz.
                // Örneğin:
                // LblPersonelMaas.Text = "Geçerli bir sayı giriniz";
            }
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            //kasadaki toplam tutar
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(Ucret) as toplam from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblKasaToplam.Text = oku["toplam"].ToString();
            }
            baglanti.Close();


            //gıdalar

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select sum(Gida) as toplam1 from Stoklar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                LblAlinanUrunler1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();

            //icecekler

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select sum(Gida) as toplam2 from Stoklar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                LblAlinanUrunler2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();


            //atistirmaliklar

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select sum(Atistirmaliklar) as toplam3 from Stoklar", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                LblAlinanUrunler3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();

            int personel1;
            if (int.TryParse(textBox1.Text, out personel1))
            {
                LblPersonelMaas.Text = (personel1 * 1500).ToString();
            }
            else
            {
                // Kullanıcıdan geçerli bir sayısal giriş alınamadı
                // Hata durumunu kullanıcıya bildirme veya varsayılan değeri atama gibi bir işlem yapabilirsiniz.
                // Örneğin:
                // LblPersonelMaas.Text = "Geçerli bir sayı giriniz";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblPersonelMaas_Click(object sender, EventArgs e)
        {
           
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
