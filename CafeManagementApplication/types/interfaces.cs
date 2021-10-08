using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagementApplication.models;
using MongoDB.Bson;

namespace CafeManagementApplication.types
{
    interface IOderItems
    {
        int  product { get; set; }
        int amount { get; set; }
        
    }
}
