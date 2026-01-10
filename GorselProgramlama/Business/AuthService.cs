using GorselProgramlama.Data;
using GorselProgramlama.Repositoty;
using GorselProgramlama.UI; // UI referansı
using System.Security.Cryptography;
using System.Text;

namespace GorselProgramlama.Business
{
    internal class AuthService
    {
        // Connection string'i buraya koymuşsunuz ama normalde appsettings.json'da olması daha iyidir.
        static string _connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Hafta12;Integrated Security=True;TrustServerCertificate=True";

        // IAuthRepository arayüzünü değil direkt sınıfı kullanıyorsanız burayı AuthRepository yapabilirsiniz.
        AuthRepository _repo;

        public AuthService()
        {
            _repo = new AuthRepository(_connString);
        }

        public void CreateUser(string plateNumber, string password, string name, string surname)
        {
            tblUser u = new tblUser();
            u.PlateNumber = plateNumber;
            u.Name = name;
            u.Surname = surname;
            // Şifreyi hashleyerek gönderiyoruz
            u.Password = GenerateHash(password);

            _repo.CreateUser(u);
        }

        public string GenerateHash(string password)
        {
            using (var hashFunction = SHA512.Create())
            {
                var hash = hashFunction.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hash);
            }
        }

        public bool Login(string plateNumber, string password)
        {
            // 1. Veritabanından kullanıcıyı plakaya göre çek
            // Repository'deki metodumuz artık ID değil plaka bekliyor.
            tblUser u = _repo.GetUser(plateNumber);

            // 2. KRİTİK KONTROL: Kullanıcı var mı?
            if (u == null)
            {
                return false; // Kullanıcı yoksa işlem biter.
            }

            // 3. Girilen şifreyi hashle
            var inputPasswordHash = GenerateHash(password);

            // 4. Karşılaştır (u.Password veritabanındaki hash'tir)
            if (u.Password == inputPasswordHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout()
        {
            // Servis katmanında UI açmak (LoginPage show) mimari olarak hatalıdır ama
            // projeniz basitse çalışır. Doğrusu UI katmanının bunu yönetmesidir.
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
        }
    }
}