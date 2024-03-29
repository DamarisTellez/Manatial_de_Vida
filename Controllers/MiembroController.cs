using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manatial_de_Vida.Data;
using Manatial_de_Vida.Models;

namespace Manatial_de_Vida.Controllers
{
    public class MiembroController : Controller
    {
        private readonly BDContext _context;

        public MiembroController(BDContext context)
        {
            _context = context;
        }

        // GET: Miembro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miembro.ToListAsync());
        }

        // GET: Miembro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // GET: Miembro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miembro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,TipoMiembro")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miembro);
        }

        // GET: Miembro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembro.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }
            return View(miembro);
        }

        // POST: Miembro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,TipoMiembro")] Miembro miembro)
        {
            if (id != miembro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroExists(miembro.Id))
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
            return View(miembro);
        }

        // GET: Miembro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // POST: Miembro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miembro = await _context.Miembro.FindAsync(id);
            _context.Miembro.Remove(miembro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroExists(int id)
        {
            return _context.Miembro.Any(e => e.Id == id);
        }
    }
}
