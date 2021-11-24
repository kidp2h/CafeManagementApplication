using CafeManagementApplication.controllers;
using CafeManagementApplication.helpers;
using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CafeManagementApplication.views
{
    public partial class fAddProducts : Form
    {
        public fAddProducts()
        {  
            InitializeComponent();

            //Gán cái form fAddProducts vào trong controler để có thể xử lý sự kiện click vào sản phẩm truyền thông tin sản phẩm qua ô TTSP
            //và xử lý render sản phẩm khi click vào loại sản phẩm
            LoadInfoController.Instance.View = this;

            //Gọi control để render các category vào trong ô chứa category của form fAddProduct
            LoadItemController.Instance.LoadingItemCategory(flpListCategorys);
            
        }

        #region Public Data In View
      
        public string BillID { get; set; }

        public string TableId { get; set; }

        public string TableStatus { get; set; }

        public string LblNameText
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string LblPriceText
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; this.tbSubtotal = Int32.Parse(value).ToString("c"); }
        }
        public string LblNameTag
        {
            get { return lblName.Tag.ToString(); }
            set { lblName.Tag = value; }
        }
        public string txtAmount
        {
            get { return txtBoxAmount.Text; }
            set { txtBoxAmount.Text = value; }
        }
        public TextBox tbAmount
        {
            get { return txtBoxAmount; }
        }

        public FlowLayoutPanel FlpListProducts
        {
            get { return flpListProducts; }
        }


        public string tbSubtotal
        {
            set { textBox2.Text = value; }
        }
        #endregion

        #region Handler Event
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkEmpty(lblName, sb, "Vui lòng chọn sản phẩm !");
            ValidateForm.Instance.checkEmpty(lblPrice, sb, "");
            ValidateForm.Instance.checkNumber(txtBoxAmount, sb, "Vui lòng nhập số lượng !", "Số lượng");
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            //gọi controler để thêm product vào bill có: id của bill là BillID, tên product là LblNameTag, số lượng là txtAmount
            BillController.Instance.AddProductToBill(this, this.BillID, this.LblNameTag, Int32.Parse(this.txtAmount));

            if (this.TableStatus != "Có người")
            {
                //nếu bàn chưa có người thì đổi lại trạng thái bàn
                this.TableStatus = "Có người";
                //Thread t1 = new Thread(() =>
               // {
                    //Invoke(new Action(() => // cách chạy đa luồng cho form không lỗi
                    //{
                        //render lại item bàn vào form bán hàng 
                        uscSale.Instance.LoadListTableForForm();
                //    }));
                //});
                //t1.IsBackground = true;
                //t1.Start();
                
            }

            LoadDataController.Instance.LoadBillOfTableByIdForViewSale(this.TableId);

            uscManager_Tables.Instance.LoadListTables(false);

            MessageBox.Show("ĐÃ THÊM MÓN !!!!", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Information);
        } 

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            #region Validate
            StringBuilder sb = new StringBuilder();
            ValidateForm.Instance.checkEmpty(lblName, sb, "Vui lòng chọn sản phẩm !");
            ValidateForm.Instance.checkEmpty(lblPrice, sb, "");
            
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            if (this.txtAmount == "") return;
            int amount = Int32.Parse(this.txtAmount);
            int price = Int32.Parse(this.LblPriceText);
            this.tbSubtotal = (amount * price).ToString("c");
          
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (this.txtAmount == "") this.txtAmount = "0";
            int amount = Int32.Parse(this.txtAmount);
            this.txtAmount = "" + (amount + 1);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (this.txtAmount == "") this.txtAmount = "2";
            int amount = Int32.Parse(this.txtAmount);
            if(amount > 1) this.txtAmount = "" + (amount - 1);
        }
        #endregion

        #region Effect
        private void lblName_TextChanged(object sender, EventArgs e)
        {
            if(lblName.BackColor != Color.White)
            lblName.BackColor = Color.White;
        }

        private void lblPrice_TextChanged(object sender, EventArgs e)
        {
            if (lblPrice.BackColor != Color.White)
            lblPrice.BackColor = Color.White;
        }
        #endregion
    }
}
