using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCastle.Core.Interfaces;
using TheCastle.Infrastructure.Data;
using TheCastle.Kernel.Entities;

namespace TheCastle.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmiesController : ControllerBase
    {
        private readonly IArmyService _armyService;

        public ArmiesController(IArmyService armyService)
        {
            _armyService = armyService;
        }

        // GET: api/Armies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Army>>> GetArmies()
        {
            return await _armyService.GetAll().ToListAsync();
        }

        // GET: api/Armies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Army>> GetArmy(int id)
        {
            var army = await _armyService.GetOne(id);

            if (army == null)
            {
                return NotFound();
            }

            return army;
        }

        // PUT: api/Armies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmy(int id, Army army)
        {
            if (id != army.Id)
            {
                return BadRequest();
            }

            try
            {
                await _armyService.Update(army);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Armies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Army>> PostArmy(Army army)
        {
            await _armyService.Create(army);

            return CreatedAtAction("GetArmy", new { id = army.Id }, army);
        }

        // DELETE: api/Armies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Army>> DeleteArmy(int id)
        {
            var army = await _armyService.GetOne(id);
            if (army == null)
            {
                return NotFound();
            }
            
            await _armyService.Delete(army);

            return army;
        }

        private bool ArmyExists(int id)
        {
            return _armyService.EntityExist(id);
        }
    }
}
