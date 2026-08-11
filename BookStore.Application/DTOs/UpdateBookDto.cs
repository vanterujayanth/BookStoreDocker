using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.DTOs
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ISBN { get; set; } = string.Empty;
    }
}
