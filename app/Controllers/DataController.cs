using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.Controllers
{
    public class DataController : Controller
    {
        private readonly dataContext _context;

        public DataController(dataContext context)
        {
            _context = context;
        }

        // GET: Data
        public async Task<IActionResult> Index(string searchString)
        {
            var personer = from p in _context.Personer
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                personer = personer.Where(s => s.Fornavn.Contains(searchString));
            }
            return View(await personer.ToListAsync());
        }

        // GET: Data/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personer = await _context.Personer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personer == null)
            {
                return NotFound();
            }

            return View(personer);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fornavn,Efternavn,Adresse,Adresse2,Postnr,By,Telefonnr")] Personer personer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personer);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personer = await _context.Personer.FindAsync(id);
            if (personer == null)
            {
                return NotFound();
            }
            return View(personer);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Fornavn,Efternavn,Adresse,Adresse2,Postnr,By,Telefonnr")] Personer personer)
        {
            if (id != personer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonerExists(personer.Id))
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
            return View(personer);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personer = await _context.Personer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personer == null)
            {
                return NotFound();
            }

            return View(personer);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var personer = await _context.Personer.FindAsync(id);
            _context.Personer.Remove(personer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonerExists(long id)
        {
            return _context.Personer.Any(e => e.Id == id);
        }
    }
}
