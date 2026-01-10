using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorselProgramlama.Data;
using Microsoft.VisualBasic.ApplicationServices;

namespace GorselProgramlama.Business
{
    public interface IAuthService
    {
        bool Login(string u, string p);
        void Logout();

        void CreateUser(string username, string password, string role);


        string GenerateHash(string password);

        User GetUser(string username);
    }

}
