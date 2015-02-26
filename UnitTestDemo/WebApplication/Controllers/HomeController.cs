using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolTech.Demos.UnitTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyObjectLogic _myObjectLogic;

        public HomeController(IMyObjectLogic myObjectLogic)
        {
            if (myObjectLogic == null) throw new ArgumentNullException("myObjectLogic");
            _myObjectLogic = myObjectLogic;
        }


        public ActionResult Index()
        {
            return View(_myObjectLogic.ListMyObjects());
        }

        public PartialViewResult Add()
        {
            return PartialView(new AddMyObjectModel { Id = Guid.NewGuid(), Created = DateTime.Now, IsValid = true });
        }

        [HttpPost]
        public PartialViewResult _AddObjectForm(AddMyObjectModel model)
        {
            if (ModelState.IsValid)
            {
                var myObject = new MyObject { Id = model.Id, Name = model.Name, Created = model.Created };
                try
                {
                    _myObjectLogic.AddMyObject(myObject);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e);
                }
            }
            return PartialView(model);
        }

        public JsonResult Delete(Guid id)
        {
            _myObjectLogic.DeleteMyObject(id);
            return Json(new { success = true });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}