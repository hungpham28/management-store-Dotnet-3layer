using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        public AccountDTO(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public string username{ get; set; }
        public string password { get; set; }
        public string role { get; set;}


    }
}
