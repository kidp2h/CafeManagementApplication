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

        public bool checkEmpty(dynamic tb, StringBuilder sb, string msg)
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


        public void checkUsername(TextBox tb, StringBuilder sb, string msg, bool status)
        {
            if (checkEmpty(tb, sb, msg)) return;

            else
            {
                if(status)
                {
                    if (UserModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Tài khoản đã tồn tại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                } 
                else
                {
                    if (!UserModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Tài khoản không tồn tại !\n");
                        sb.Append("Vui lòng chọn lại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }
                
            }
        }

        public void checkTableName(TextBox tb, StringBuilder sb, string msg, bool status)
        {
            if(checkEmpty(tb, sb, msg)) return;

            else
            {
                if (status)
                {
                    if (TableModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Bàn đã tồn tại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }
                else
                {
                    if (!TableModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Bàn không tồn tại !\n");
                        sb.Append("Vui lòng chọn lại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }

            }
        }

        public void checkProductName(TextBox tb, StringBuilder sb, string msg, bool status)
        {
            if (checkEmpty(tb, sb, msg)) return;

            else
            {
                if (status)
                {
                    if (ProductModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Món đã tồn tại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }
                else
                {
                    if (!ProductModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Món đó không tồn tại !\n");
                        sb.Append("Vui lòng chọn lại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }

            }
        }

        public void checkCategoryName(TextBox tb, StringBuilder sb, string msg, bool status)
        {
            if (checkEmpty(tb, sb, msg)) return;

            else
            {
                if (status)
                {
                    if (CategoryModel.Instance.isExist(tb.Text))
                    {
                        sb.Append("Loại sản phẩm đã tồn tại !\n");
                        tb.BackColor = Color.Yellow;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }
                else
                {
                    if (!CategoryModel.Instance.isExist(tb.Tag.ToString()))
                    {
                        sb.Append("Loại sản phẩm không tồn tại !\n");
                        sb.Append("Vui lòng chọn lại !\n");
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
}
