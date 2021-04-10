using EFCore.WebAPI.Models;
using EFCore.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IHeroiRepository _heroiRepository;

        public HeroiController(IHeroiRepository heroiRepository)
        {
            _heroiRepository = heroiRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Heroi>> GetHeroi() // Get realiza consultas no BD
        {
            return await _heroiRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Heroi>> GetHeroi(int id)
        {
            return await _heroiRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Heroi>> PostHeroi([FromBody] Heroi heroi)
        {
            var newHeroi = await _heroiRepository.Create(heroi);
            return CreatedAtAction(nameof(GetHeroi), new { id = newHeroi.Id }, newHeroi);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Heroi heroi)
        {
            if (id != heroi.Id)
            {
                return BadRequest();
            }

            await _heroiRepository.Update(heroi);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHeroi (int id)
        {
            var heroiDelete = await _heroiRepository.Get(id);
            if(heroiDelete == null)
            {
                return NotFound();
            }
            await _heroiRepository.Delete(heroiDelete.Id);
            return NoContent();
        }
    }
}
