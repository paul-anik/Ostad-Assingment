using BookApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Data
{
    public static class BookRepository
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", PublishedYear = 1949 },
            new Book { Id = 2, Title = "Brave New World", Author = "Aldous Huxley", PublishedYear = 1932 },
            new Book { Id = 3, Title = "Fahrenheit 451", Author = "Ray Bradbury", PublishedYear = 1953 }
        };

        public static List<Book> GetAll() => _books;

        public static Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
    }
}
