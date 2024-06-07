using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Application.Services.BorrowRequestService;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Enum;
using ManhPT_MidAssignment.Domain.Exceptions;
using Moq;

namespace ManhPT_MidAssignment.UnitTest.Services
{
    [TestFixture]
    public class BorrowRequestServiceTests
    {
        private Mock<IBookBorrowingRequestRepo> _mockBorrowingRequestRepo;
        private Mock<IBookRepo> _mockBookRepo;
        private Mock<IMapper> _mockMapper;
        private BorrowRequestService _service;

        [SetUp]
        public void SetUp()
        {
            _mockBorrowingRequestRepo = new Mock<IBookBorrowingRequestRepo>();
            _mockBookRepo = new Mock<IBookRepo>();
            _mockMapper = new Mock<IMapper>();
            _service = new BorrowRequestService(_mockBorrowingRequestRepo.Object, _mockBookRepo.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetByIdAsync_EntityExists_ReturnsDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new BookBorrowingRequest { Id = id };
            var dto = new BorrowingRequestDTO { Id = id };

            _mockBorrowingRequestRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(entity);
            _mockMapper.Setup(mapper => mapper.Map<BorrowingRequestDTO>(entity)).Returns(dto);

            // act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.That(result, Is.EqualTo(dto));
        }

        [Test]
        public void GetByIdAsync_EntityDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockBorrowingRequestRepo.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(null as BookBorrowingRequest);

            // Assert
            Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(id));
        }

        [Test]
        public async Task BorrowBooksAsync_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var bookIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
            var newRequestId = Guid.NewGuid();

            _mockBorrowingRequestRepo.Setup(repo => repo.GetRequestsByUserAndMonthAsync(userId, It.IsAny<int>()))
                .ReturnsAsync(new List<BookBorrowingRequest>());
            _mockBorrowingRequestRepo.Setup(repo => repo.InsertAsync(It.IsAny<BookBorrowingRequest>()))
                .Callback<BookBorrowingRequest>(request => request.Id = newRequestId)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.BorrowBooksAsync(userId, userName, bookIds);

            // Assert
            Assert.That(result, Is.EqualTo($"Request submitted. Status: {Status.Waiting}"));
            _mockBorrowingRequestRepo.Verify(repo => repo.InsertAsync(It.IsAny<BookBorrowingRequest>()), Times.Once);
        }

        [Test]
        public void BorrowBooksAsync_TooManyBooks_ThrowsDataInvalidException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var bookIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            // Assert
            Assert.ThrowsAsync<DataInvalidException>(() => _service.BorrowBooksAsync(userId, userName, bookIds));
        }
        [Test]
        public void BorrowBooksAsync_TooManyRequest_ThrowsDataInvalidException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var bookIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            _mockBorrowingRequestRepo.Setup(repo => repo.GetRequestsByUserAndMonthAsync(userId, It.IsAny<int>()))
                        .ReturnsAsync([new (),
                            new (),
                            new (),
                            new () ]);
            // Assert
            Assert.ThrowsAsync<DataInvalidException>(() => _service.BorrowBooksAsync(userId, userName, bookIds));
        }

        [Test]
        public async Task UpdateRequestStatusAsync_StatusWaiting_Approved_ReturnsTrue()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var requestId = Guid.NewGuid();
            var status = Status.Approved;

            var borrowingRequest = new BookBorrowingRequest
            {
                Id = requestId,
                Status = Status.Waiting,
                BookBorrowingRequestDetails =
                [
                    new() {
                        Book = new Book { AvailableCopies = 2 },
                        Quantity = 1
                    }
                ]
            };

            _mockBorrowingRequestRepo.Setup(repo => repo.GetByIdAsync(requestId)).ReturnsAsync(borrowingRequest);
            _mockBookRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);
            _mockBorrowingRequestRepo.Setup(repo => repo.UpdateAsync(borrowingRequest)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.UpdateRequestStatusAsync(userId, userName, requestId, status);

            // Assert
            Assert.Multiple(() =>
            {

                Assert.That(result, Is.True);
                Assert.That(borrowingRequest.Status, Is.EqualTo(Status.Approved));
            });
            _mockBorrowingRequestRepo.Verify(repo => repo.UpdateAsync(borrowingRequest), Times.Once);
            _mockBookRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Book>()), Times.Once);
        }

        [Test]
        public async Task UpdateRequestStatusAsync_StatusWaiting_NotEnoughCopies_ThrowsDataInvalidException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var requestId = Guid.NewGuid();
            var status = Status.Approved;

            var borrowingRequest = new BookBorrowingRequest
            {
                Id = requestId,
                Status = Status.Waiting,
                BookBorrowingRequestDetails =
                [
                    new() {
                        Book = new Book { AvailableCopies = 0 },
                        Quantity = 1
                    }
                 ]
            };

            _mockBorrowingRequestRepo.Setup(repo => repo.GetByIdAsync(requestId)).ReturnsAsync(borrowingRequest);

            // Assert
            Assert.ThrowsAsync<DataInvalidException>(() => _service.UpdateRequestStatusAsync(userId, userName, requestId, status));
        }
        [Test]
        public async Task ConfirmReturned_ValidRequest_ReturnsTrue()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var requestId = Guid.NewGuid();
            var request = new BookBorrowingRequest
            {
                Id = requestId,
                IsReturn = false,
                BookBorrowingRequestDetails =
                [
                    new() {
                        Book = new Book { AvailableCopies = 1 },
                        Quantity = 1
                    }
                ]
            };

            _mockBorrowingRequestRepo.Setup(repo => repo.GetByIdAsync(requestId)).ReturnsAsync(request);
            _mockBookRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);
            _mockBorrowingRequestRepo.Setup(repo => repo.UpdateAsync(request)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.ConfirmReturnedAsync(userId, userName, requestId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(request.IsReturn, Is.True);
            });
            _mockBorrowingRequestRepo.Verify(repo => repo.UpdateAsync(request), Times.Once);
            _mockBookRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Book>()), Times.Once);
        }

        [Test]
        public void ConfirmReturned_AlreadyReturned_ReturnsFalse()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "testuser";
            var requestId = Guid.NewGuid();
            var request = new BookBorrowingRequest { Id = requestId, IsReturn = true };

            _mockBorrowingRequestRepo.Setup(repo => repo.GetByIdAsync(requestId)).ReturnsAsync(request);

            // Act
            var result = _service.ConfirmReturnedAsync(userId, userName, requestId).Result;

            // Assert
            Assert.That(result, Is.False);
            _mockBorrowingRequestRepo.Verify(repo => repo.UpdateAsync(It.IsAny<BookBorrowingRequest>()), Times.Never);
        }
    }
}
