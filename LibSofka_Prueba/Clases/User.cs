using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSofka_Prueba.Clases
{
    public class User
    {
        private String userName;
        private String password;

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public String UserName
        {
            get => userName;
            set => userName = value;
        }
        public string Password { get => password; set => password = value; }
    }
}
