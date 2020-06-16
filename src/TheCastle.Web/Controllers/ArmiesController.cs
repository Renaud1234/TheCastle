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
    public class ArmiesController : Controller
    {
        private readonly ICastleService _castleService;
        private readonly IArmyService _armyService;

        public ArmiesController(ICastleService castleService,
                                IArmyService armyService)
        {
            _castleService = castleService;
            _armyService = armyService;
        }

        // GET: Armies
        public async Task<IActionResult> Index()
        {
            return View(await _armyService.GetAll().ToListAsync());
        }

        // GET: Armies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var army = await _armyService.GetOne(id);
                return View(army);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Armies/Create
        public IActionResult Create()
        {
            var castleList = _castleService.GetAll().OrderBy(x => x.Name);

            ViewData["CastleId"] = new SelectList(castleList, "Id", "Id");
            return View();
        }

        // POST: Armies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Army army)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _armyService.Create(army);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                throw;
            }

            var castleList = _castleService.GetAll().OrderBy(x => x.Name);

            ViewData["CastleId"] = new SelectList(castleList, "Id", "Id");
            return View(army);
        }

        // GET: Armies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var army = await _armyService.GetOne(id);

                if (army == null)
                {
                    return NotFound();
                }

                return View(army);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Armies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] Army army)
        {
            if (id != army.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _armyService.Update(army);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmyExists(army.Id))
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

            return View(army);
        }

        // GET: Armies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var army = await _castleService.GetOne(id);

            if (army == null)
            {
                return NotFound();
            }

            return View(army);
        }

        // POST: Armies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _armyService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ArmyExists(int id)
        {
            return _armyService.EntityExist(id);
        }
    }
}
