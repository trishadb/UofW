using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Data.Infrastructure.Interfaces
{
    /// <summary>
    /// a factory Interface responsible to initialize instances of this class.
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        UoWEntities Init();
    }
}
