using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Model.Models;

namespace UoW.Service.Interfaces
{
    public interface IGadgetService
    {
        Gadget GetGadget(string name);
    }
}
