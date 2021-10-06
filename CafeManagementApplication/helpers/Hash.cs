using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using CafeManagementApplication.helpers;

namespace CafeManagementApplication.helpers
{
    class Hash
    {
        static int salt = int.Parse(Config.GetValueFromKey("salt"));

        static public string hashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, Hash.salt);
        }
        static public bool verifyPassword(string password, string passwordHashed)
        {

            return BCrypt.Net.BCrypt.Verify(password, passwordHashed);

        }
    }
}
