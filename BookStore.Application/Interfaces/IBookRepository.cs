using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(Guid id);

        Task<Book> AddAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task<bool> DeleteAsync(Guid id);
    }
}
