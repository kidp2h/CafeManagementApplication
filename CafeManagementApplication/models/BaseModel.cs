using MongoDB.Driver;

namespace CafeManagementApplication.models
{
    abstract class BaseModel<T>
    {
        public abstract IMongoCollection<T> getCollection();
    }
}
