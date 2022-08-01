using Core.Abstractions;

namespace Core.Entities
{
    public class Admin : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
