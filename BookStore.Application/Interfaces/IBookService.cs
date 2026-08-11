using BookStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllBooksAsync();

       public Task<BookDto?> GetBookByIdAsync(Guid id);

        public Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);

        public  Task<BookDto?> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto);

        public Task<bool> DeleteBookAsync(Guid id);
    }
}
