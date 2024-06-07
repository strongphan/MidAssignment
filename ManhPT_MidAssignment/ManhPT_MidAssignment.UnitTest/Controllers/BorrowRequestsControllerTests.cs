using ManhPT_MidAssignment.API.Controllers;
using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Application.Services.BorrowRequestService;
using ManhPT_MidAssignment.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Internal;
using System.Security.Claims;

namespace ManhPT_MidAssignment.UnitTest.Controllers
{

    [TestFixture]
    public class BorrowRequestsControllerTests
    {
        private Mock<IBorrowRequestService> _mockService;
        private BorrowRequestsController _controller;
        private Guid _userId;
        private string _userName;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IBorrowRequestService>();
            _controller = new BorrowRequestsController(_mockService.Object);

            _userId = Guid.NewGuid();
            _userName = "testuser";

            var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, _userId.ToString()),
            new Claim(ClaimTypes.Name, _userName)
        };

            var identity = new ClaimsIdentity(userClaims, "TestAuth");
            var user = new ClaimsPrincipal(identity);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [Test]
        public async Task GetByIdAsync_ValidId_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDto = new BorrowingRequestDTO(); // Assuming you have a valid BorrowRequestDTO object
            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(expectedDto);

            // Act
            var result = await _controller.GetByIdAsync(id);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedDto));
        }

        [Test]
        public async Task GetRequestAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var filterRequest = new FilterRequest(SearchTerm: "", SortColumn: "", SortOrder: "", Page: 1, PageSize: 10);
            var expectedResponse = new PaginationResponse<BorrowingRequestDTO>([], 1); // Assuming the service returns a list of BorrowRequestDTO
            _mockService.Setup(service => service.GetRequestAsync(filterRequest)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetRequestAsync(filterRequest);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task GetRequestNotReturnedAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var filterRequest = new FilterRequest(SearchTerm: "", SortColumn: "", SortOrder: "", Page: 1, PageSize: 10);
            var expectedResponse = new PaginationResponse<BorrowingRequestDTO>([], 1); // Assuming the service returns a list of BorrowRequestDTO
            _mockService.Setup(service => service.GetRequestNotReturnedAsync(filterRequest)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetRequestNotReturnedAsync(filterRequest);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task GetRequestByRequestorIdAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var filterRequest = new FilterRequest(SearchTerm: "", SortColumn: "", SortOrder: "", Page: 1, PageSize: 10);
            var expectedResponse = new PaginationResponse<BorrowingRequestDTO>([], 1);
            _mockService.Setup(service => service.GetRequestByRequestorIdAsync(filterRequest, requestId)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetRequestNotReturnedAsync(filterRequest, requestId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task BorrowBooksAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var bookIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
            var expectedResponse = ""; // Assuming the service returns a list of BorrowRequestDTO
            _mockService.Setup(service => service.BorrowBooksAsync(_userId, _userName, bookIds)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.BorrowBooksAsync(bookIds);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task UpdateRequestStatusAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var status = new Status(); // Assuming you have a valid Status object
            var expectedResponse = true; // Assuming the service returns a BorrowRequestDTO
            _mockService.Setup(service => service.UpdateRequestStatusAsync(_userId, _userName, requestId, status)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.UpdateRequestStatusAsync(requestId, status);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task ConfirmReturnedAsync_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var expectedResponse = true; // Assuming the service returns a BorrowRequestDTO
            _mockService.Setup(service => service.ConfirmReturnedAsync(_userId, _userName, requestId)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.ConfirmReturnedAsync(requestId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedResponse));
        }
    }
}
