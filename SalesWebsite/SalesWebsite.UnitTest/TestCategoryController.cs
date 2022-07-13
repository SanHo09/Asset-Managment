

using SalesWebsite.Backend.Controllers;
using SalesWebsite.Backend.Services;

namespace SalesWebsite.UnitTest
{
    public class TestCategoryController
    {
        [Fact]
        public async Task test()
        {
            Mock<ICategoryService> categoryService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(categoryService.Object);
            var a = await controller.FindAllAsync(null);
            Console.WriteLine(a.TotalPages);
            Assert.True(a.TotalPages > 0);
        }

    }
}
