using CafeManagementApplication.models;
using CafeManagementApplication.views;
using System.Windows.Forms;

namespace CafeManagementApplication.controllers
{
    public class LoadItemController
    {
        private static LoadItemController instance;

        public static LoadItemController Instance
        {
            get
            {
                if (instance == null)
                {
                   instance = new LoadItemController();
                }
                return instance;

            }
        }

        private LoadItemController() { }


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


        public void LoadingItemProductByCategoryId(FlowLayoutPanel flp, string categoryId)
        {
            flp.Controls.Clear();
            dynamic products = ProductModel.Instance.getListProductByCategory(categoryId);
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
            flp.Controls.Clear();
            dynamic categorys = CategoryModel.Instance.getListCategory();
            foreach (dynamic category in categorys)
            {
                uscCategory temp = new uscCategory();
                temp.CategoryId = category.Id.ToString();
                temp.CategoryName = category.NameCategory.ToString();
                
                flp.Controls.Add(temp);
            }
        }
    }
}
