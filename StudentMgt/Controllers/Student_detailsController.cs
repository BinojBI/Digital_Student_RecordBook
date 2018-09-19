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
    public class Student_detailsController : Controller
    {
        private readonly StudentMgtContext _context;

        public Student_detailsController(StudentMgtContext context)
        {
            _context = context;
        }

        // GET: Student_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student_details.ToListAsync());
        }

        // GET: Student_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_details = await _context.Student_details
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student_details == null)
            {
                return NotFound();
            }

            return View(student_details);
        }

        // GET: Student_details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Reg_No,Email,UserName,Password")] Student_details student_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student_details);
        }

        // GET: Student_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_details = await _context.Student_details.SingleOrDefaultAsync(m => m.ID == id);
            if (student_details == null)
            {
                return NotFound();
            }
            return View(student_details);
        }

        // POST: Student_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Reg_No,Email,UserName,Password")] Student_details student_details)
        {
            if (id != student_details.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_detailsExists(student_details.ID))
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
            return View(student_details);
        }

        // GET: Student_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_details = await _context.Student_details
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student_details == null)
            {
                return NotFound();
            }

            return View(student_details);
        }

        // POST: Student_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_details = await _context.Student_details.SingleOrDefaultAsync(m => m.ID == id);
            _context.Student_details.Remove(student_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_detailsExists(int id)
        {
            return _context.Student_details.Any(e => e.ID == id);
        }
    }
}
