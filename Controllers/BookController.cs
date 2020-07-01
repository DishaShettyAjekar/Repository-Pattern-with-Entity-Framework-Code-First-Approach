using EF_Example.DAL;
using EF_Example.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_Example.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;
        public BookController()
        {
            _bookRepository = new BookRepository(new BookContext());
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = from book in _bookRepository.GetBooks() select book;
            return View(books);
        }

        public ActionResult Details(int id)
        {
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.InsertBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.UpdateBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Book book = _bookRepository.GetBookById(id);
                _bookRepository.DeleteBook(id);
                _bookRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
                        { "id", id },
                        { "saveChangesError", true }
                   });
            }
                return RedirectToAction("Index");
        }
    }
}