using UoW.Data.Infrastructure.Interfaces;

namespace UoW.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        StoreEntities dbContext;

        public StoreEntities Init()
        {
            return dbContext ?? (dbContext = new StoreEntities());
        }

        protected override void DisposeCore()
        {
            dbContext?.Dispose();
        }
    }
}
