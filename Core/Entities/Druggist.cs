using Core.Abstractions;

namespace Core.Entities
{
    public class Druggist : Person, IEntity
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public double Experience { get; set; }
        public DrugStore DrugStore { get; set; }
    }
}
