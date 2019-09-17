using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management
{
    public class Users
    {
        public string username;
        public string password;
        private int id;

        public Users(string username, string password, int id)
        {
            this.username = username;
            this.password = password;
            this.id = id;
        }
    }
}
