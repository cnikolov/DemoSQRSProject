namespace DataAccessLibrary.Models
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; internal set; }
    }
}
