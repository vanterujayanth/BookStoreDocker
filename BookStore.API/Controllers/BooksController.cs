using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
        {
            var book = await _bookService.CreateBookAsync(createBookDto);

            return CreatedAtAction(
                nameof(GetBookById),
                new { id = book.Id },
                book);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BookDto>> UpdateBook(Guid id,UpdateBookDto updateBookDto)
        {
            var book = await _bookService.UpdateBookAsync(
                id,
                updateBookDto);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
