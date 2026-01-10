using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorselProgramlama.Data;

namespace GorselProgramlama.Repositoty
{
    internal interface IAuthRepository
    {
        public tblUser GetUser(string username);

        public void CreateUser(tblUser user);  
    }
}
