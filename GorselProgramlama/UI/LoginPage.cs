using GorselProgramlama.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace GorselProgramlama.UI;

public partial class LoginPage : Form
{
    AuthService authService = new AuthService();
    public LoginPage()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //if(textBox1.Text=="admin" && textBox2.Text=="admin")
        // {
        //     MessageBox.Show("Admin Girişi Başarılı");
        //     AdminPage adminPage = new AdminPage();
        //     adminPage.Show();
        //     this.Hide();
        // }
        if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
        {
            MessageBox.Show("Lütfen plaka ve şifre alanlarını doldurunuz.");
            return;
        }
        else if (authService.Login(textBox1.Text, textBox2.Text))
        {
            MessageBox.Show("Giriş Başarılı");
            FloorSelectionPage floorSelectionPage = new FloorSelectionPage();
            floorSelectionPage.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        RegisterPage registerPage = new RegisterPage(this);
        registerPage.Show();
        this.Hide();
    }

    private void LoginPage_Load(object sender, EventArgs e)
    {
        textBox1.TabIndex = 0;
        textBox2.TabIndex = 1;
        button1.TabIndex = 2;
        button2.TabIndex = 3;
        this.AcceptButton = button1;
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }
}
