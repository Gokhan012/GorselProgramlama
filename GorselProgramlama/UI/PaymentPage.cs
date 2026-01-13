using System;
using System.Windows.Forms;
using GorselProgramlama.Repositoty;

namespace GorselProgramlama.UI
{
    public partial class PaymentPage : Form
    {
        private int _userId;
        private int _katNo;
        private int _parkNo;
        private decimal _hesaplananUcret;
        private ParkingRepository _repo;

        public PaymentPage(int userId, int katNo, int parkNo)
        {
            InitializeComponent();
            _userId = userId;
            _katNo = katNo;
            _parkNo = parkNo;
            _repo = new ParkingRepository();
            Hesapla();
        }

        private void Hesapla()
        {
            try
            {
                DateTime girisSaati = _repo.GetGirisSaati(_userId, _katNo, _parkNo);

                if (girisSaati == DateTime.MinValue)
                {
                    MessageBox.Show("Giriş saati veritabanından okunamadı!");
                    return;
                }

                DateTime cikisSaati = DateTime.Now;
                TimeSpan sure = cikisSaati - girisSaati;
                double toplamSaat = Math.Ceiling(sure.TotalHours);

                if (toplamSaat < 1) toplamSaat = 1;

                decimal saatlikUcret = 20;
                _hesaplananUcret = (decimal)toplamSaat * saatlikUcret;

                label1.Text = $"Giriş: {girisSaati.ToShortTimeString()}\nÇıkış: {cikisSaati.ToShortTimeString()}\nSüre: {toplamSaat} Saat";
                label2.Text = $"{_hesaplananUcret} TL";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama hatası: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _repo.AracCikisYap(_userId, _katNo, _parkNo);
                MessageBox.Show("Ödeme alındı. Çıkış yapabilirsiniz. İyi günler!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme Hatası: " + ex.Message);
            }
        }
    }
}