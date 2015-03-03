using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SolTech.Demos.UnitTesting
{
    public static class JsonNetExtensions
    {
        public static JsonNetResult JsonNet(this Controller controller, object data, JsonRequestBehavior requestBehavior = JsonRequestBehavior.AllowGet)
        {
            return new JsonNetResult { Data = data, JsonRequestBehavior = requestBehavior };
        }
    }
}
