

using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Controllers;
using SalesWebsite.Backend.Services;
using SalesWebsite.Shared;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Enum;
using SalesWebsite.ViewModels;
using System.Net;

namespace SalesWebsite.UnitTest
{

    public class CategoryControllerTest
    {
        CategoryController controller;
        Mock<ICategoryService> categoryServiceMock;
        CategoryCriteriaDto CategoryCriteriaDtoQuery = new CategoryCriteriaDto()
        {
            Limit = 10,
            Page = 1,
            Search = "",
            SortColumn = "Id",
            SortOrder = SortOrderEnum.Ascending,
        };

        List<CategoryDto> CategoriesExpected = new List<CategoryDto>()
        {
            new CategoryDto() {Id = 1, Name = "Category 1", Description = "Description 1"},
            new CategoryDto() {Id = 2, Name = "Category 2", Description = "Description 2"},
            new CategoryDto() {Id = 3, Name = "Category 3", Description = "Description 3"},
        };

        CategoryVm categoryVmReturn = new CategoryVm()
        {
            Id = 1,
            Name = $"Category {1}",
            Description = $"Description {1}"
        };

        [Fact]
        public async Task Get_Categories_ReturnOK()
        {
            // Arrange
            var pagedResponseDto = new PagedResponseDto<CategoryDto>()
            {
                SortOrder = SortOrderEnum.Ascending,
                TotalPages = 1,
                CurrentPage = 1,
                Items = CategoriesExpected
            };

            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.FindAllAsync(CategoryCriteriaDtoQuery))
                                                        .Returns(Task.FromResult(pagedResponseDto));
            controller = new CategoryController(categoryServiceMock.Object);

            // Act
            var result = await controller.FindAllAsync(CategoryCriteriaDtoQuery);
            var categoryActual = result.Items.ToList();

            //Assert
            Assert.Collection(categoryActual,
                category1 => Assert.Equal(category1, CategoriesExpected[0]),
                category2 => Assert.Equal(category2, CategoriesExpected[1]),
                category3 => Assert.Equal(category3, CategoriesExpected[2])
            );

        }

        [Fact]
        public async Task Get_Categories_ReturnNotFound()
        {
            //Arrange
            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.FindAllAsync(CategoryCriteriaDtoQuery))
                                                        .Returns(Task.FromResult(new PagedResponseDto<CategoryDto>()));
            controller = new CategoryController(categoryServiceMock.Object);
            //Act
            var result = await controller.FindAllAsync(CategoryCriteriaDtoQuery);
            //Assert
            Assert.Null(result.Items);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Get_Category_By_ID_ReturnOK(int categoryID)
        {
            //Arrange 
            var expected = CategoriesExpected[categoryID - 1].Id;
            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.FindByID(categoryID)).Returns(Task.FromResult(categoryVmReturn));
            controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.FindByID(categoryID)) as OkObjectResult;
            var data = result.Value as CategoryVm;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(categoryVmReturn, data);
        }


        [Fact]
        public async Task Get_Category_By_ID_ReturnNotFound()
        {
            //Arrange 
            var categoryID = 0;
            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.FindByID(categoryID));
            controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.FindByID(categoryID)) as NotFoundObjectResult;

            //Assert
            
            Assert.Null(result);
        }

        
        [Fact]
        public async Task Create_Category_ReturnOk()
        {
            //Arrange 
            var categoryCreateRequest = new CategoryCreateRequest()
            {
                Name = "Category 1",
                Description = "Description 1"
            };
            
            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.Create(categoryCreateRequest)).Returns(Task.FromResult(categoryVmReturn));

            var controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.Create(categoryCreateRequest)) as OkObjectResult;
            var data = result.Value as CategoryVm;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(categoryVmReturn, data);
        }

        [Fact]
        public async Task Create_Category_BadRequest()
        {
            //Arrange 
            var categoryCreateRequest = new CategoryCreateRequest()
            {
                Name = "",
                Description = "Description 1"
            };

            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.Create(categoryCreateRequest));

            var controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.Create(categoryCreateRequest)) as BadRequestObjectResult;

            //Assert
            
            Assert.Null(result);
        }

        [Fact]
        public async Task Update_Category_ReturnOk()
        {
            //Arrange 
            int categoryId = 1;

            var categoryCreateRequest = new CategoryCreateRequest()
            {
                Name = "Category 1",
                Description = "Description 1"
            };

            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.UpdateAsync(1, categoryCreateRequest)).Returns(Task.FromResult(categoryVmReturn));

            var controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.UpdateAsync(categoryId, categoryCreateRequest)) as OkObjectResult;
            var data = result.Value as CategoryVm;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(categoryVmReturn, data);
        }

        [Fact]
        public async Task Update_Category_ReturnNotFound()
        {
            //Arrange 
            int categoryId = 0;

            var categoryCreateRequest = new CategoryCreateRequest()
            {
                Name = "Category 1",
                Description = "Description 1"
            };

            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.UpdateAsync(0, categoryCreateRequest));

            var controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.UpdateAsync(categoryId, categoryCreateRequest)) as NotFoundObjectResult;

            //Assert
            
            Assert.Null(result);
        }

        [Fact]
        public async Task Delete_Category_ReturnOk()
        {
            //Arrange 
            int categoryId = 1;

            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.DeleteAsync(categoryId)).Returns(Task.FromResult(categoryVmReturn));

            var controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.DeleteAsync(categoryId)) as OkObjectResult;
            var data = result.Value as CategoryVm;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(categoryVmReturn, data);
        }

        [Fact]
        public async Task Delete_Category_ReturnNotFound()
        {
            //Arrange 
            int categoryId = 0;

            categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(service => service.DeleteAsync(categoryId));

            var controller = new CategoryController(categoryServiceMock.Object);

            //Act
            var result = (await controller.DeleteAsync(categoryId)) as NotFoundResult;

            //Assert
            Assert.Equal(StatusCodeConstants.NotFound, result.StatusCode);
        }

        
    }
}
