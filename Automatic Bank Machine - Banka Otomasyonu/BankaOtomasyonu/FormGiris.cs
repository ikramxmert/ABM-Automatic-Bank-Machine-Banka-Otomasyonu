using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace BankaOtomasyonu
{
    partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();       
        }
        public FormGiris(Banka banka)
        {
            InitializeComponent();
            this.banka = banka;
        }

        Banka banka;
    
        private void simpleButton3_Click(object sender, EventArgs e) //Yönetici girişi tıklanma olayı
        {   
            FormAna f1 = Application.OpenForms["FormAna"] as FormAna;
            Panel panel1 = f1.Controls["panel1"] as Panel;
            panel1.Controls.Clear();

            FormYonetici formYonetici = new FormYonetici(banka);
            formYonetici.TopLevel = false;
            panel1.Controls.Add(formYonetici);
            formYonetici.Show();
            formYonetici.Dock = DockStyle.Fill;
        }

        private void simpleButton2_Click(object sender, EventArgs e) //Personel Girişi tıklanma olayı
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            foreach (Personel p in banka.personeller)
            {
                if(kullaniciAdi == p.ID && sifre == p.Sifre)
                {
                    FormAna f1 = Application.OpenForms["FormAna"] as FormAna;
                    Panel panel1 = f1.Controls["panel1"] as Panel;
                    panel1.Controls.Clear();

                    FormPersonel formPersonel = new FormPersonel(banka);
                    formPersonel.TopLevel = false;
                    panel1.Controls.Add(formPersonel);
                    formPersonel.Show();
                    formPersonel.Dock = DockStyle.Fill;
                    MessageBox.Show("Hoşgeldiniz. Sayın "+p.Ad+" "+p.Soyad);
                }
                /*else
                {
                    //MessageBox.Show("**Kullanıcı Adı veya Şifre Hatalı...!***","Hatalı...!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }*/
            }
            
        }

        private void btnMusteriGiris_Click(object sender, EventArgs e) //Müşteri Girişi tıklanma olayı
        {
            string musteriNo = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            foreach (BireyselMusteri m in banka.BireyselMusteriler)
            {   
                if(musteriNo == m.ID && sifre == m.Sifre)
                {
                    FormAna f1 = Application.OpenForms["FormAna"] as FormAna;
                    Panel panel1 = f1.Controls["panel1"] as Panel;
                    panel1.Controls.Clear();
                    FormMusteri formMusteri = new FormMusteri(banka, m);
                    formMusteri.TopLevel = false;
                    panel1.Controls.Add(formMusteri);
                    formMusteri.Show();
                    formMusteri.Dock = DockStyle.Fill;

                    MessageBox.Show("Hoşgeldiniz Sayın "+m.Ad+" "+m.Soyad);
                }
            }
            foreach (TicariMusteri m in banka.TicariMusteriler)
            {
                if (musteriNo == m.ID && sifre == m.Sifre)
                {
                    FormAna f1 = Application.OpenForms["FormAna"] as FormAna;
                    Panel panel1 = f1.Controls["panel1"] as Panel;
                    panel1.Controls.Clear();
                    FormMusteri formMusteri = new FormMusteri(banka, m);
                    formMusteri.TopLevel = false;
                    panel1.Controls.Add(formMusteri);
                    formMusteri.Show();
                    formMusteri.Dock = DockStyle.Fill;

                    MessageBox.Show("Hoşgeldiniz Sayın " + m.Ad + " " + m.Soyad);
                }
            }

        }

        private void FormGiris_Load(object sender, EventArgs e)
        {
            
            txtSifre.UseSystemPasswordChar = true;
            textBox1.Text = "Müşteri Numarasınız Giriniz";

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = MessageBox.Show("Çıkmak İstediğinize Eminmisiniz...?", "Soru!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hakkında frmHakkında = new Hakkında();
            frmHakkında.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            QRCodeEncoder enc = new QRCodeEncoder();
            string site1 = "https://www.instagram.com/ikram_mert/";
            pictureBox1.Image = enc.Encode(site1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QRCodeEncoder enc = new QRCodeEncoder();
            string site2 = "https://www.linkedin.com/in/ikram-mert/";
            pictureBox1.Image = enc.Encode(site2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //QRCodeEncoder enc = new QRCodeEncoder();      //yazıldığı gibi QR oluşturuyor
            // string yazi = textBox1.Text;
            //pictureBox1.Image = enc.Encode(yazi);
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            QRCodeEncoder enc = new QRCodeEncoder();
            string yazi = textBox1.Text;
            pictureBox1.Image = enc.Encode(yazi);
        }
    }
}
