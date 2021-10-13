using CafeManagementApplication.models;
using CafeManagementApplication.views;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    public class LoadItemController
    {
        private static LoadItemController instance;
        private static readonly object lockObject = new object();
        public static LoadItemController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null) instance = new LoadItemController();
                    }
                }
                return instance;

            }
        }

        private LoadItemController() { }

        public void LoadingItemTable ()
        {
            uscSale.Instance.getFlpTableList().Controls.Clear();
            dynamic tables = TableModel.Instance.getListTable();
            foreach (Table table in tables)
            {            
                uscSale_Table temp = new uscSale_Table();
                temp.Tag = table.Id;
                temp.TableName = table.TableName;

                if (table.Status == types.sTable.FULL)
                {
                    temp.Status = "Có người";                 
                }
                else
                {
                    temp.Status = "Bàn trống";                  
                }

                uscSale.Instance.getFlpTableList().Controls.Add(temp);
            }
        }

        public void LoadingItemTable(FlowLayoutPanel flp)
        {
            flp.Controls.Clear();
            dynamic tables = TableModel.Instance.getListTable();
            foreach (Table table in tables)
            {   
                uscSale_Table temp = new uscSale_Table();
                temp.Id = table.Id.ToString();
                temp.TableName = table.TableName;
                temp.BillId = table.Bill.ToString();

                if (table.Status == types.sTable.FULL)
                {
                    temp.Status = "Có người";
                }
                else
                {
                    temp.Status = "Bàn trống";
                }

                flp.Controls.Add(temp);             
            }
        }


        public void LoadingItemProduct(FlowLayoutPanel flp)
        {
            dynamic products = ProductModel.Instance.getListProduct();
            foreach (dynamic product in products)
            {
                uscProduct temp = new uscProduct();
                temp.Id = product["_id"].Value.ToString();
                temp.NameProduct = product["name"].Value;
                temp.Price = product["price"].Value.ToString();
                flp.Controls.Add(temp);
            }
        }

        public void LoadingItemCategory(FlowLayoutPanel flp)
        {
            dynamic products = ProductModel.Instance.getListProduct();
            foreach (dynamic product in products)
            {
                uscCategory temp = new uscCategory();
                temp.CategoryName = product["category"].Value.ToString();
                
                flp.Controls.Add(temp);
            }
        }
    }
}
