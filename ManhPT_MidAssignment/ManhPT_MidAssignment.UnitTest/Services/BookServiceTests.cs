using AutoMapper;
using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Services.BookService;
using ManhPT_MidAssignment.Domain.Entity;
using Moq;

namespace ManhPT_MidAssignment.UnitTest.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        private Mock<IBookRepo> _bookRepoMock;
        private Mock<IMapper> _mapperMock;
        private BookService _bookService;

        [SetUp]
        public void SetUp()
        {
            _bookRepoMock = new Mock<IBookRepo>();
            _mapperMock = new Mock<IMapper>();
            _bookService = new BookService(_bookRepoMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetByCategory_CategoryExists_ReturnsBooks()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var books = new List<Book> { new() { Id = Guid.NewGuid(), Title = "Test Book" } };
            var bookDtos = new List<BookDTO> { new() { Id = Guid.NewGuid(), Title = "Test Book" } };
            _bookRepoMock.Setup(repo => repo.GetByCategoryAsync(categoryId)).ReturnsAsync(books);
            _mapperMock.Setup(m => m.Map<IEnumerable<BookDTO>>(books)).Returns(bookDtos);

            // Act
            var result = await _bookService.GetByCategoryAsync(categoryId);

            // Assert
            Assert.That(result, Is.EqualTo(bookDtos));
            _bookRepoMock.Verify(repo => repo.GetByCategoryAsync(categoryId), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<BookDTO>>(books), Times.Once);
        }

        [Test]
        public async Task GetFilterAsync_FilterRequest_ReturnsFilteredBooks()
        {
            // Arrange
            var filterRequest = new FilterRequest(SearchTerm: "", SortColumn: "", SortOrder: "", Page: 1, PageSize: 10);
            var books = new List<Book> { new() { Id = Guid.NewGuid(), Title = "Test Book" } };
            var paginatedBooks = new PaginationResponse<Book>(books, 1);
            var bookDtos = new List<BookDTO> { new() { Id = Guid.NewGuid(), Title = "Test Book" } };
            _bookRepoMock.Setup(repo => repo.GetFilterAsync(filterRequest)).ReturnsAsync(paginatedBooks);
            _mapperMock.Setup(m => m.Map<IEnumerable<BookDTO>>(books)).Returns(bookDtos);

            // Act
            var result = await _bookService.GetFilterAsync(filterRequest);

            // Assert
            Assert.That(result.TotalCount, Is.EqualTo(1));
            Assert.That(result.Data, Is.EqualTo(bookDtos));
            _bookRepoMock.Verify(repo => repo.GetFilterAsync(filterRequest), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<BookDTO>>(books), Times.Once);
        }

        [Test]
        public async Task ValidateDTO_ValidDTO_DoesNothing()
        {
            // Arrange
            var bookCreateDto = new BookCreateDTO { Title = "Test Book", Author = "Test Author" };

            // Act & Assert
            Assert.DoesNotThrowAsync(() => _bookService.ValidateDTO(bookCreateDto));
        }
    }
}