using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GorselProgramlama.UI
{
    public partial class FloorSelectionPage : Form
    {
        public FloorSelectionPage()
        {
            InitializeComponent();
        }

        private void Allbuttons_Click(object sender, EventArgs e)
        {
            ParkingLotSelectingPage parkingLotSelectingPage = new ParkingLotSelectingPage();
            parkingLotSelectingPage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ParkingLotFinderPage parkingLotFinderPage = new ParkingLotFinderPage();
            parkingLotFinderPage.ShowDialog();
        }
    }
}
