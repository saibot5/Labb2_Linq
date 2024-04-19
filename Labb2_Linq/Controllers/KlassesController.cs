using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_Linq.Models;
using NuGet.DependencyResolver;

namespace Labb2_Linq.Controllers
{
    public class KlassesController : Controller
    {
        private readonly Labb2Context _context;

        public KlassesController(Labb2Context context)
        {
            _context = context;
        }

        // GET: Klasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klass.ToListAsync());
        }

        // GET: Klasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klass = await _context.Klass
                .FirstOrDefaultAsync(m => m.KlassId == id);
            if (klass == null)
            {
                return NotFound();
            }

            return View(klass);
        }

        // GET: Klasses/Create
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(_context.Course, "Id", "Name");
            return View();
        }

        // POST: Klasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlassId,Name")] Klass klass, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klass);

                if (selectedCourses != null)
                {
                    foreach (int courseId in selectedCourses)
                    {
                        var course = _context.Course.Find(courseId);
                        if (course != null)
                        {
                            klass.Courses.Add(course);

                        }
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klass);
        }

        // GET: Klasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klass = await _context.Klass.FindAsync(id);
            if (klass == null)
            {
                return NotFound();
            }
            return View(klass);
        }

        // POST: Klasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlassId,Name")] Klass klass)
        {
            if (id != klass.KlassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlassExists(klass.KlassId))
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
            return View(klass);
        }

        // GET: Klasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klass = await _context.Klass
                .FirstOrDefaultAsync(m => m.KlassId == id);
            if (klass == null)
            {
                return NotFound();
            }

            return View(klass);
        }

        // POST: Klasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klass = await _context.Klass.FindAsync(id);
            if (klass != null)
            {
                _context.Klass.Remove(klass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlassExists(int id)
        {
            return _context.Klass.Any(e => e.KlassId == id);
        }
    }
}
