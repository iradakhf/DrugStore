
using Core.Abstractions;

namespace Core.Entities
{
    public class Owner : IEntity
    {
        public Owner()
        {
            DrugStores = new List<DrugStore>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public List<DrugStore> DrugStores { get; set; }
    }
}
