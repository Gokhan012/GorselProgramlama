using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GorselProgramlama.UI;

public partial class LoginPage : Form
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        FloorSelectionPage floorSelectionPage = new FloorSelectionPage();
        floorSelectionPage.Show();
        this.Hide();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        RegisterPage registerPage = new RegisterPage(this);
        registerPage.Show();
        this.Hide();
    }
}
