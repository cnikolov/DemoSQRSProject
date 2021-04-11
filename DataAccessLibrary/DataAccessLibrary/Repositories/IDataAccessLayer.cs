using DataAccessLibrary.Models;
using System.Collections.Generic;

namespace DataAccessLibrary.Repositories
{
    public interface IDataAccessLayer
    {
        public List<HeroModel> GetHeroes();
        public HeroModel InsertHero(string firstName, string lastName);
    }
}