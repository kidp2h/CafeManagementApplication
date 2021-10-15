using CafeManagementApplication.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementApplication.helpers
{
    public class ValidateForm
    {
        private static ValidateForm instance;
        public static ValidateForm Instance
        {
            get
            {
                if (instance == null) instance = new ValidateForm();
                return instance;
            }
        }

        public bool checkEmpty(TextBox tb, StringBuilder sb, string msg)
        {
            if(tb.Text.Equals(""))
            {
                sb.Append(msg + "\n");
                tb.BackColor = Color.Yellow;
                return true;
            } 
            else
            {
                tb.BackColor = Color.White;
            }
            return false;
        }

        public bool checkNumber(TextBox tb, StringBuilder sb, string msg, string type)
        {
            if (checkEmpty(tb, sb, msg)) return true;
            else
            {
                try
                {
                    int Number = Int32.Parse(tb.Text);
                    tb.BackColor = Color.White;
                }
                catch(Exception e)
                {
                    sb.Append( type + " phải là số !\n");
                    tb.BackColor = Color.Yellow;
                    return true;
                } 
                
            }
            return false;
        }

        public void checkAge(TextBox tb, StringBuilder sb, string msg)
        {
            if (checkEmpty(tb, sb, msg)) return;
            else if(checkNumber(tb, sb, msg, "Tuổi")) return;
            else
            {
                int age = Int32.Parse(tb.Text);
                if (age < 18 || age > 60)
                {
                    sb.Append("Độ tuổi phải từ 18 đến 60 tuổi !\n");
                    tb.BackColor = Color.Yellow;
                    return;
                }
                else
                {
                    tb.BackColor = Color.White;
                }

            }
        }
        public void checkUsername(TextBox tb, StringBuilder sb, string msg)
        {
            if (checkEmpty(tb, sb, msg)) return;
            else
            {
                if(UserModel.Instance.checkExist(tb.Text))
                {
                    sb.Append("Tài khoản đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                } 
                else
                {
                    tb.BackColor = Color.White;
                }
            }
        }
    }
}
