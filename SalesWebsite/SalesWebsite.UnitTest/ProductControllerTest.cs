
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Controllers;
using SalesWebsite.Backend.Services;
using SalesWebsite.Shared;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.Shared.Enum;
using SalesWebsite.ViewModels;
using System.Net;
namespace SalesWebsite.UnitTest
{
    public class ProductControllerTest
    {
        private ProductController controller;
        private Mock<IProductService> productServiceMock;
        ProductCriteriaDto productCriteriaRequest = new ProductCriteriaDto()
        {
            Limit = 10,
            Page = 1,
            Search = "",
            SortColumn = "Id",
            SortOrder = SortOrderEnum.Ascending,
        };


        List<ProductDto> ProductsExpected = new List<ProductDto>()
        {
            new ProductDto() {Id = 1, Name = "Product 1", Price = 1000, Quantity = 100},
            new ProductDto() {Id = 2, Name = "Product 2", Price = 2000, Quantity = 200},
            new ProductDto() {Id = 3, Name = "Product 3", Price = 3000, Quantity = 300}

        };

        ProductVm productVmReturn = new ProductVm()
        {
            Id = 1,
            Name = "Product 1",
            Price = 1000,
            Quantity = 100,
        };

        [Fact]
        public async Task Get_Product_ReturnOk()
        {
            // Arrange
            var pagedResponseDto = new PagedResponseDto<ProductDto>()
            {
                SortOrder = SortOrderEnum.Ascending,
                TotalPages = 1,
                CurrentPage = 1,
                Items = ProductsExpected
            };

            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.FindAllAsync(productCriteriaRequest))
                                                        .Returns(Task.FromResult(pagedResponseDto));
            controller = new ProductController(productServiceMock.Object);

            // Act
            var result = await controller.FindAllAsync(productCriteriaRequest);
            var productActual = result.Items.ToList();

            //Assert
            Assert.Collection(productActual,
                product1 => Assert.Equal(product1, ProductsExpected[0]),
                product2 => Assert.Equal(product2, ProductsExpected[1]),
                product3 => Assert.Equal(product3, ProductsExpected[2])
            );
        }

        [Fact]
        public async Task Get_Product_ReturnNotFound()
        {
            //Arrange
            var pagedResponseDto = new PagedResponseDto<ProductDto>()
            {
                SortOrder = SortOrderEnum.Ascending,
                TotalPages = 1,
                CurrentPage = 1,
                Items = ProductsExpected
            };

            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.FindAllAsync(productCriteriaRequest));
                                                       
            controller = new ProductController(productServiceMock.Object);

            // Act
            var result = await controller.FindAllAsync(productCriteriaRequest);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task Get_Product_By_Id_ReturnOk()
        {
            //Arrange
            int productId = 1;
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.FindById(productId)).Returns(Task.FromResult(productVmReturn));

            controller = new ProductController(productServiceMock.Object);
            // Act
            var result = (await controller.FindById(productId)) as OkObjectResult;
            var data = result.Value as ProductVm;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(productVmReturn, data);        
        }

        [Fact]
        public async Task Get_Product_By_Id_ReturnNotFournd()
        {
            //Arrange
            int productId = 0;
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.FindById(productId));
            controller = new ProductController(productServiceMock.Object);
            // Act
            var result = (await controller.FindById(productId)) as NotFoundObjectResult;
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Create_Product_ReturnOk()
        {
            //Arrange
            var productCreateRequest = new ProductCreateRequest()
            {
                CategoryId = 1,
                Price = 1000,
                Sold = 1000
            };
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.CreateAsync(productCreateRequest)).Returns(Task.FromResult(productVmReturn));

            controller = new ProductController(productServiceMock.Object);
            // Act
            var result = (await controller.CreateAsync(productCreateRequest)) as OkObjectResult;
            var data = result.Value as ProductVm;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(productVmReturn, data);
        }

        [Fact]
        public async Task Create_Product_ReturnBadRequest()
        {
            //Arrange
            var productCreateRequest = new ProductCreateRequest()
            {
                CategoryId = 1,
                Price = 1000,
                Sold = 1000
            };
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.CreateAsync(productCreateRequest));

            controller = new ProductController(productServiceMock.Object);
            // Act
            var result = (await controller.CreateAsync(productCreateRequest)) as BadRequestObjectResult;
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Update_Product_ReturnOk()
        {
            //Arrange
            int productID = 1;
            var productCreateRequest = new ProductCreateRequest()
            {
                CategoryId = 1,
                Price = 1000,
                Sold = 1000
            };
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.UpdateAsync(productID, productCreateRequest)).Returns(Task.FromResult(productVmReturn));

            controller = new ProductController(productServiceMock.Object);
            // Act
            var result = (await controller.UpdateAsync(productID, productCreateRequest)) as OkObjectResult;
            var data = result.Value as ProductVm;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(productVmReturn, data);
        }

        [Fact]
        public async Task Update_Product_ReturnNotFound()
        {
            //Arrange
            int productID = 0;
            var productCreateRequest = new ProductCreateRequest()
            {
                CategoryId = 1,
                Price = 1000,
                Sold = 1000
            };
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.UpdateAsync(productID, productCreateRequest));

            controller = new ProductController(productServiceMock.Object);
            // Act
            var result = (await controller.UpdateAsync(productID, productCreateRequest)) as NotFoundObjectResult;
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Delete_Product_ReturnOk()
        {
            //Arrange
            int productID = 1;
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.DeleteAsync(productID)).Returns(Task.FromResult(productVmReturn));
            controller = new ProductController(productServiceMock.Object);

            // Act
            var result = (await controller.DeleteAsync(productID)) as OkObjectResult;
            var data = result.Value as ProductVm;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodeConstants.Success, result.StatusCode);
            Assert.Equal(productVmReturn, data);
        }

        [Fact]
        public async Task Delete_Product_ReturnNotFound()
        {
            //Arrange
            int productID = 1;
            productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.DeleteAsync(productID));
            controller = new ProductController(productServiceMock.Object);

            // Act
            var result = (await controller.DeleteAsync(productID)) as NotFoundObjectResult;

            // Assert
            Assert.Null(result);
        }


    }
}