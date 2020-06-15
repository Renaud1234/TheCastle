using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheCastle.Infrastructure.Data;
using TheCastle.Kernel.Entities;

namespace TheCastle.Web.Controllers
{
    public class CastlesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CastlesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Castles
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Castles.Include(c => c.Army);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Castles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castle = await _context.Castles
                .Include(c => c.Army)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (castle == null)
            {
                return NotFound();
            }

            return View(castle);
        }

        // GET: Castles/Create
        public IActionResult Create()
        {
            ViewData["ArmyId"] = new SelectList(_context.Armies, "Id", "Id");
            return View();
        }

        // POST: Castles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ArmyId,Id")] Castle castle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(castle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmyId"] = new SelectList(_context.Armies, "Id", "Id", castle.ArmyId);
            return View(castle);
        }

        // GET: Castles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castle = await _context.Castles.FindAsync(id);
            if (castle == null)
            {
                return NotFound();
            }
            ViewData["ArmyId"] = new SelectList(_context.Armies, "Id", "Id", castle.ArmyId);
            return View(castle);
        }

        // POST: Castles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ArmyId,Id")] Castle castle)
        {
            if (id != castle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(castle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastleExists(castle.Id))
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
            ViewData["ArmyId"] = new SelectList(_context.Armies, "Id", "Id", castle.ArmyId);
            return View(castle);
        }

        // GET: Castles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castle = await _context.Castles
                .Include(c => c.Army)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (castle == null)
            {
                return NotFound();
            }

            return View(castle);
        }

        // POST: Castles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var castle = await _context.Castles.FindAsync(id);
            _context.Castles.Remove(castle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastleExists(int id)
        {
            return _context.Castles.Any(e => e.Id == id);
        }
    }
}
