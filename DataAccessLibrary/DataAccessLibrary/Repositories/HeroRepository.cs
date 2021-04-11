using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Repositories
{
    public class HeroRepository : IDataAccessLayer
    {
        //new () c#9 Feature
        private List<HeroModel> people = new();
        public HeroRepository()
        {
            SeedSampleData();
        }
        private void SeedSampleData()
        {
            people.Add(new HeroModel { Id = 1, FirstName = "Tony", LastName = "Stark" });
            people.Add(new HeroModel { Id = 2, FirstName = "Joe", LastName = "Bennett" });
        }
        public List<HeroModel> GetHeroes()
        {
            return people;
        }
        public HeroModel InsertHero(string firstName, string lastName)
        {
            HeroModel hero = new() { FirstName = firstName, LastName = lastName };
            hero.Id = people.Max(x => x.Id) + 1;
            people.Add(hero);
            return hero;
        }
    }
}
