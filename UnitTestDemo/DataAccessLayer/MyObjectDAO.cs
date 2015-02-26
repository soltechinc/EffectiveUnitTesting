using System;
using System.Collections.Generic;

namespace SolTech.Demos.UnitTesting
{
    public class MyObjectDAO : IMyObjectDAO
    {
        public IEnumerable<MyObject> List()
        {
            return new List<MyObject>(MyObjectRepository._database).AsReadOnly();
        }
    }
}
