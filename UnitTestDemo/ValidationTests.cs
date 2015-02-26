using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolTech.Demos.UnitTesting
{
    public class ValidationTests
    {
        [Fact]
        public void VerifyThatEmptyGuidsAreInvalid()
        {
            var item = new MyObject { Id = Guid.Empty, Created = DateTime.Now, Name = "Valid" };
            var results = new List<ValidationResult>();
            Assert.False(Validator.TryValidateObject(item, new ValidationContext(item), results));
        }

        [Fact]
        public void VerifyThatFutureCreatedDatesAreInvalid()
        {
            var item = new MyObject { Id = Guid.NewGuid(), Created = DateTime.Now.AddDays(1), Name = "Valid" };
            var results = new List<ValidationResult>();
            Assert.False(Validator.TryValidateObject(item, new ValidationContext(item), results));
        }
    }
}
