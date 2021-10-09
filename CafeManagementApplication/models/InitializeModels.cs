using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.models
{
    class InitializeModels
    {
        public static User UserModel = new User();
        public static Table TableModel = new Table();
        public static Bill BillModel = new Bill();
        public static Category CategoryModel = new Category();
        public static Product ProductModel = new Product();
    }
}
