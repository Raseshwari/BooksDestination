using BooksDestination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.ViewModels.Books
{
    public class BookDetailsViewModel
    {
        public IEnumerable<BookRepo> Books{ get; set; }

        public string Abstract { get; set; }
    }
}
