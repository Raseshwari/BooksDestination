using BooksDestination.Services;
using BooksDestination.ViewModels.BooksAndJournal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Controllers
{
    public class HomeController: Controller
    {
        private IBookData _bookData;
        private IJournalData _journalData;

        public HomeController(IBookData bookData, IJournalData journalData)
        {
            _bookData = bookData;
            _journalData = journalData;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult AllDetails()
        {
            var model = new BooksAndJournalDetailsModel();
            model.Books = _bookData.GetAll();
            model.Journals = _journalData.GetAllJournals();
            return View(model);
        }
    }
}
