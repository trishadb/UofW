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

        public Gadget GetGadget(string name)
        {
            return gadgetRepo.Get(xx => xx.Name == name);
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }
    }
}
