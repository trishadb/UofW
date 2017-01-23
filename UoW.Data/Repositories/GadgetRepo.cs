using UoW.Data.Infrastructure;
using UoW.Data.Infrastructure.Interfaces;
using UoW.Data.Repositories.Interfaces;
using UoW.Model.Models;

namespace UoW.Data.Repositories
{
    public class GadgetRepo : GenericRepo<Gadget>, IGadgetRepo
    {
        public GadgetRepo(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
