using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manager.Controllers
{
    public class DruggistController
    {
        private static int id;
        public DruggistRepository _druggistRepository;
        public DrugStoreRepository _drugStoreRepository;
        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
            _drugStoreRepository = new DrugStoreRepository();
        }
        #region CreateDruggist
        public void Create()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's surname");
            string surname = Console.ReadLine();
        Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's Age");
            string age = Console.ReadLine();
            byte Age;
            bool result = byte.TryParse(age, out Age);
            if (result)
            {
                Druggist druggist = new Druggist();
                druggist.Name = name;
                druggist.Surname = surname;
                druggist.Age = Age;
                druggist.Id = id;
                _druggistRepository.Create(druggist);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Druggist is successfully created with the id {druggist.Id}, Name: {druggist.Name}, surname :{druggist.Surname} , age :{druggist.Age}");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter DrugStore's age in the correct format");
                goto Age;
            }
        }
        #endregion
        #region UpdateDruggist
        public void Update()
        {

            DrugStore drugStore1 = new DrugStore();
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the drugstores by id");

                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id} Name : {drugStore.Name} Address : {drugStore.Address} Contact Number: {drugStore.ContactNumber}");
                }
                string id = Console.ReadLine();
                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == drugStoreId);
                    if (drugStore != null)
                    {
                    Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the druggist by id");

                        foreach (var druggist in drugStore.Druggists)
                        {

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"druggist id : {druggist.Id}, name : {druggist.Name}" +
                                $"surname : {druggist.Surname}, Age {druggist.Age}");

                        }

                        string druggistId = Console.ReadLine();
                        int Id;
                        result = int.TryParse(druggistId, out Id);
                        if (result)
                        {
                            var druggist = _druggistRepository.Get(d => d.Id == Id);
                            if (druggist != null)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter druggist's new name");
                                string name = Console.ReadLine();
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter druggist's new surname");
                                string surname = Console.ReadLine();
                            Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter druggist's new age");
                                string age = Console.ReadLine();
                                byte newAge;
                                result = byte.TryParse(age, out newAge);
                                if (result)
                                {

                                    Druggist newDruggist = new Druggist();
                                    newDruggist.Name = name;
                                    newDruggist.Surname = surname;
                                    newDruggist.Age = newAge;

                                    _druggistRepository.Update(newDruggist);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Druggist is successfully updated : id {newDruggist.Id}, Name: {newDruggist.Name}, surname :{newDruggist.Surname}, Age :{newDruggist.Age}");

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the contact number in the correct format");
                                    goto Age;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No druggist found as indicated");

                            }
                           

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the ID in the correct format");
                            goto Id;
                        }

                        
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugstore found as indicated");
                        
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the ID in the correct format");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drugstore found");
               
            }
        }
        #endregion
        #region DeleteDruggist
        public void Delete()
        {

        }
        #endregion
        #region GetDruggist
        public void Get()
        {

        }
        #endregion
        #region GetAllDruggists
        public void GetAll()
        {

        }
        #endregion
    }
}
