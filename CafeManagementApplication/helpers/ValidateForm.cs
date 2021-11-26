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
                catch
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

        public void checkTableName(TextBox tb, StringBuilder sb, string msg, string status)
        {
            if(checkEmpty(tb, sb, msg)) return;

            
            if(status == "add")
            {
                if (TableModel.Instance.isExist(tb.Text))
                {
                    sb.Append("Bàn đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                }
                    
            }
            else if (status == "update")
            {
                if (!TableModel.Instance.isExist(tb.Tag.ToString()))
                {
                    sb.Append("Vui lòng chọn bàn để thao tác !\n");
                    tb.BackColor = Color.Yellow;
                    return;
                }

                if (TableModel.Instance.isExist(tb.Text))
                {
                    sb.Append("Bàn đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                }
            }
            else
            {
                if (!TableModel.Instance.isExist(tb.Tag.ToString()))
                {
                    sb.Append("Vui lòng chọn bàn để thao tác !\n");
                    tb.BackColor = Color.Yellow;
                }
            }

         
        }

        public void checkTableStatus(TextBox tb, StringBuilder sb, string msg)
        {
           if(tb.Text == "Có người")
           {
                sb.Append(msg);
           }
        }

        public void checkProductName(TextBox tb, StringBuilder sb, string msg, string status)
        {
            if (checkEmpty(tb, sb, msg)) return;

           
            if (status ==  "add")
            {
                if (ProductModel.Instance.isExist(tb.Text))
                {
                    sb.Append("Tên món đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                }
                    
            }
            else if (status == "update")
            {
                if (!ProductModel.Instance.isExist(tb.Tag.ToString()))
                {
                    sb.Append("Vui lòng chọn món để thao tác !\n");
                    tb.BackColor = Color.Yellow;
                    return;
                }

                if (ProductModel.Instance.isExist(tb.Text))
                {
                    sb.Append("Tên món đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                }
                    
            }
            else
            {
                if (!ProductModel.Instance.isExist(tb.Tag.ToString()))
                {
                    sb.Append("Vui lòng chọn món để thao tác !\n");
                    tb.BackColor = Color.Yellow;
                }
            }

            
        }

        public void checkCategoryName(TextBox tb, StringBuilder sb, string msg, string status)
        {
            if (checkEmpty(tb, sb, msg)) return;

           
            if (status == "add")
            {
                if (CategoryModel.Instance.isExist(tb.Text))
                {
                    sb.Append("Tên loại món đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                }
                   
            }
            else if ( status ==  "update")
            {
                if (!CategoryModel.Instance.isExist(tb.Tag.ToString()))
                {
                    sb.Append("Vui lòng chọn loại món để thao tác !\n");
                    tb.BackColor = Color.Yellow;
                    return;
                }

                if (CategoryModel.Instance.isExist(tb.Text))
                {
                    sb.Append("Tên loại món đã tồn tại !\n");
                    tb.BackColor = Color.Yellow;
                }
                    
            }
            else
            {
                if (!CategoryModel.Instance.isExist(tb.Tag.ToString()))
                {
                    sb.Append("Vui lòng chọn loại món để thao tác !\n");
                    tb.BackColor = Color.Yellow;           
                }
            }

            
        }

        public void checkCharge(TextBox tb, StringBuilder sb, string msg)
        {
            if (Int32.Parse(tb.Text) < 0) sb.Append(msg);
        }
    }
}
