//using BookStore.Application.Interfaces;
//using BookStore.Application.Services;
//using BookStore.Domain.Entities;
//using Moq;

//namespace BookStore.Tests;

//public class UnitTest1
//{
//    [Fact]
//    public void Test1()
//    {

//    }
//}
using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using BookStore.Domain.Entities;
using Moq;

namespace BookStore.Tests;

public class BookServiceTests
{
    [Fact]
    public async Task GetBookByIdAsync_WhenBookExists_ReturnsBookDto()
    {
        // Arrange
        var bookId = Guid.NewGuid();

        var book = new Book
        {
            Id = bookId,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Price = 500,
            Stock = 10,
            ISBN = "9780132350884",
            CreatedAt = DateTime.UtcNow
        };

        var repositoryMock = new Mock<IBookRepository>();

        repositoryMock
            .Setup(repo => repo.GetByIdAsync(bookId))
            .ReturnsAsync(book);

        var service = new BookService(repositoryMock.Object);

        // Act
        var result = await service.GetBookByIdAsync(bookId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bookId, result.Id);
        Assert.Equal("Clean Code", result.Title);
        Assert.Equal("Robert C. Martin", result.Author);
        Assert.Equal(500, result.Price);
        Assert.Equal(10, result.Stock);

        repositoryMock.Verify(
            repo => repo.GetByIdAsync(bookId),
            Times.Once);
    }

    [Fact]
    public async Task GetBookByIdAsync_WhenBookDoesNotExist_ReturnsNull()
    {
        // Arrange
        var bookId = Guid.NewGuid();

        var repositoryMock = new Mock<IBookRepository>();

        repositoryMock
            .Setup(repo => repo.GetByIdAsync(bookId))
            .ReturnsAsync((Book?)null);

        var service = new BookService(repositoryMock.Object);

        // Act
        var result = await service.GetBookByIdAsync(bookId);

        // Assert
        Assert.Null(result);

        repositoryMock.Verify(
            repo => repo.GetByIdAsync(bookId),
            Times.Once);
    }
}