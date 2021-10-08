using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using CafeManagementApplication.config;

namespace CafeManagementApplication.models
{
    abstract class BaseModel<T>
    {
        public abstract IMongoCollection<T> getCollection();
    }
}
