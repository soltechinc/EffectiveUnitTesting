using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolTech.Demos.UnitTesting
{
    public interface IMyObjectLogic
    {
        void AddMyObject(MyObject item);
        void UpdateMyObject(MyObject item);
        IEnumerable<MyObject> ListMyObjects();
        void DeleteMyObject(Guid id);
    }
}
