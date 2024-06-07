using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Services.TokenService;
using ManhPT_MidAssignment.Application.Services.UserService;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Exceptions;
using Moq;
using System.Security.Claims;

namespace ManhPT_MidAssignment.UnitTest.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepo> _userRepoMock;
        private Mock<ITokenService> _tokenServiceMock;
        private Mock<IMapper> _mapperMock;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userRepoMock = new Mock<IUserRepo>();
            _tokenServiceMock = new Mock<ITokenService>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_userRepoMock.Object, _tokenServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_UserExists_ReturnsUserDto()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId };
            var userDto = new UserDTO { Id = userId };
            _userRepoMock.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
            _mapperMock.Setup(m => m.Map<UserDTO>(user)).Returns(userDto);

            // Act
            var result = await _userService.GetByIdAsync(userId);

            // Assert
            Assert.That(result, Is.EqualTo(userDto));
            _userRepoMock.Verify(repo => repo.GetByIdAsync(userId), Times.Once);
            _mapperMock.Verify(m => m.Map<UserDTO>(user), Times.Once);
        }

        [Test]
        public void GetByIdAsync_UserDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            _userRepoMock.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _userService.GetByIdAsync(userId));
        }

        [Test]
        public async Task FindUserByEmailAsync_UserExists_ReturnsUser()
        {
            // Arrange
            var email = "test@example.com";
            var user = new User { Email = email };
            _userRepoMock.Setup(repo => repo.FindUserByEmailAsync(email)).ReturnsAsync(user);

            // Act
            var result = await _userService.FindUserByEmailAsync(email);

            // Assert
            Assert.That(result, Is.EqualTo(user));
            _userRepoMock.Verify(repo => repo.FindUserByEmailAsync(email), Times.Once);
        }

        [Test]
        public async Task LoginAsync_ValidCredentials_ReturnsSuccessResponse()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password";
            var user = new User { Email = email, Password = BCrypt.Net.BCrypt.HashPassword(password) };
            var token = "jwt_token";
            _userRepoMock.Setup(repo => repo.FindUserByEmailAsync(email)).ReturnsAsync(user);
            // Create a local variable for token
            var tokenValue = token;
            _tokenServiceMock.Setup(service => service.GenerateJWT(It.IsAny<User>(), It.IsAny<IEnumerable<Claim>?>())).Returns(tokenValue);
            var loginDto = new LoginDTO { Email = email, Password = password };

            // Act
            var result = await _userService.LoginAsync(loginDto);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result.Flag, Is.True);
                Assert.That(result.Message, Is.EqualTo("Login success"));
                Assert.That(result.Token, Is.EqualTo(token));
            });
        }

        [Test]
        public async Task LoginAsync_InvalidCredentials_ReturnsFailureResponse()
        {
            // Arrange
            var email = "test@example.com";
            var password = "wrong_password";
            var user = new User { Email = email, Password = BCrypt.Net.BCrypt.HashPassword("password") };
            _userRepoMock.Setup(repo => repo.FindUserByEmailAsync(email)).ReturnsAsync(user);
            var loginDto = new LoginDTO { Email = email, Password = password };

            // Act
            var result = await _userService.LoginAsync(loginDto);

            // Assert
            Assert.That(result.Flag, Is.False);
            Assert.That(result.Message, Is.EqualTo("Invalid credentials"));
        }

        [Test]
        public async Task RegisterAsync_NewUser_ReturnsSuccessResponse()
        {
            // Arrange
            var email = "test@example.com";
            var registerDto = new RegisterUserDto
            {
                Email = email,
                Name = "Test User",
                Password = "password"
            };
            _userRepoMock.Setup(repo => repo.FindUserByEmailAsync(email)).ReturnsAsync((User)null);

            // Act
            var result = await _userService.RegisterAsync(registerDto);

            // Assert
            Assert.That(result.Flag, Is.True);
            Assert.That(result.Message, Is.EqualTo("Register success"));
            _userRepoMock.Verify(repo => repo.InsertAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task RegisterAsync_ExistingUser_ReturnsFailureResponse()
        {
            // Arrange
            var email = "test@example.com";
            var registerDto = new RegisterUserDto
            {
                Email = email,
                Name = "Test User",
                Password = "password"
            };
            var existingUser = new User { Email = email };
            _userRepoMock.Setup(repo => repo.FindUserByEmailAsync(email)).ReturnsAsync(existingUser);

            // Act
            var result = await _userService.RegisterAsync(registerDto);

            // Assert
            Assert.That(result.Flag, Is.False);
            Assert.That(result.Message, Is.EqualTo("User already exist"));
            _userRepoMock.Verify(repo => repo.InsertAsync(It.IsAny<User>()), Times.Never);
        }
    }
}
