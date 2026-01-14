using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GorselProgramlama.Business;
using GorselProgramlama.Repositoty;

namespace GorselProgramlama.UI
{
    public partial class ParkingLotSelectingPage : Form
    {
        private int _gelenKatNo;
        private ParkingRepository _parkRepo;

        public ParkingLotSelectingPage(int katNo)
        {
            InitializeComponent();
            _gelenKatNo = katNo;
            _parkRepo = new ParkingRepository();
            this.Text = $"{_gelenKatNo}. Kat - Park Alanı";
        }

        private void ParkingLotSelectingPage_Load(object sender, EventArgs e)
        {
            EkranTazele();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                EkranTazele();
            }
        }

        private void EkranTazele()
        {
            ButonlariSifirlaVeBagla();
            DataTable dtDoluYerleri = _parkRepo.GetDoluParkYerleri(_gelenKatNo);
            DoluYerleriIsaretle(dtDoluYerleri);
        }

        private IEnumerable<Button> TumButonlariGetir(Control anaKontrol)
        {
            foreach (Control item in anaKontrol.Controls)
            {
                if (item is Button btn && item.Tag != null && item.Tag.ToString().Trim() != "")
                {
                    yield return btn;
                }
                if (item.HasChildren)
                {
                    foreach (Button childBtn in TumButonlariGetir(item))
                    {
                        yield return childBtn;
                    }
                }
            }
        }

        private void ButonlariSifirlaVeBagla()
        {
            foreach (Button btn in TumButonlariGetir(this))
            {
                btn.Font = new Font("Microsoft Sans Serif",20, FontStyle.Bold);
                btn.BackColor = Color.GreenYellow;
                btn.Text = "BOŞ";
                btn.Enabled = true;
                btn.Click -= ParkYeri_Click;
                btn.Click += ParkYeri_Click;
            }
        }

        private void DoluYerleriIsaretle(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                int parkYeriNo = Convert.ToInt32(row["ParkYeriNumarasi"]);
                int userID = Convert.ToInt32(row["UserID"]);
                string plaka = row["PlateNumber"] != DBNull.Value ? row["PlateNumber"].ToString() : "";

                foreach (Button btn in TumButonlariGetir(this))
                {
                    if (btn.Tag.ToString().Trim() == parkYeriNo.ToString())
                    {
                        btn.BackColor = Color.Red;

                        if (userID == AuthService.CurrentUserId)
                        {
                            btn.Text = !string.IsNullOrEmpty(plaka) ? plaka : "ARACINIZ";
                        }
                        else
                        {
                            btn.Text = "DOLU";
                        }
                        break;
                    }
                }
            }
        }

        private void ParkYeri_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null) return;
            int parkNo = Convert.ToInt32(btn.Tag);

            bool benimAracim = _parkRepo.BuParkYeriBenimMi(AuthService.CurrentUserId, _gelenKatNo, parkNo);

            if (benimAracim)
            {
                DialogResult cevap = MessageBox.Show(
                    "Aracınızın çıkış işlemini yapmak ve ödeme ekranına gitmek istiyor musunuz?",
                    "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    PaymentPage odemeSayfasi = new PaymentPage(AuthService.CurrentUserId, _gelenKatNo, parkNo);
                    if (odemeSayfasi.ShowDialog() == DialogResult.OK)
                    {
                        EkranTazele();
                    }
                }
                return;
            }

            if (btn.Text == "DOLU" || btn.BackColor == Color.Red)
            {
                MessageBox.Show("Bu park yeri dolu ve size ait değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool zatenAraciVar = _parkRepo.KullanicininIcerideAraciVarMi(AuthService.CurrentUserId);
            if (zatenAraciVar)
            {
                MessageBox.Show("Otoparkta bu plakaya sahip olan bir araba zaten var.",
                                "İşlem Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult parkCevap = MessageBox.Show(
                $"{_gelenKatNo}. Kat, {parkNo} numaralı yere park etmek istiyor musunuz?",
                "Park Et", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (parkCevap == DialogResult.Yes)
            {
                try
                {
                    _parkRepo.ParkEt(AuthService.CurrentUserId, _gelenKatNo, parkNo);
                    MessageBox.Show("Park işlemi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EkranTazele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}