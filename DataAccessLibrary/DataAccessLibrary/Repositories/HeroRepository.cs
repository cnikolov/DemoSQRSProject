using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        //new () c#9 Feature
        private readonly List<HeroModel> _heroes = new();
        private const int Throttle = 1000 * 10;
        public HeroRepository()
        {
            SeedSampleData();
        }
        private void SeedSampleData()
        {
            _heroes.Add(new HeroModel { Id = 1, FirstName = "Tony", LastName = "Stark" });
            _heroes.Add(new HeroModel { Id = 2, FirstName = "Joe", LastName = "Bennett" });
        }
        public Task<List<HeroModel>>  GetHeroes()
        {
            Thread.Sleep(Throttle);
            return Task.FromResult(_heroes);
        }
        public HeroModel InsertHero(string firstName, string lastName)
        {
            HeroModel hero = new() { FirstName = firstName, LastName = lastName };
            hero.Id = _heroes.Max(x => x.Id) + 1;
            _heroes.Add(hero);
            return hero;
        }

        public Task<HeroModel> GetHeroById(int id)
        {
            return Task.FromResult(_heroes.FirstOrDefault(x => x.Id == id));
        }
    }
}
