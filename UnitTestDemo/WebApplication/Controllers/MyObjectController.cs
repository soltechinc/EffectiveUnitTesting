using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolTech.Demos.UnitTesting.Controllers
{
    public class MyObjectController : Controller
    {
        private readonly IMyObjectLogic _myObjectLogic;

        public MyObjectController(IMyObjectLogic myObjectLogic)
        {
            if (myObjectLogic == null) throw new ArgumentNullException("myObjectLogic");
            _myObjectLogic = myObjectLogic;
        }

        [HttpGet]
        public JsonNetResult Get(Guid id)
        {
            var myObject = _myObjectLogic.GetMyObject(id);
            return this.JsonNet(myObject);
        }

        [HttpPost]
        public JsonNetResult Add(MyObject myObject)
        {
            bool success = false;
            String errorMessage = null;
            try
            {
                _myObjectLogic.AddMyObject(myObject);
            }
            catch (Exception e)
            {
                success = false;
                errorMessage = e.Message;
            }
            return this.JsonNet(new { Success = success, ErrorMessage = errorMessage });
        }

        [HttpDelete]
        public JsonNetResult Delete(Guid id)
        {
            bool success = false;
            String errorMessage = null;
            try
            {
                _myObjectLogic.DeleteMyObject(id);
            }
            catch (Exception e)
            {
                success = false;
                errorMessage = e.Message;
            }
            return this.JsonNet(new { Success = success, ErrorMessage = errorMessage });
        }

        [HttpPut]
        public JsonNetResult Update(MyObject myObject)
        {
            bool success = false;
            String errorMessage = null;
            try
            {
                _myObjectLogic.UpdateMyObject(myObject);
            }
            catch (Exception e)
            {
                success = false;
                errorMessage = e.Message;
            }
            return this.JsonNet(new { Success = success, ErrorMessage = errorMessage });
        }
    }
}