using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolTech.Demos.UnitTesting
{
    public class MyObject : IValidatableObject
    {
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set;}
        public DateTime Created { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IList<ValidationResult> results = new List<ValidationResult>();

            if (Id == Guid.Empty)
            {
                results.Add(new ValidationResult("You must supply a valid Guid."));
            }
            if (Created > DateTime.Now)
            {
                results.Add(new ValidationResult("You cannot create objects in the future."));
            }

            return results;
        }
    }
}
