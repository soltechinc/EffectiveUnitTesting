using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolTech.Demos.UnitTesting
{
    public class TestBLL
    {
        [Fact(DisplayName = "Calling add should push the object to the repository.")]
        public void CallingAddShouldPushTheObjectToTheRepository()
        {
            var mockRepo = new Mock<IMyObjectRepository>();
            var mockDAO = new Mock<IMyObjectDAO>();
            var mockAuditLog = new Mock<IAuditLogger>();

            var myBLL = new MyObjectLogic(mockRepo.Object, mockDAO.Object, mockAuditLog.Object);
            // Note that we're not setting CreatedDate
            var myObject = new MyObject { Id = Guid.NewGuid(), Name = "UnitTest" }; 
            myBLL.AddMyObject(myObject);

            // Compare the received object with the expected
            mockRepo.Verify(repo => repo.Add(It.Is<MyObject>(item =>
                item.Id == myObject.Id &&
                item.Name == myObject.Name &&
                item.Created != default(DateTime)
            )));
        }

        [Fact(DisplayName = "Calling add should be audited.")]
        public void CallingAddShouldBeAudited()
        {
            var mockRepo = new Mock<IMyObjectRepository>();
            var mockDAO = new Mock<IMyObjectDAO>();
            var mockAuditLog = new Mock<IAuditLogger>();

            var myBLL = new MyObjectLogic(mockRepo.Object, mockDAO.Object, mockAuditLog.Object);
            myBLL.AddMyObject(new MyObject { Id = Guid.NewGuid(), Name = "UnitTest", Created = new DateTime(2015, 2, 21) });

            // We expect a message that starts with "Adding item "
            mockAuditLog.Verify(auditLog => auditLog.Log(It.Is<String>(s => s == "Adding item {0}"), It.IsAny<Guid>()));
        }

        [Fact(DisplayName = "Calling add with a null should throw")]
        public void CallingAddWithANullShouldThrow()
        {
            var mockRepo = new Mock<IMyObjectRepository>();
            var mockDAO = new Mock<IMyObjectDAO>();
            var mockAuditLog = new Mock<IAuditLogger>();

            var myBLL = new MyObjectLogic(mockRepo.Object, mockDAO.Object, mockAuditLog.Object);
            Assert.Throws<ArgumentNullException>( () => myBLL.AddMyObject(null) );
        }

        [Fact(DisplayName = "Calling add with an invalid object should throw")]
        public void CallingAddWithAnInvalidObjectShouldThrow()
        {
            var mockRepo = new Mock<IMyObjectRepository>();
            var mockDAO = new Mock<IMyObjectDAO>();
            var mockAuditLog = new Mock<IAuditLogger>();

            var myBLL = new MyObjectLogic(mockRepo.Object, mockDAO.Object, mockAuditLog.Object);
            Assert.Throws<ValidationException>(() => 
                myBLL.AddMyObject(
                new MyObject { 
                    Id = Guid.NewGuid(),
                    Name = null,
                    Created = new DateTime(2015, 2, 21) }
            ));
        }
    }
}
