using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolTech.Demos.UnitTesting
{
    public class TestMyObject
    {
        [Fact]
        public void VerifyNameIsRequired()
        {
            var myObject = new MyObject();
            myObject.Id = Guid.NewGuid();
            myObject.Created = DateTime.Now;
            var validationContext = new ValidationContext(myObject);
            Validator.ValidateObject(myObject, validationContext, true);
        }
    }
}
