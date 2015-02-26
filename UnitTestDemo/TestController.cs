using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace SolTech.Demos.UnitTesting
{
    public class TestHomeController
    {
        [Fact(DisplayName = "HomeController: Verify Index is shown by default")]
        public void VerifyIndexIsShownByDefault()
        {
            var mockBLL = new Mock<IMyObjectLogic>();
            var controller = new SolTech.Demos.UnitTesting.Controllers.HomeController(mockBLL.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.Equal(String.Empty, viewResult.ViewName);
        }

        [Fact(DisplayName = "HomeController: Verify Add returns a PartialViewResult with an AddMyObjectModel model")]
        public void VerifyAddReturnsAPartialViewResultWithanAddMyObjectModelModel()
        {
            var mockBLL = new Mock<IMyObjectLogic>();
            var controller = new SolTech.Demos.UnitTesting.Controllers.HomeController(mockBLL.Object);
            var result = controller.Add();
            Assert.IsType<PartialViewResult>(result);
            var partialViewResult = result as PartialViewResult;
            Assert.Equal(String.Empty, partialViewResult.ViewName);
            Assert.NotNull(partialViewResult.Model);
            Assert.IsType<AddMyObjectModel>(partialViewResult.Model);
            var model = partialViewResult.Model as AddMyObjectModel;
            Assert.NotEqual(Guid.Empty, model.Id);
            Assert.NotEqual(default(DateTime), model.Created);
            Assert.True(DateTime.Now >= model.Created);
        }

        [Fact(DisplayName = "Verify sending a valid model to AddMyObjectForm saves the object")]
        public void VerifySendingAValidModelToAddMyObjectFormSavesTheObject()
        {
            var mockBLL = new Mock<IMyObjectLogic>();
            mockBLL.Setup(bll => bll.AddMyObject(It.IsAny<MyObject>()));
            var controller = new SolTech.Demos.UnitTesting.Controllers.HomeController(mockBLL.Object);
            var model = new AddMyObjectModel { Id = Guid.NewGuid(), Name = "UnitTest", Created = new DateTime(2015, 2, 21) };
            var result = controller._AddObjectForm(model);

            // Verify that the method was called with the expected object
            mockBLL.Verify(bll => bll.AddMyObject(It.Is<MyObject>(item => item.Id == model.Id && item.Name == model.Name && item.Created == model.Created)));
        }

        [Fact]
        public void VerifyAddModelValidation_EmptyName()
        {
            var model = new AddMyObjectModel { Id = Guid.NewGuid(), Name = null, Created = new DateTime(2015, 2, 21) };
            var results = new List<ValidationResult>();
            Assert.False(Validator.TryValidateObject(model, new ValidationContext(model), results));
        }

        [Fact(DisplayName = "Verify sending a invalid model to AddMyObjectForm does not save the object")]
        public void VerifySendingAnInvalidModelToAddMyObjectFormDoesNotSaveTheObject()
        {
            var mockBLL = new Mock<IMyObjectLogic>();
            mockBLL.Setup(bll => bll.AddMyObject(It.IsAny<MyObject>()));
            var controller = new SolTech.Demos.UnitTesting.Controllers.HomeController(mockBLL.Object);
            controller.ModelState.AddModelError("Guid", "some error");
            var model = new AddMyObjectModel { Id = Guid.Empty, Name = "UnitTest", Created = new DateTime(2015, 2, 21) };
            var result = controller._AddObjectForm(model);

            // Verify that the method was never called
            mockBLL.Verify(bll => bll.AddMyObject(It.IsAny<MyObject>()), Times.Never);
        }
    }
}
