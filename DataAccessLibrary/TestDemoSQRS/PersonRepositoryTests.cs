using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLibrary.Repositories;
using System.Linq;
using DataAccessLibrary.Models;
using DataAccessLibrary.Queries;

namespace TestDemoSQRS
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private readonly PersonRepository _repository;
        public TestContext TestContext { get; set; }
        public PersonRepositoryTests()
        {
            _repository = new();
        }
        [TestMethod]
        public void IsInitialized()
        {
            //Arrange
            //Done in Ctor

            //Act
            var hasRecords = _repository.GetPeople().Any();
            //Assert
            Assert.IsTrue(hasRecords);

        }
        [TestMethod]
        public void InsertNewRecordTest()
        {
            //Arrange
            var peopleCount = _repository.GetPeople().Count;
            PersonModel newPerson = new() {FirstName = "Mike", LastName = "Wazowski"};
            //Done in Ctor

            //Act
            TestContext.WriteLine("Inserting new person Record");
            _repository.InsertPerson(newPerson.FirstName, newPerson.LastName);
            var countAfterInsert = _repository.GetPeople().Count();
            //Assert
            Assert.AreEqual(peopleCount + 1, countAfterInsert);

        }
    }
}
