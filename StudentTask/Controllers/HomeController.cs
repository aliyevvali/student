using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentTask.DAL;
using StudentTask.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StudentTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string name,int page = 1)
        {
            //var value = from x in _context.Students select x;
            //if (!string.IsNullOrEmpty(name))
            //{
            //    value = value.Where(x=>x.Name.Contains(name));
            //}
            return View(_context.Students.ToList().ToPagedList(page,10));
        }

        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            Student studentDB = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            if (studentDB == null) return NotFound();
            studentDB.Name = student.Name;
            studentDB.Surname = student.Surname;
            studentDB.Fin = student.Fin;
            studentDB.Enterprise = student.Enterprise;
            studentDB.StartDate = student.StartDate;
            studentDB.DateOfBirth = student.DateOfBirth;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult Search(int fin)
        //{
        //    return View(_context.Students.FirstOrDefault(x=>x.Fin == fin));
        //}


    }
}
