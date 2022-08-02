using Core.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Implementations
{
    public class OwnerRepository : IRepository<Owner>
    {
        private static int id;
        public Owner Create(Owner entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DataBaseContext.Owners.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }
        public void Update(Owner entity)
        {
            try
            {
            var owner = DataBaseContext.Owners.Find(o=>o.Id==entity.Id);
                if (owner != null)
                {
                    owner.Id = entity.Id;
                    owner.Name = entity.Name;
                    owner.Surname = entity.Surname;
                    owner.Age = entity.Age;
                    owner.DrugStores = entity.DrugStores;
                   
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           
        }

        public void Delete(Owner entity)
        {
            try
            {
                DataBaseContext.Owners.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Owner Get(Predicate<Owner> filter=null)
        {
            try
            {
                if (filter != null)
                {
                return DataBaseContext.Owners.Find(filter);

                }
                else
                {
                    return DataBaseContext.Owners[0];
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Owner> GetAll(Predicate<Owner> filter=null)
        {
            try
            {
                if (filter!=null)
                {
                    return DataBaseContext.Owners.FindAll(filter);
                }
                else
                {
                    return DataBaseContext.Owners;
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
