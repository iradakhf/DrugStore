using Core.Abstractions;

namespace Core.Entities
{
    public class DrugStore : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public List<Druggist> Druggists { get; set; }
    }
}
