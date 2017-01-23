using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Data.Infrastructure.Interfaces;

namespace UoW.Data.Infrastructure
{
    /// <summary>
    /// Responsible to send a Commit command to the database through a IUnitOfWork injected instance
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private StoreEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public StoreEntities DbContext => dbContext ?? (dbContext = dbFactory.Init());

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
