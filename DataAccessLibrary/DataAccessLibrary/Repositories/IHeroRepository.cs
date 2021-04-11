using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public interface IHeroRepository
    {
        public Task<List<HeroModel>> GetHeroes();
        public HeroModel InsertHero(string firstName, string lastName);
        public Task<HeroModel> GetHeroById(int id);
    }
}