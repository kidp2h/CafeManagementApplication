
using System.Configuration;

namespace CafeManagementApplication.helpers
{
    class Hash
    {
        static int salt = int.Parse(ConfigurationManager.AppSettings["salt"]);

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
