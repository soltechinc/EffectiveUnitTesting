using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolTech.Demos.UnitTesting
{
    public class AddMyObjectModel
    {
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsValid { get; set; }
    }
}
