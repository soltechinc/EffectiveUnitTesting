using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolTech.Demos.UnitTesting
{
    public class MyObjectRepository : IMyObjectRepository
    {
        internal static readonly IList<MyObject> _database = new List<MyObject>();

        public MyObject Get(Guid id)
        {
            return _database.FirstOrDefault(i => i.Id == id);
        }

        public void Add(MyObject item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (_database.FirstOrDefault(i => i.Id == item.Id) != null) throw new InvalidOperationException("Object with the specified ID already exists.");

            _database.Add(item);
        }

        public void Update(MyObject item)
        {
            if (item == null) throw new ArgumentNullException("item");
            var existingItem = _database.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem == null) throw new InvalidOperationException("No object with the specified ID exists.");

            _database.Remove(existingItem);
            _database.Add(item);
        }

        public void Delete(Guid id)
        {
            var existingItem = _database.FirstOrDefault(i => i.Id == id);
            if (existingItem == null) throw new InvalidOperationException("No object with the specified ID exists.");

            _database.Remove(existingItem);
        }
    }
}
