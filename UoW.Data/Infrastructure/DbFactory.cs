using UoW.Data.Infrastructure.Interfaces;

namespace UoW.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        UoWEntities dbContext;

        public UoWEntities Init()
        {
            return dbContext ?? (dbContext = new UoWEntities());
        }

        protected override void DisposeCore()
        {
            dbContext?.Dispose();
        }
    }
}
