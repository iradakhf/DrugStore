using Core.Abstractions;

namespace Core.Entities
{
    public class DrugStore : IEntity
    {
        public DrugStore()
        {
            Druggists = new List<Druggist>();
            Drugs = new List<Drug>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public List<Druggist> Druggists { get; set; }
        public List<Drug> Drugs { get; set; }
        public Owner Owner { get; set; }

    }
}
