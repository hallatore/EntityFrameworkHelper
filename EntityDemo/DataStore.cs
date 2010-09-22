using EntityFrameworkHelper.Web;
using EntityDemo.Model;

namespace EntityDemo
{
    public static class DataStore
    {
        public static IEntities GetSession()
        {
            return (IEntities)EntityContextManager.GetSession();
        }

        public static IEntities CreateSession()
        {
            return (IEntities)EntityContextManager.CreateSession();
        }

        public static void Dispose()
        {
            EntityContextManager.Dispose();
        }
    }
}