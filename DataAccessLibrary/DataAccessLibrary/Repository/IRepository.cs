using DataAccessLibrary.Models;
using System.Collections.Generic;

namespace DataAccessLibrary.Repository
{
    interface IRepository
    {
        public List<PersonModel> GetPeople();
        public PersonModel InsertPerson(string firstName, string lastName);
    }
}