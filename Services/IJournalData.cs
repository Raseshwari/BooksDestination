using BooksDestination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Services
{
    public interface IJournalData
    {
        IEnumerable<Journals> GetAllJournals();

        Journals GetJournalById(int id);

        Journals AddJournal(Journals journal);
    }

    public class InMemoryJournalData : IJournalData
    {
        private List<Journals> _journals;

        public InMemoryJournalData()
        {
            _journals = new List<Journals>
            {
                new Journals{ JournalId = 450, JName="Astro Physics", JSubject="Physics"},
                new Journals{ JournalId = 600, JName="Chemical Bonds", JSubject="Chemistry"},
                new Journals{ JournalId = 333, JName="Heart Matters", JSubject="Biology"}
            };
        }

        public Journals AddJournal(Journals journal)
        {
            journal.JournalId = _journals.Max(j => j.JournalId) + 1;
            _journals.Add(journal);
            return journal;
        }

        public IEnumerable<Journals> GetAllJournals()
        {
            return _journals.OrderBy(j => j.JournalId);
        }

        public Journals GetJournalById(int id)
        {
            return _journals.FirstOrDefault(j => j.JournalId == id);
        }
    }
}
