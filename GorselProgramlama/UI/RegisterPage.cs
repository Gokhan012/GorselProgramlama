using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GorselProgramlama.UI;

public partial class RegisterPage : Form
{
    LoginPage _loginPage;
    public RegisterPage(LoginPage loginPage)
    {
        InitializeComponent();
        _loginPage = loginPage;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _loginPage.Show();
        this.Hide();
    }
}
