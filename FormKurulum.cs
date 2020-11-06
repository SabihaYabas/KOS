using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormKurulum : Form
    {
        public FormKurulum()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

       

        private void FormKurulum_Load(object sender, EventArgs e)
        {

        }
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text) || 
                string.IsNullOrEmpty(txtSoyad.Text) || 
                string.IsNullOrEmpty(txtKullaniciAdi.Text) || 
                string.IsNullOrEmpty(txtSifre.Text) ||
                string.IsNullOrEmpty(txtSifreTekrar.Text))
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!");
                return;
            }
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifre Tekrarları Uyuşmuyor!");
                return;
            }



            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@adi", SqlDbType.VarChar) { Value = txtAd.Text });
            parameters.Add(new SqlParameter("@soyadi", SqlDbType.VarChar) { Value = txtSoyad.Text });
            parameters.Add(new SqlParameter("@kullaniciAdi", SqlDbType.VarChar) { Value = txtKullaniciAdi.Text });
            parameters.Add(new SqlParameter("@sifre", SqlDbType.VarChar) { Value = txtSifre.Text });
            IDataBase.ExecuteNonQuery("insert into kullanicilar (adi,soyadi,kullaniciAdi,sifre) values (@adi,@soyadi,@kullaniciAdi,@sifre)", parameters);


            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();



        }   
    }
}
