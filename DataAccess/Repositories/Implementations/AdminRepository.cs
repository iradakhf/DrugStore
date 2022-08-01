

using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Implementations
{
    public class AdminRepository : IRepository<Admin>
    {
        public static int id { get; set; }

        public Admin Create(Admin entity)
        {

            id++;
            entity.Id = id;
            try
            {

                DataBaseContext.Admins.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;

        }
        public void Update(Admin entity)
        {
            try
            {
                var admin = DataBaseContext.Admins.Find(a => a.Id == entity.Id);
                if (admin != null)
                {
                    admin.Id = entity.Id;
                    admin.Name = entity.Name;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Delete(Admin entity)
        {
            try
            {
                DataBaseContext.Admins.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.Admins.Find(filter);
                }
                else
                {
                    return DataBaseContext.Admins[0];
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return DataBaseContext.Admins.FindAll(filter);
                }
                else
                {
                    return DataBaseContext.Admins;
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
