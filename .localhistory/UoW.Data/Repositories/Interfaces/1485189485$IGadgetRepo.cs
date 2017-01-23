using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Data.Infrastructure.Interfaces;
using UoW.Model.Models;

namespace UoW.Data.Repositories.Interfaces
{
    public interface IGadgetRepo : IGenericGets<Gadget>
    {
    }
}
