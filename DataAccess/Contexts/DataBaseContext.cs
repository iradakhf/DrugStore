using Core.Entities;
using Core.Helpers;

namespace DataAccess.Contexts
{
    public static class DataBaseContext
    {
        static DataBaseContext()
        {
            Owners = new List<Owner>();
            Drugs = new List<Drug>();
            DrugStores = new List<DrugStore>();
            Druggists = new List<Druggist>();
            Admins = new List<Admin>();
          


            string password1 = "000";           
            Admin admin1 = new Admin("user1", PasswordHasher.Encrypt(password1));
            Admins.Add(admin1);

            string password2 = "0";            
            Admin admin2 = new Admin("user2", PasswordHasher.Encrypt(password2));
            Admins.Add(admin2);

        }
       
        public static List<DrugStore> DrugStores { get; set; }
        public static List<Drug> Drugs { get; set; }
        public static List<Druggist> Druggists { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Owner> Owners { get; set; }

    }
}
