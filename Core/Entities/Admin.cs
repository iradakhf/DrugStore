using Core.Abstractions;

namespace Core.Entities
{
    public class Admin : IEntity
    {
        public Admin(string username, string password)
        {
            Name = username;
            Password = password;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
