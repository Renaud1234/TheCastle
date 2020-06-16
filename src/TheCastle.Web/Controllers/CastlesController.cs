using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheCastle.Core.Interfaces;
using TheCastle.Kernel.Entities;

namespace TheCastle.Web.Controllers
{
    public class CastlesController : Controller
    {
        private readonly ICastleService _castleService;
        private readonly IArmyService _armyService;

        public CastlesController(ICastleService castleService,
                                 IArmyService armyService)
        {
            _castleService = castleService;
            _armyService = armyService;
        }

        // GET: Castles
        public async Task<IActionResult> Index()
        {
            var Castles =  await _castleService.GetAll()
                                               .Include(x => x.Army)
                                               .ToListAsync();

            return View(Castles);

            /* Scaffolded code
            var applicationDBContext = _castleService.Castles.Include(c => c.Army);
            return View(await applicationDBContext.ToListAsync());
            */
        }

        // GET: Castles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var castle = await _castleService.GetOneWithDetails(id);
                return View(castle);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }

            /* Scaffolded code
            if (id == null)
            {
                return NotFound();
            }

            var castle = await _castleService.Castles
                .Include(c => c.Army)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (castle == null)
            {
                return NotFound();
            }

            return View(castle);
            */
        }

        // GET: Castles/Create
        public IActionResult Create()
        {
            var armyList = _armyService.GetAll().OrderBy(x => x.Name);

            ViewData["ArmyId"] = new SelectList(armyList, "Id", "Id");
            return View();

            /* Scaffolded code
            ViewData["ArmyId"] = new SelectList(_castleService.Armies, "Id", "Id");
            return View();
            */
        }

        // POST: Castles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ArmyId,Id")] Castle castle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _castleService.Create(castle);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                throw;
            }

            var armyList = _armyService.GetAll().OrderBy(x => x.Name);

            ViewData["ArmyName"] = new SelectList(armyList, "Id", "Name");
            return View(castle);

            /* Scaffolded code
            if (ModelState.IsValid)
            {
                _castleService.Add(castle);
                await _castleService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmyId"] = new SelectList(_castleService.Armies, "Id", "Id", castle.ArmyId);
            return View(castle);
            */
        }

        // GET: Castles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var castle = await _castleService.GetOne(id);

                if (castle == null)
                {
                    return NotFound();
                }

                var armyList = _armyService.GetAll().OrderBy(x => x.Name);
                ViewData["ArmyId"] = new SelectList(armyList, "Id", "Id", castle.ArmyId);

                return View(castle);
            }
            catch (Exception)
            {
                return NotFound();
            }

            /* Scaffolded code
            if (id == null)
            {
                return NotFound();
            }

            var castle = await _castleService.Castles.FindAsync(id);
            if (castle == null)
            {
                return NotFound();
            }
            ViewData["ArmyId"] = new SelectList(_castleService.Armies, "Id", "Id", castle.ArmyId);
            return View(castle);
            */
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
                    await _castleService.Update(castle);
                    //_castleService.Update(castle);
                    //await _castleService.SaveChangesAsync();
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

            var armyList = _armyService.GetAll().OrderBy(x => x.Name);
            ViewData["ArmyId"] = new SelectList(armyList, "Id", "Id", castle.ArmyId);

            //ViewData["ArmyId"] = new SelectList(_castleService.Armies, "Id", "Id", castle.ArmyId);
            return View(castle);
        }

        // GET: Castles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var castle = await _castleService.GetOne(id);

            if (castle == null)
            {
                return NotFound();
            }

            return View(castle);

            /* Scaffolded code
            if (id == null)
            {
                return NotFound();
            }

            var castle = await _castleService.Castles
                .Include(c => c.Army)
                .FirstOrDefaultAsync(m => m.Id == id);
            */
        }

        // POST: Castles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _castleService.Delete(id);
            return RedirectToAction(nameof(Index));

            /* Scaffolded code
            var castle = await _castleService.Castles.FindAsync(id);
            _castleService.Castles.Remove(castle);
            await _castleService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
        }

        private bool CastleExists(int id)
        {
            return _castleService.EntityExist(id);

            /* Scaffolded code
            return _castleService.Castles.Any(e => e.Id == id);
            */
        }
    }
}
