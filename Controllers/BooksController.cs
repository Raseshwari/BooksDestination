using BooksDestination.Model;
using BooksDestination.Services;
using BooksDestination.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Controllers
{
    public class BooksController : Controller
    {
        private IBookData _bookData;

        public BooksController(IBookData bookData)
        {
            _bookData = bookData;

        }

        public IActionResult Details()
        {
            var model = new BookDetailsViewModel();
            model.Books = _bookData.GetAll();
            model.Abstract = "Books Repository";
            return View(model);
        }

        public IActionResult Info(int id)
        {
            var model = _bookData.GetBookById(id);
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
        public IActionResult Create(BookEditModel bookEditModel)
        {
            if (ModelState.IsValid)
            {
                var newBook = new BookRepo();
                newBook.Name = bookEditModel.Name;
                newBook.Type = bookEditModel.Type;
                newBook = _bookData.AddBook(newBook);
                return RedirectToAction(nameof(Info), new { id = newBook.BookId });

            }
            else
            {
                return View();
            }
        }
    }
}
