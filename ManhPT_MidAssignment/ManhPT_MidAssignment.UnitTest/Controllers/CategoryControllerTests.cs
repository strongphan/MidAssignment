using ManhPT_MidAssignment.API.Controllers;
using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.Services.CategoryService;
using ManhPT_MidAssignment.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace ManhPT_MidAssignment.UnitTest.Controllers
{
    public class CategoryControllerTests
    {
        private Mock<ICategoryService> _mockService;
        private CategoriesController _controller;
        private readonly Guid _userId = Guid.NewGuid();
        private readonly string _userName = "testuser";

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<ICategoryService>();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, _userId.ToString()),
            new Claim(ClaimTypes.Name, _userName),
            new Claim(ClaimTypes.Role, nameof(Role.Admin))
            }, "mock"));

            _controller = new CategoriesController(_mockService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = user }
                }
            };
        }

        [Test]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfDtos()
        {
            // Arrange
            var expectedDtos = new List<CategoryDTO> { new CategoryDTO(), new CategoryDTO() };
            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(expectedDtos);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(expectedDtos));
        }

        [Test]
        public async Task GetByIdAsync_ReturnsOkResult_WithDto()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var expectedDto = new CategoryDTO();
            _mockService.Setup(service => service.GetByIdAsync(categoryId)).ReturnsAsync(expectedDto);

            // Act
            var result = await _controller.GetByIdAsync(categoryId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(expectedDto));
        }

        [Test]
        public async Task InsertAsync_ReturnsOkResult()
        {
            // Arrange
            var createDto = new CategoryCreateDTO();

            // Act
            var result = await _controller.InsertAsync(createDto);

            // Assert
            _mockService.Verify(service => service.InsertAsync(createDto, _userName), Times.Once);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task UpdateAsync_ReturnsOkResult()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var updateDto = new CategoryCreateDTO();

            // Act
            var result = await _controller.UpdateAsync(categoryId, updateDto);

            // Assert
            _mockService.Verify(service => service.UpdateAsync(categoryId, updateDto, _userName), Times.Once);
            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public async Task DeleteAsync_ReturnsOkResult()
        {
            // Arrange
            var categoryId = Guid.NewGuid();

            // Act
            var result = await _controller.DeleteAsync(categoryId);

            // Assert
            _mockService.Verify(service => service.DeleteAsync(categoryId), Times.Once);
            Assert.That(result, Is.InstanceOf<OkResult>());
        }
    }
}
