using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Service.Interfaces
{
    public interface IGadgetService
    {
        Gadget GetGadget(int id);
    }
}
