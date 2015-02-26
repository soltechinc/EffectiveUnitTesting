using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolTech.Demos.UnitTesting
{
    public class MyObjectLogic : IMyObjectLogic
    {
        private readonly IMyObjectRepository _repository;
        private readonly IMyObjectDAO _dao;
        private readonly IAuditLogger _logger;

        public MyObjectLogic(IMyObjectRepository repository, IMyObjectDAO dao, IAuditLogger logger)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            if (dao == null) throw new ArgumentNullException("dao");
            if (logger == null) throw new ArgumentNullException("logger");

            _repository = repository;
            _dao = dao;
            _logger = logger;
        }

        public void AddMyObject(MyObject item)
        {
            if (item == null) throw new ArgumentNullException("item");
            
            item.Created = DateTime.Now;
            Validator.ValidateObject(item, new ValidationContext(item));

            _logger.Log("Adding item {0}", item.Id);
            _repository.Add(item);
        }

        public void UpdateMyObject(MyObject item)
        {
            if (item == null) throw new ArgumentNullException("item");
            Validator.ValidateObject(item, new ValidationContext(item));

            if (_repository.Get(item.Id) == null) throw new IndexOutOfRangeException();

            _logger.Log("Updating item {0}", item.Id);
            _repository.Update(item);
        }

        public void DeleteMyObject(Guid id)
        {
            if (_repository.Get(id) == null) throw new IndexOutOfRangeException();
            _logger.Log("Deleting item {0}", id);
            _repository.Delete(id);
        }

        public IEnumerable<MyObject> ListMyObjects()
        {
            return _dao.List();
        }
    }
}
