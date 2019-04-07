using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeisterMask.Models;
using TeisterMask.Data;

namespace TeisterMask.Controllers
{
    public class TaskController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using(var db = new TeisterMaksDbContext())
            {
                var tasks = db.Tasks.ToList();
                return View(tasks);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(string title, string status)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status))
            {
                return RedirectToAction("Index");
            }
            Task task = new Task
            {
                Title = title,
                Status = status
            };
            using (var db = new TeisterMaksDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            using (var db = new TeisterMaksDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == Id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }
        [HttpPost]
        public IActionResult Edit(Task task)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new TeisterMaksDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == task.Id);
                taskToEdit.Title = task.Title;
                taskToEdit.Status = task.Status;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterMaksDbContext())
            {
                var taskToDelete = db.Tasks.Find(id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return View(taskToDelete);
            }
        }
        [HttpPost]
        public IActionResult Delete(Task task)
        {
            using (var db = new TeisterMaksDbContext())
            {
                
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
