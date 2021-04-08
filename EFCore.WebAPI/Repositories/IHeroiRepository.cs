using EFCore.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Repositories
{
    public interface IHeroiRepository
    {
        // O Repositorio é uma camada que fica entre o aplicativo e a camada de acesso do banco de dados. 

        Task<IEnumerable<Heroi>> Get();
        Task<Heroi> Get(int id); 
        Task<Heroi> Create(Heroi heroi);
        Task Update(Heroi heroi);
        Task Delete(int id);
    }
}
