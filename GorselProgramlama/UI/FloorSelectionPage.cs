using GorselProgramlama.Business;
using GorselProgramlama.Repositoty;
using System;
using System.Windows.Forms;

namespace GorselProgramlama.UI
{
    public partial class FloorSelectionPage : Form
    {
        AuthRepository authRepository = new AuthRepository();
        public FloorSelectionPage()
        {
            InitializeComponent();
        }

        // Kat Butonları (Tag özelliği 1, 2, 3... olmalı)
        private void Allbuttons_Click(object sender, EventArgs e)
        {
            Button tiklananButon = (Button)sender;
            int secilenKatNo = 1; // Varsayılan

            // YÖNTEM: Tag özelliğini kontrol et
            if (tiklananButon.Tag != null)
            {
                // Tag'deki değeri sayıya çevir
                secilenKatNo = Convert.ToInt32(tiklananButon.Tag);
            }
            else
            {
                // Eğer Tag unutulmuşsa eski yöntemle Text'ten kurtarmaya çalış
                string yazi = tiklananButon.Text;
                if (char.IsDigit(yazi[0]))
                    secilenKatNo = int.Parse(yazi[0].ToString());
            }

            this.Hide();

            // Kat Detay Sayfasını Aç
            ParkingLotSelectingPage parkPage = new ParkingLotSelectingPage(secilenKatNo);
            parkPage.ShowDialog();

            this.Show();
        }

        // ARAÇ BUL BUTONU (Tasarımda button5 ise)
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Araç Bulma Sayfasını Aç
            ParkingLotFinderPage finderPage = new ParkingLotFinderPage();
            finderPage.ShowDialog();

            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            authRepository.VeritabaniniKompleSifirla();
            MessageBox.Show("Veritabanı komple sıfırlandı.");
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
    }
}