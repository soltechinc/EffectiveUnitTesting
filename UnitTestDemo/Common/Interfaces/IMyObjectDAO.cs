using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolTech.Demos.UnitTesting
{
    public interface IMyObjectDAO
    {
        IEnumerable<MyObject> List();
    }
}
