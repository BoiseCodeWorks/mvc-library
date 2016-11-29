using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLibrary.Models;

namespace MVCLibrary.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryContext _db;
        public LibraryController(LibraryContext libraryContext)
        {
            _db = libraryContext;
        }

        public IActionResult Index()
        {
            var libraries = _db.Libraries.ToList();
            return View(libraries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Library library)
        {
            _db.Libraries.Add(library);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/library/{libraryId}/books")]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost("/library/{libraryId}/books")]
        public IActionResult AddBook(int libraryId, Book book)
        {
            var library = GetLibrary(libraryId);

            if (library == null)
            {
                return NotFound("This library does not exists");
            }
            book.LibraryId = libraryId;
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var library = _db.Libraries.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            return View(library);
        }

        private Library GetLibrary(int id)
        {
            return _db.Libraries.Find(id);
        }
    }
}