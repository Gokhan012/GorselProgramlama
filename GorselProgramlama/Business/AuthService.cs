using GorselProgramlama.Data;
using GorselProgramlama.Repositoty;
using GorselProgramlama.UI; // UI referansı
using System.Security.Cryptography;
using System.Text;

namespace GorselProgramlama.Business
{
    public class AuthService
    {
        public static int CurrentUserId = 0;
        public static string CurrentUserPlate = "";
        AuthRepository _repo;
        public static string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\Gorsel.mdf;Integrated Security=True;Connect Timeout=30";
        public AuthService()
        {
            _repo = new AuthRepository();
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
                CurrentUserId = u.ID;             
                CurrentUserPlate = u.PlateNumber;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout()
        {
            CurrentUserId = 0;
            CurrentUserPlate = "";
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
        }
    }
}