using ManhPT_MidAssignment.API.Controllers;
using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ManhPT_MidAssignment.UnitTest.Controllers
{
    [TestFixture]
    public class BooksControllerTests
    {
        private Mock<IBookService> _mockService;
        private BooksController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IBookService>();
            _controller = new BooksController(_mockService.Object);
        }

        [Test]
        public async Task GetFilterAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var filterRequest = new FilterRequest(SearchTerm: "", SortColumn: "", SortOrder: "", Page: 1, PageSize: 10);
            var expectedResponse = new PaginationResponse<BookDTO>([], 1);
            _mockService.Setup(service => service.GetFilterAsync(It.IsAny<FilterRequest>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetFilterAsync(filterRequest);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task GetByCategoryAsync_ValidCategoryId_ReturnsOkResult()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var expectedResponse = new List<BookDTO>(); // Assuming the service returns a list of BookDTO
            _mockService.Setup(service => service.GetByCategoryAsync(categoryId)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetByCategoryAsync(categoryId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }
    }
}
