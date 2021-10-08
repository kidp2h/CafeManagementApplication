using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementApplication.models
{
    public class Table
    {
        private int iD; 

        public int ID
        {
            get { return iD; }
            set { iD = value;}
        }

        private string name;
         public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string status; 
        public string Status
        {
            get { return status; }
            set { name = value; }
        }

        public Table()
        {
            
        }
        public Table(int iD, string name, string status)
        {
            this.iD = iD;
            this.name = name;
            this.status = status;
        }
        
        public List<Table> GetTableList()
        {
            List<Table> tables = new List<Table>();
            Table table1 = new Table(1,"Bàn 1","Trống");
            Table table2 = new Table(2, "Bàn 2", "Trống");
            Table table3 = new Table(3, "Bàn 3", "Trống");
            tables.Add(table1);
            tables.Add(table2);
            tables.Add(table3);
            return tables;
        }
    }
}
