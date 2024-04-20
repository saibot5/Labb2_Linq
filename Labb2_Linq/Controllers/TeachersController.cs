using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_Linq.Models;

namespace Labb2_Linq.Controllers
{
    public class TeachersController : Controller
    {
        private readonly Labb2Context _context;

        public TeachersController(Labb2Context context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teacher.Include(c => c.Courses).ToListAsync());
        }
        public async Task<IActionResult> Programmering()
        {
            var query = from t in _context.Teacher
                        where t.Courses.Any(c => c.Name == "programmering 1")
                        select t;

            return View(await query.Include(c => c.Courses).ToListAsync());
        }



        public async Task<IActionResult> ReiToTob()
        {
            //hitta om reidar är lärare i programmering 1
            var teacher = await _context.Teacher.Where(t => t.FirstName == "Reidar").Where(t => t.Courses.Any(c => c.Name == "Programmering 1")).FirstOrDefaultAsync();
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> ReiToTob(Teacher teacher)
        {
            //hämta reidar igen annars skapas en till reidar (hittar inte varför) och ta bort kursen "Programmering 1"
            teacher = await _context.Teacher.Where(t => t.FirstName == "Reidar").Include(c => c.Courses).FirstOrDefaultAsync();
            var course = await _context.Course.Where(c => c.Name == "Programmering 1").FirstOrDefaultAsync();
            teacher.Courses.Remove(course);
            _context.Update(teacher);

            //hämta tobias och lägg till Programmering 1
            Teacher teacher1 = await _context.Teacher.Where(t => t.FirstName == "Tobias").FirstOrDefaultAsync();
            teacher1.Courses.Add(course);
            _context.Update(teacher1);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(_context.Course, "Id", "Name");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Teacher teacher, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);

                if (selectedCourses != null)
                {
                    foreach(int courseId in selectedCourses)
                    {
                        var course = _context.Course.Find(courseId);
                        if(course != null)
                        {
                            teacher.Courses.Add(course);
                            
                        }
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
