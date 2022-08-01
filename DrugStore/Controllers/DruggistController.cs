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

            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All Druggists");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id : {druggist.Id}, Name: {druggist.Name}," +
                        $" Surname {druggist.Surname}, Age : {druggist.Age}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please choose one of the druggists by id to continue");
                string druggistId = Console.ReadLine();
                int Id;
                bool result = int.TryParse(druggistId, out Id);
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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the age in the correct format");
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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No druggist found");

                }


            }
        }

        #endregion
        #region DeleteDruggist
        public void Delete()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the druggists by id to delete");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "all druggists");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {druggist.Id} name : {druggist.Name} " +
                        $"surname :{druggist.Surname}, age : {druggist.Age}"); 
                }
                string id = Console.ReadLine();
                int druggistId;
                bool result = int.TryParse(id, out druggistId);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == druggistId);
                    if (druggist != null)
                    {

                        _druggistRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"{druggist.Name} druggist is deleted");

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no druggist found with this id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter id in digits");
                    goto Id;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No druggist found");
            }
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
