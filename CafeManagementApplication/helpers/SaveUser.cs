using CafeManagementApplication.models;
using System;
using System.IO;
using System.Windows.Forms;
using CafeManagementApplication.types;
using CafeManagementApplication.views;

namespace CafeManagementApplication.helpers
{
    public class SaveUser
    {
        private string file;

        private static SaveUser instance;
        public static SaveUser Instance
        {
            get
            {
                if (instance == null) instance = new SaveUser();
                return instance;
            }
        }
        public SaveUser()
        {
            file = Path.GetTempPath() + "tempSaveUser.txt";
        }

        public void saveUserToFile(string username)
        {
            DateTime expire = DateTime.Now.AddHours(2);
            string[] lines ={username,expire.ToString()};
            File.WriteAllLines(file, lines);
        }
        public dynamic checkSession()
        { 
            if (File.Exists(file))
            {
                string[] line = File.ReadAllLines(file);
                if(line.Length != 0) {
                    DateTime expire = DateTime.Parse(line[1]);
                    string username = line[0];
                    if (DateTime.Compare(DateTime.Now, expire) == 1) // expired
                    {
                        return null;
                    }
                    else
                    {
                        User user = UserModel.Instance.getUserByUsername(username);
                        return user;
                    }
                }
                else
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }
            
        }
    }
}
