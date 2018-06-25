using BooksDestination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.ViewModels.BooksAndJournal
{
    public class BooksAndJournalDetailsModel
    {
        public IEnumerable<BookRepo> Books { get; set; }

        public IEnumerable<BooksDestination.Model.Journals> Journals { get; set; }

    }
}
