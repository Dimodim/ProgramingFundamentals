using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using BandRegister.Data;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BandRegisterDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == id);
                if (bandToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new BandRegisterDbContext())
            {
                var taskToEdit = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                taskToEdit.Name = band.Name;
                taskToEdit.Members = band.Members;
                taskToEdit.Honorarium = band.Honorarium;
                taskToEdit.Genre = band.Genre;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToDelete = db.Bands.Find(id);
                if (bandToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {

                db.Bands.Remove(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}