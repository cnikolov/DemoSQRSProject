using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLibrary.Repositories;
using System.Linq;
using DataAccessLibrary.Models;

namespace TestDemoSQRS
{
    [TestClass]
    public class HeroRepositoryTests
    {
        private readonly HeroRepository _repository;
        public TestContext TestContext { get; set; }
        public HeroRepositoryTests()
        {
            _repository = new();
        }
        [TestMethod]
        public void IsInitialized()
        {
            //Arrange
            //Done in Ctor

            //Act
            var hasRecords = _repository.GetHeroes().Result.Any();
            //Assert
            Assert.IsTrue(hasRecords);

        }
        [TestMethod]
        public void InsertNewRecordTest()
        {
            //Arrange
            var heroesCount = _repository.GetHeroes().Result.Count;
            HeroModel newHero = new() {FirstName = "Mike", LastName = "Wazowski"};
            //Done in Ctor

            //Act
            TestContext.WriteLine("Inserting new person Record");
            _repository.InsertHero(newHero.FirstName, newHero.LastName);
            var countAfterInsert = _repository.GetHeroes().Result.Count();
            //Assert
            Assert.AreEqual(heroesCount + 1, countAfterInsert);

        }
        [TestMethod]
        public void GetHeroById()
        {
            //Arrange
            //Act
            var hero = _repository.GetHeroById(1).Result;
            //Assert
            Assert.IsNotNull(hero);

        }
    }
}
