using BooksDestination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Services
{
    public interface IBookData
    {
        IEnumerable<BookRepo> GetAll();

        BookRepo GetBookById(int id);

        BookRepo AddBook(BookRepo book);
    }
}
