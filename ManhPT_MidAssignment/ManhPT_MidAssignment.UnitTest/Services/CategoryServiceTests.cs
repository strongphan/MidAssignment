using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Services.CategoryService;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Exceptions;
using Moq;

namespace ManhPT_MidAssignment.UnitTest.Services
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mock<ICategoryRepo> _mockCategoryRepo;
        private Mock<IBookRepo> _mockBookRepo;
        private Mock<IMapper> _mockMapper;
        private CategoryService _service;

        [SetUp]
        public void SetUp()
        {
            _mockCategoryRepo = new Mock<ICategoryRepo>();
            _mockBookRepo = new Mock<IBookRepo>();
            _mockMapper = new Mock<IMapper>();
            _service = new CategoryService(_mockCategoryRepo.Object, _mockMapper.Object, _mockBookRepo.Object);
        }

        [Test]
        public async Task DeleteAsync_CategoryWithoutBooks_CallsBaseDeleteAsync()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var category = new Category();
            _mockBookRepo.Setup(repo => repo.GetByCategoryAsync(categoryId)).ReturnsAsync(null as List<Book>);
            _mockCategoryRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(category);

            // Act
            await _service.DeleteAsync(categoryId);

            // Assert
            _mockCategoryRepo.Verify(repo => repo.DeleteAsync(It.IsAny<Category>()), Times.Once);
        }

        [Test]
        public void DeleteAsync_CategoryWithBooks_ThrowsDataInvalidException()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var books = new List<Book> { new Book { Id = Guid.NewGuid() } };

            _mockBookRepo.Setup(repo => repo.GetByCategoryAsync(categoryId)).ReturnsAsync(books);

            // Assert
            Assert.ThrowsAsync<DataInvalidException>(() => _service.DeleteAsync(categoryId));
        }

        [Test]
        public async Task ValidateDTO_ValidatesSuccessfully()
        {
            // Arrange
            var categoryCreateDTO = new CategoryCreateDTO();

            // Act
            await _service.ValidateDTO(categoryCreateDTO);

            // Assert
            Assert.Pass();
        }


        [Test]
        public async Task DeleteAsync_CategoryExists_ShouldDeleteCategory()
        {
            var categoryId = Guid.NewGuid();
            var category = new Category { Id = categoryId };
            _mockBookRepo.Setup(repo => repo.GetByCategoryAsync(categoryId)).ReturnsAsync(null as List<Book>);
            _mockCategoryRepo.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync(category);

            await _service.DeleteAsync(categoryId);

            _mockCategoryRepo.Verify(r => r.DeleteAsync(category), Times.Once);
        }

        [Test]
        public void DeleteAsync_CategoryDoesNotExist_ShouldThrowNotFoundException()
        {
            var categoryId = Guid.NewGuid();
            _mockBookRepo.Setup(repo => repo.GetByCategoryAsync(categoryId)).ReturnsAsync(null as List<Book>);
            _mockCategoryRepo.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync(null as Category);

            Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(categoryId));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCategories()
        {
            var categories = new List<Category> { new Category(), new Category() };
            var categoryDtos = new List<CategoryDTO> { new CategoryDTO(), new CategoryDTO() };

            _mockCategoryRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
            _mockMapper.Setup(m => m.Map<IEnumerable<CategoryDTO>>(categories)).Returns(categoryDtos);

            var result = await _service.GetAllAsync();

            Assert.That(result, Is.EqualTo(categoryDtos));
        }

        [Test]
        public async Task GetByIdAsync_CategoryExists_ShouldReturnCategoryDTO()
        {
            var categoryId = Guid.NewGuid();
            var category = new Category { Id = categoryId };
            var categoryDto = new CategoryDTO { Id = categoryId };

            _mockCategoryRepo.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync(category);
            _mockMapper.Setup(m => m.Map<CategoryDTO>(category)).Returns(categoryDto);

            var result = await _service.GetByIdAsync(categoryId);

            Assert.That(result, Is.EqualTo(categoryDto));
        }

        [Test]
        public void GetByIdAsync_CategoryDoesNotExist_ShouldThrowNotFoundException()
        {
            var categoryId = Guid.NewGuid();

            _mockCategoryRepo.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync((Category)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(categoryId));
        }

        [Test]
        public async Task InsertAsync_ShouldInsertCategory()
        {
            var categoryCreateDto = new CategoryCreateDTO();
            var category = new Category();

            _mockMapper.Setup(m => m.Map<Category>(categoryCreateDto)).Returns(category);

            await _service.InsertAsync(categoryCreateDto, "testUser");

            _mockCategoryRepo.Verify(r => r.InsertAsync(category), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_CategoryExists_ShouldUpdateCategory()
        {
            var categoryId = Guid.NewGuid();
            var categoryCreateDto = new CategoryCreateDTO();
            var category = new Category { Id = categoryId };

            _mockCategoryRepo.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync(category);
            _mockMapper.Setup(m => m.Map<Category>(categoryCreateDto)).Returns(category);

            await _service.UpdateAsync(categoryId, categoryCreateDto, "testUser");

            _mockCategoryRepo.Verify(r => r.UpdateAsync(category), Times.Once);
        }

        [Test]
        public void UpdateAsync_CategoryDoesNotExist_ShouldThrowNotFoundException()
        {
            var categoryId = Guid.NewGuid();
            var categoryCreateDto = new CategoryCreateDTO();

            _mockCategoryRepo.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync((Category)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(categoryId, categoryCreateDto, "testUser"));
        }

    }
}