using Core.Entities;


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
        }
        public static List<DrugStore> DrugStores { get; set; }
        public static List<Drug> Drugs { get; set; }
        public static List<Druggist> Druggists { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Owner> Owners { get; set; }

    }
}
