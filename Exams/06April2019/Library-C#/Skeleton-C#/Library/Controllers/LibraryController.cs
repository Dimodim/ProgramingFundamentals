using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using(var db = new LibraryDbContext())
            {
                var allBooks = db.Books.ToList();
                return View(allBooks);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title,string author,double price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author)||price<=0)
            {
                return RedirectToAction("Index");
            }
            Book task = new Book
            {
                Title = title,
                Author = author,
                Price = price
            };
            using (var db = new LibraryDbContext())
            {
                db.Books.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var booksToEdit = db.Books.FirstOrDefault(t => t.Id == id);
                if (booksToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(booksToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Books.FirstOrDefault(t => t.Id == book.Id);
                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.Price = book.Price;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelete = db.Books.Find(id);
                if (bookToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return View(bookToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {

                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}