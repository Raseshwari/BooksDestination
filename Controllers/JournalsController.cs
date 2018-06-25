using BooksDestination.Model;
using BooksDestination.Services;
using BooksDestination.ViewModels.Journals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Controllers
{
    public class JournalsController : Controller
    {
        private IJournalData _journaldata;

        public JournalsController(IJournalData journalData)
        {
            _journaldata = journalData;
        }

        public IActionResult Details()
        {
            var model = _journaldata.GetAllJournals();
            return View(model);
        }

        public IActionResult Info(int id)
        {
            var model = _journaldata.GetJournalById(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Details));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JournalEditModel journalEditModel)
        {
            if (ModelState.IsValid)
            {
                var newJournal = new Journals();
                newJournal.JName = journalEditModel.JName;
                newJournal.JSubject = journalEditModel.JSubject;
                newJournal.Jtype = journalEditModel.Jtype;

                newJournal = _journaldata.AddJournal(newJournal);
                return RedirectToAction(nameof(Info), new { id = newJournal.JournalId });
            }
            else
            {
                return View();
            }
        }
    }
}
