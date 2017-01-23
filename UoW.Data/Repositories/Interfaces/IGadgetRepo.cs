using UoW.Data.Infrastructure.Interfaces;
using UoW.Model.Models;

namespace UoW.Data.Repositories.Interfaces
{
    public interface IGadgetRepo : IGenericGets<Gadget>, IGenericCreate<Gadget>
    {
    }
}
