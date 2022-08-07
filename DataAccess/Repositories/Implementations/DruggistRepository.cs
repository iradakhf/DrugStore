using DataAccess.Repositories.Base;
using Core.Entities;
using DataAccess.Contexts;

namespace DataAccess.Repositories.Implementations
{
    public class DruggistRepository : IRepository<Druggist>
    {
        public static int id { get; set; }
        public Druggist Create(Druggist entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DataBaseContext.Druggists.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }
        public void Update(Druggist entity)
        {
            try
            {

                var druggist = DataBaseContext.Druggists.Find(d => d.Id == entity.Id);
                if (druggist != null)
                {
                    druggist.Id = entity.Id;
                    druggist.Name = entity.Name;
                    druggist.Surname = entity.Surname;
                    druggist.Age = entity.Age;
                    druggist.Experience = entity.Experience;
                    druggist.DrugStore = entity.DrugStore;
                                     
                    
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Delete(Druggist entity)
        {
            try
            {
                DataBaseContext.Druggists.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Druggist Get(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.Druggists.Find(filter);
                }
                else
                {
                    return DataBaseContext.Druggists[0];
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Druggist> GetAll(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.Druggists.FindAll(filter);
                }
                else
                {
                    return DataBaseContext.Druggists;
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
