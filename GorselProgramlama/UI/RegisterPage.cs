using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GorselProgramlama.Business;
using GorselProgramlama.Repositoty;
namespace GorselProgramlama.UI;

public partial class RegisterPage : Form
{
    LoginPage _loginPage;
    AuthService authService = new AuthService();
    public RegisterPage(LoginPage loginPage)
    {
        InitializeComponent();
        _loginPage = loginPage;

    }

    private void button2_Click(object sender, EventArgs e)
    {

        try
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            else if (textBox1.Text.Trim().Length < 7 || textBox1.Text.Trim().Length > 9)
            {
                MessageBox.Show("Lütfen geçerli  bir plaka giriniz.", "Hatalı Plaka");
            }
            else if (textBox2.Text.Trim().Length < 6)
            {
                MessageBox.Show("Şifreniz çok kısa! En az 6 karakter olmalı.", "Zayıf Şifre");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen tekrar giriniz.", "Şifre Hatası");
            }
            else
            {
                authService.CreateUser(textBox1.Text.Trim().ToUpper(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim());

                MessageBox.Show("Kayıt Başarılı! Giriş sayfasına yönlendiriliyorsunuz.");

                _loginPage.Show();
                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Kayıt başarısız: " + ex.Message);
        }
    }

    private void RegisterPage_Load(object sender, EventArgs e)
    {
        textBox1.TabIndex = 0;
        textBox2.TabIndex = 1;
        textBox3.TabIndex = 2;
        textBox4.TabIndex = 3;
        textBox5.TabIndex = 4;
        button.TabIndex = 5;
        this.AcceptButton = button;
    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {

    }
}