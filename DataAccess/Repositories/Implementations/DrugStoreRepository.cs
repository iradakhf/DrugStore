using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;


namespace DataAccess.Repositories.Implementations
{
    public class DrugStoreRepository : IRepository<DrugStore>
    {
        public static int id { get; set; }
        public DrugStore Create(DrugStore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DataBaseContext.DrugStores.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Update(DrugStore entity)
        {
            try
            {
                var drugStores = DataBaseContext.DrugStores.Find(ds => ds.Id == entity.Id);
                if (drugStores != null)
                {
                    drugStores.Id = entity.Id;
                    drugStores.Name = entity.Name;
                    drugStores.Address = entity.Address;
                    drugStores.ContactNumber = entity.ContactNumber;
                    drugStores.Druggists = entity.Druggists;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void Delete(DrugStore entity)
        {
            try
            {
                DataBaseContext.DrugStores.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public DrugStore Get(Predicate<DrugStore> filter= null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.DrugStores.Find(filter);
                }
                else
                {
                    return DataBaseContext.DrugStores[0];
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<DrugStore> GetAll(Predicate<DrugStore> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.DrugStores.FindAll(filter);

                }
                else
                {
                    return DataBaseContext.DrugStores;
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
