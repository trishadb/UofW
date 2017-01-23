using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UoW.Service.Interfaces;

namespace UoW.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGadgetService gadgetService;

        public HomeController(IGadgetService gadgetService)
        {
            this.gadgetService = gadgetService;
        }


        // GET: Home
        public ActionResult Index()
        {
            var objGadget = gadgetService.GetGadget("ProntoTec 7");
            gadgetService.CreateGadget(objGadget);

            gadgetService.SaveGadget();
            return View(objGadget);
        }
    }
}