using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class Admin
    {
        public string login;
        public string password;

        public Admin(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
