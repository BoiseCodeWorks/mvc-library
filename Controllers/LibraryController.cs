using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCLibrary.Models;

namespace MVCLibrary.Controllers
{
    public class LibraryController : Controller
    {

        private static Library library = new Library("Wan Shi Tong's Mysterious Library", "The Si Wong Desert (Desert of the Dead)");

        public IActionResult Index()
        {
            return View(library);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(string title, string author)
        {
            library.AddBook(new Book(title, author));
            return RedirectToAction("Index");
        }
    }
}