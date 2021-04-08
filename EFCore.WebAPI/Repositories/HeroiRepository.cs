using EFCore.WebAPI.Data;
using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Repositories
{
    public class HeroiRepository : IHeroiRepository
    {
        private readonly HeroiContext _context;

        public HeroiRepository(HeroiContext context) 
        {
            _context = context;
        }

        // =============================================== Repositório abaixo

        public async Task<Heroi> Create(Heroi heroi)
        {
            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }

        public async Task Delete(int id)
        {
            var HeroiToDelete = await _context.Herois.FindAsync(id);
            _context.Herois.Remove(HeroiToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Heroi>> Get()
        {
            return await _context.Herois.ToListAsync();
        }

        public async Task<Heroi> Get(int id)
        {
            return await _context.Herois.FindAsync(id);
        }

        public async Task Update(Heroi heroi)
        {
            _context.Entry(heroi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
