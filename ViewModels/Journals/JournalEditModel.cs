using BooksDestination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.ViewModels.Journals
{
    public class JournalEditModel
    {
        public string JName { get; set; }
        public string JSubject { get; set; }

        public JournalType Jtype { get; set; }
    }
}
