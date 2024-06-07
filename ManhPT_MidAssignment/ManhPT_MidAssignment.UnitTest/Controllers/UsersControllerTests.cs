using ManhPT_MidAssignment.API.Controllers;
using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ManhPT_MidAssignment.UnitTest.Controllers
{
    public class UsersControllerTests
    {
        private Mock<IUserService> _mockUserService;
        private UsersController _controller;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UsersController(_mockUserService.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnsOkResult_WithUserDto()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedDto = new UserDTO();
            _mockUserService.Setup(service => service.GetByIdAsync(userId)).ReturnsAsync(expectedDto);

            // Act
            var result = await _controller.GetByIdAsync(userId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(expectedDto));
        }

        [Test]
        public async Task LoginAsync_ReturnsOkResult_WithLoginResponse()
        {
            // Arrange
            var loginDto = new LoginDTO();
            var expectedResponse = new LoginResponse(true);
            _mockUserService.Setup(service => service.LoginAsync(loginDto)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.LoginAsync(loginDto);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(expectedResponse));
        }

        [Test]
        public async Task RegisterAsync_ReturnsOkResult_WithRegistrationResponse()
        {
            // Arrange
            var registerDto = new RegisterUserDto();
            var expectedResponse = new RegistrationResponse(true);
            _mockUserService.Setup(service => service.RegisterAsync(registerDto)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.RegisterAsync(registerDto);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(expectedResponse));
        }
    }
}
