using System;

namespace SolTech.Demos.UnitTesting
{
    public interface IMyObjectRepository
    {
        MyObject Get(Guid id);
        void Add(MyObject item);
        void Update(MyObject item);
        void Delete(Guid id);
    }
}
