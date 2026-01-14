using GorselProgramlama.Business;
using GorselProgramlama.Data;
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

        private void Allbuttons_Click(object sender, EventArgs e)
        {
            Button tiklananButon = (Button)sender;
            int secilenKatNo = 1; 

            if (tiklananButon.Tag != null)
            {
                secilenKatNo = Convert.ToInt32(tiklananButon.Tag);
            }
            else
            {
                string yazi = tiklananButon.Text;
                if (char.IsDigit(yazi[0]))
                    secilenKatNo = int.Parse(yazi[0].ToString());
            }

            this.Hide();

            ParkingLotSelectingPage parkPage = new ParkingLotSelectingPage(secilenKatNo);
            parkPage.ShowDialog();

            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private void FloorSelectionPage_Load(object sender, EventArgs e)
        {
            label2.Text = "Hoşgeldiniz, " + AuthService.CurrentUserPlate;
        }
    }
}