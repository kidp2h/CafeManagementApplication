using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.models
{
    class TableModel
    {
        private string name;
        private string status;

        public TableModel() { }

        public TableModel(string name, string status)
        {
            this.name = name;
            this.status = status;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        
        public List<TableModel> getTableList()
        {
            List<TableModel> tbList = new List<TableModel>();
            TableModel tbnew1 = new TableModel("Bàn 1", "Trống");
            TableModel tbnew2 = new TableModel("Bàn 2", "Trống");
            TableModel tbnew3 = new TableModel("Bàn 3", "Trống");
            TableModel tbnew4 = new TableModel("Bàn 4", "Trống");
            tbList.Add(tbnew1);
            tbList.Add(tbnew2);
            tbList.Add(tbnew3);
            tbList.Add(tbnew4);

            return tbList;


        }











    }
}
