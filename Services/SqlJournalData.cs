using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksDestination.Data;
using BooksDestination.Model;

namespace BooksDestination.Services
{
    public class SqlJournalData : IJournalData
    {
        private BooksDestinationDbContext _context;

        public SqlJournalData(BooksDestinationDbContext context)
        {
            _context = context;
        }
        public Journals AddJournal(Journals journal)
        {
            _context.Journals.Add(journal);
            _context.SaveChanges();
            return journal;
        }

        public IEnumerable<Journals> GetAllJournals()
        {
            return _context.Journals.OrderBy(j => j.JournalId);
        }

        public Journals GetJournalById(int id)
        {
            return _context.Journals.FirstOrDefault(j => j.JournalId == id);
        }
    }
}
