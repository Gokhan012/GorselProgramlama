using System;
using System.Windows.Forms;
using GorselProgramlama.Business;
using GorselProgramlama.Repositoty;

namespace GorselProgramlama.UI
{
    public partial class ParkingLotFinderPage : Form
    {
        ParkingRepository _repo;

        public ParkingLotFinderPage()
        {
            InitializeComponent();
            _repo = new ParkingRepository();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            string girilenPlaka = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(girilenPlaka))
            {
                MessageBox.Show("Lütfen plaka giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (girilenPlaka.ToUpper() != AuthService.CurrentUserPlate.ToUpper())
            {
                MessageBox.Show("HATA: Sadece kendi aracınızı sorgulayabilirsiniz!",
                                "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string sonuc = _repo.PlakadanKonumBul(girilenPlaka);

            if (!string.IsNullOrEmpty(sonuc) && !sonuc.StartsWith("Hata"))
            {
                MessageBox.Show(sonuc, "Araç Bulundu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (sonuc.StartsWith("Hata"))
            {
                MessageBox.Show(sonuc, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Otoparkta aracınız görünmüyor.", "Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}