//using AutoMapper;
//using Common.Interface_Sort_Pag_Flt;
//using Common.Sort_Pag_Flt;
//using DAL.Entities;
//using Model.Common.ProjectManagement;
//using Model.ProjectManagement;
//using Moq;
//using ProjectManagement.Controllers;
//using ProjectManagement.Models.ProjectManagement;
//using Service.Common.ProjectManagement;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http;
//using Xunit;

//namespace ProjectManagement.Tests.Controllers
//{
//    public class OrganizationControllerTest
//    {
//        [Fact]
//        public void GetAll()
//        {
//            //Arrange
//            IPaging pagging = new Paging() { PageNumber = 0, PageSize = 1, TotalPages = 30 };

//            IEnumerable<IOrganizationModel> organizationModel = new List<IOrganizationModel>()
//            { new OrganizationModel { Id = Guid.NewGuid(), Name = "A", Abrv= "a", Address = "Adresa 1", City = "test1", State = "aa", Country = "aa", Email = "test1" },
//                new OrganizationModel { Id = Guid.NewGuid(), Name = "B", Abrv= "b", Address = "Adresa 2", City = "test2", State = "bb", Country = "bb", Email = "test2"  }, 
//                new OrganizationModel { Id = Guid.NewGuid(), Name = "C", Abrv= "c", Address = "Adresa 3", City = "test3", State = "cc", Country = "cc", Email = "test3"  } };

//            IEnumerable<OrganizationViewModel> organizationViewModel = new List<OrganizationViewModel>()
//            { new OrganizationViewModel {  Name = "A", Address = "Adresa 1", City = "test1", State = "aa", Country = "aa", Email = "test1" },
//                new OrganizationViewModel { Name = "B", Address = "Adresa 2", City = "test2", State = "bb", Country = "bb", Email = "test2"  },
//                new OrganizationViewModel { Name = "C", Address = "Adresa 3", City = "test3", State = "cc", Country = "cc", Email = "test3"  } };

//            var id = Guid.NewGuid();
//            var mapper = new Mock<IMapper>();
//            mapper.Setup(x => x.Map<IEnumerable<OrganizationViewModel>>(It.IsAny<IEnumerable<OrganizationModel>>())).Returns(organizationViewModel);

//            var mockService = new Mock<IOrganizationService>();
//            mockService.Setup(x => x.GetAllAsync(id, pagging)).ReturnsAsync(organizationModel);

//            OrganizationController controller = new OrganizationController(mockService.Object, mapper.Object);

//            //act
//            var actual = controller.GetAll(id, pagging.PageNumber, pagging.PageSize);

//            //Assert
//            mockService.Verify();//verify that GetByID was called based on setup.
//            Assert.NotNull(actual);//assert that a result was returned   
//            Assert.IsType<Task<IHttpActionResult>>(actual);
//            Assert.Equal(organizationViewModel, actual.Result);
//        }
//    }
//}
