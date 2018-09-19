using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMgt.Models;

namespace StudentMgt.Controllers
{
    public class Marks1Controller : Controller
    {
        private readonly StudentMgtContext _context;

        public Marks1Controller(StudentMgtContext context)
        {
            _context = context;
        }

        // GET: Marks1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marks.ToListAsync());
        }

        // GET: Marks1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .SingleOrDefaultAsync(m => m.ID == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // GET: Marks1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marks1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Student_detailsID,Maths,Chem,Physics")] Marks marks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marks);
        }

        // GET: Marks1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks.SingleOrDefaultAsync(m => m.ID == id);
            if (marks == null)
            {
                return NotFound();
            }
            return View(marks);
        }

        // POST: Marks1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Student_detailsID,Maths,Chem,Physics")] Marks marks)
        {
            if (id != marks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.ID))
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
            return View(marks);
        }

        // GET: Marks1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .SingleOrDefaultAsync(m => m.ID == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // POST: Marks1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marks = await _context.Marks.SingleOrDefaultAsync(m => m.ID == id);
            _context.Marks.Remove(marks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarksExists(int id)
        {
            return _context.Marks.Any(e => e.ID == id);
        }
    }
}
