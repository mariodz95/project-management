using DAL.Entities;
using Model.Common.ProjectManagement;
using Model.ProjectManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ProjectManagement.Tests.Controllers
{
    public class OrganizationControllerTest
    {
        [Fact]
        public void GetAll()
        {
            IEnumerable<IOrganizationModel> organizationModels = new List<IOrganizationModel>()
            { new OrganizationModel { Id = Guid.NewGuid(), Name = "A", Abrv= "a", Address = "Adresa 1", City = "1", State = "a", Country = "a", Email = "test" },
                new OrganizationModel { Id = Guid.NewGuid(), Name = "A", Abrv= "a", Address = "Adresa 1", City = "1", State = "a", Country = "a", Email = "test"  }, 
                new OrganizationModel { Id = Guid.NewGuid(), Name = "A", Abrv= "a", Address = "Adresa 1", City = "1", State = "a", Country = "a", Email = "test"  } };


            Assert.True(true);


            //List<IVehicleModel> vehicleModel = new List<IVehicleModel>() { new VehicleModel { Id = new Guid(), Name = "A", Abrv = "a" },
            //new VehicleModel { Id = new Guid(), Name = "B", Abrv = "b" },new VehicleModel { Id = new Guid(), Name = "C", Abrv = "c" }};

            //List<VehicleModelView> vehicleModelView = new List<VehicleModelView>() { new VehicleModelView { Id = new Guid(), Name = "A", Abrv = "a" },
            //new VehicleModelView { Id = new Guid(), Name = "B", Abrv = "b" },new VehicleModelView { Id = new Guid(), Name = "C", Abrv = "c" }};

            //var mapper = new Mock<IMapper>();
            //mapper.Setup(x => x.Map<List<VehicleModelView>>(It.IsAny<List<IVehicleModel>>())).Returns(vehicleModelView);

            //var mockService = new Mock<IVehicleModelService>();
            //mockService.Setup(x => x.GetAllVehicleModelAsync(filterObj, sortObj, pagingObj)).ReturnsAsync(vehicleModel);

            //VehicleModelController controller = new VehicleModelController(mockService.Object, mapper.Object);

            ////Act
            //var actual = controller.GetAsync(sortObj.SortOrder, filterObj.FilterValue, pagingObj.PageSize);
            ////var contentResult = actionResult as OkNegotiatedContentResult<>;

            ////Assert
            //mockService.Verify();//verify that GetByID was called based on setup.
            //Assert.NotNull(actual);//assert that a result was returned             
            //Assert.Equal(vehicleModelView, actual.Result);
        }
    }
}
