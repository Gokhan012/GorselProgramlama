using GorselProgramlama.Data;
using GorselProgramlama.Repositoty;
using GorselProgramlama.UI; // UI referansı
using System.Security.Cryptography;
using System.Text;

namespace GorselProgramlama.Business
{
    internal class AuthService
    {
        AuthRepository _repo;
        static string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\Gorsel.mdf;Integrated Security=True;Connect Timeout=30";
        public AuthService()
        {
            _repo = new AuthRepository(_connString);
        }

        public void CreateUser(string plateNumber, string password,string passwordagain, string name, string surname)
        {
            tblUser u = new tblUser();
            if (password != passwordagain)
            {
                throw new Exception("Şifreler uyuşmuyor.");
            }
            u.PlateNumber = plateNumber;
            u.Name = name;
            u.Surname = surname;
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
            
            tblUser u = _repo.GetUser(plateNumber);


            if (u == null)
            {
                return false; 
            }

         
            var inputPasswordHash = GenerateHash(password);

          
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
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
        }
    }
}