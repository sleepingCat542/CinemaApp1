using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class User
    {
        public object idUser { get; set; }
        public object login { get; set; }
        public object password { get; set; }
        public object eMail { get; set; }

        public User(object id, object login, object password, object eMail)
        {
            this.idUser = id;
            this.login = login;
            this.password = password;
            this.eMail = eMail;
        }
    }  
}
