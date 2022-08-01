using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;


namespace DataAccess.Repositories.Implementations
{
    public class DrugRepository : IRepository<Drug>
    {
        private static int id { get; set; }
        public Drug Create(Drug entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DataBaseContext.Drugs.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }
        public void Update(Drug entity)
        {
            try
            {
                var drug = DataBaseContext.Drugs.Find(d => d.Id == entity.Id);
                if (drug != null)
                {
                    drug.Id = entity.Id;
                    drug.Name = entity.Name;
                    drug.Price = entity.Price;
                    drug.Amount = entity.Amount;
                    drug.DrugStores = entity.DrugStores;


                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Delete(Drug entity)
        {
            try
            {
                DataBaseContext.Drugs.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Drug Get(Predicate<Drug> filter=null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.Drugs.Find(filter);
                }
                else
                {
                    return DataBaseContext.Drugs[0];
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Drug> GetAll(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.Drugs.FindAll(filter);
                }
                else
                {
                    return DataBaseContext.Drugs;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
