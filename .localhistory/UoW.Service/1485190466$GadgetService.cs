using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Data.Infrastructure.Interfaces;
using UoW.Data.Repositories.Interfaces;
using UoW.Model.Models;
using UoW.Service.Interfaces;

namespace UoW.Service
{
    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepo gadgetRepo;
        private readonly IUnitOfWork unitOfWork;

        public GadgetService(IGadgetRepo gadgetRepo, IUnitOfWork unitOfWork)
        {
            this.gadgetRepo = gadgetRepo;
            this.unitOfWork = unitOfWork;
        }

        public Gadget GetGadget(int id)
        {
            return gadgetRepo.Get(xx => xx.GadgetID == id);
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }
    }
}
