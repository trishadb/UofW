using UoW.Data.Infrastructure.Interfaces;

namespace UoW.Data.Infrastructure
{
    /// <summary>
    /// Responsible to send a Commit command to the database through a IUnitOfWork injected instance
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private UoWEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public UoWEntities DbContext => dbContext ?? (dbContext = dbFactory.Init());

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
