using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Repository
{
    public class PersonRepository : IRepository
    {
        //new () c#9 Feature
        private List<PersonModel> people = new();
        public PersonRepository()
        {
            SeedSampleData();
        }
        private void SeedSampleData()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "Tony", LastName = "Stark" });
            people.Add(new PersonModel { Id = 2, FirstName = "Joe", LastName = "Bennett" });
        }
        public List<PersonModel> GetPeople()
        {
            return people;
        }
        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel person = new() { FirstName = firstName, LastName = lastName };
            person.Id = people.Max(x => x.Id) + 1;
            people.Add(person);
            return person;
        }
    }
}
