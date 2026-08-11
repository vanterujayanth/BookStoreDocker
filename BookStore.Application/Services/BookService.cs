using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    { 
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
                ISBN = book.ISBN,
                CreatedAt = book.CreatedAt
            });
        }

        public async Task<BookDto?> GetBookByIdAsync(Guid id)
        {
            var book =await _bookRepository.GetByIdAsync(id);

            if (book == null) 
            {
                return null;
            }
            return new BookDto
            {
                Id=book.Id,
                Title=book.Title,
                Author=book.Author,
                Stock=book.Stock,
                Price=book.Price,
                ISBN=book.ISBN,
                CreatedAt=book.CreatedAt
            };

        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                Price = createBookDto.Price,
                Stock = createBookDto.Stock,
                ISBN = createBookDto.ISBN,
                CreatedAt = DateTime.UtcNow
            };

            var createdBook = await _bookRepository.AddAsync(book);

            return new BookDto
            {
                Id = createdBook.Id,
                Title = createdBook.Title,
                Author = createdBook.Author,
                Price = createdBook.Price,
                Stock = createdBook.Stock,
                ISBN = createdBook.ISBN,
                CreatedAt = createdBook.CreatedAt
            };
        }
        public async Task<BookDto?> UpdateBookAsync(Guid id,UpdateBookDto updateBookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);

            if (existingBook is null)
            {
                return null;
            }

            existingBook.Title = updateBookDto.Title;
            existingBook.Author = updateBookDto.Author;
            existingBook.Price = updateBookDto.Price;
            existingBook.Stock = updateBookDto.Stock;
            existingBook.ISBN = updateBookDto.ISBN;

            var updatedBook = await _bookRepository.UpdateAsync(existingBook);

            return new BookDto
            {
                Id = updatedBook.Id,
                Title = updatedBook.Title,
                Author = updatedBook.Author,
                Price = updatedBook.Price,
                Stock = updatedBook.Stock,
                ISBN = updatedBook.ISBN,
                CreatedAt = updatedBook.CreatedAt
            };
        }
        public async Task<bool> DeleteBookAsync(Guid id)
        {
            return await _bookRepository.DeleteAsync(id);
        }


    }
}
