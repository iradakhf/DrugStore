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

            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            idInDigits: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please choose one of the drug stores by id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "all drug stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id}, Name : {drugStore.Name}, Address : {drugStore.Address}," +
                        $" Contact Number: {drugStore.ContactNumber}, Drug store owner {drugStore.Owner.Name} {drugStore.Owner.Surname}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == choosenId);
                    if (drugStore != null)
                    {
                    name:    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's name");
                        string name = Console.ReadLine();
                        if (name != "")
                        {


                            surname: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's surname");
                            string surname = Console.ReadLine();
                            if (surname != "")
                            {


                            Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's Age");
                                string age = Console.ReadLine();
                                if (age != "")
                                {


                                    byte Age;
                                    result = byte.TryParse(age, out Age);
                                    if (result)
                                    {
                                        if (Age >= 18)
                                        {
                                        Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's Experience");
                                            string experience = Console.ReadLine();
                                            if (experience != "")
                                            {


                                                uint druggistExperience;
                                                result = uint.TryParse(experience, out druggistExperience);
                                                if (result)
                                                {
                                                    if (druggistExperience >= 1)
                                                    {
                                                        if (druggistExperience < Age / 2)
                                                        {

                                                            Druggist druggist = new Druggist();
                                                            druggist.Name = name;
                                                            druggist.Surname = surname;
                                                            druggist.Age = Age;
                                                            druggist.Id = choosenId;
                                                            druggist.Experience = druggistExperience;
                                                            drugStore.Druggists.Add(druggist);
                                                            _druggistRepository.Create(druggist);
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Druggist is successfully created with the id {druggist.Id}, Name: {druggist.Name}, surname :{druggist.Surname} , age :{druggist.Age}, has experience of {druggist.Experience}");
                                                        }
                                                        else
                                                        {
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "can not create druggist who has more experience than their age");

                                                        }
                                                    }

                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "can not create druggist who has less than 1 year experience");

                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "enter experience in the correct format");
                                                    goto Experience;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "this field is required");
                                                goto Experience;
                                            }
                                        }

                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "age should be at least 18 to be a druggist");

                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter DrugStore's age in the correct format");
                                        goto Age;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "this field is required");
                                    goto Age;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "this field is required");
                                goto surname;
                            }
                        }
                        else
                        {

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "this field is required");
                            goto name;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "drug store could not found with the id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter id in digits");
                    goto idInDigits;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found to delete drug from");
            }

        }
        #endregion
        #region UpdateDruggist
        public void Update()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            idInDigits: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please choose one of the drug stores by id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "all drug stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id}, Name : {drugStore.Name}, Address : {drugStore.Address}," +
                        $" Contact Number: {drugStore.ContactNumber}, Drug store owner {drugStore.Owner.Name} {drugStore.Owner.Surname}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == choosenId);
                    if (drugStore != null)
                    {

                        if (drugStore.Druggists.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All Druggists");
                            foreach (var druggist in drugStore.Druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id : {druggist.Id}, Name: {druggist.Name}," +
                                    $" Surname {druggist.Surname}, Age : {druggist.Age}, experience : {druggist.Experience}");
                            }
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please choose one of the druggists by id to continue");
                            string druggistId = Console.ReadLine();
                            int Id;
                            result = int.TryParse(druggistId, out Id);
                            if (result)
                            {
                                var druggist = _druggistRepository.Get(d => d.Id == Id);
                                if (druggist != null)
                                {
                               name:     ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter druggist's new name");
                                    string name = Console.ReadLine();
                                    if (name != "")
                                    {


                                        surname:   ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter druggist's new surname");
                                        string surname = Console.ReadLine();
                                        if (surname != "")
                                        {


                                        Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter druggist's new age");
                                            string age = Console.ReadLine();
                                            byte newAge;
                                            result = byte.TryParse(age, out newAge);
                                            if (result)
                                            {
                                                if (newAge >= 18)
                                                {
                                                Digits: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, $"Please choose 1 if you want to  keep the druggist at the same drugstore {druggist.DrugStore.Name}, " +
                                                      " 2 if you want to send her/him to another drugstore");
                                                    string option = Console.ReadLine();
                                                    int optionInt;
                                                    result = int.TryParse(option, out optionInt);
                                                    if (result)
                                                    {
                                                        if (optionInt == 1)
                                                        {

                                                            druggist.Name = name;
                                                            druggist.Surname = surname;
                                                            druggist.Age = newAge;
                                                            druggist.DrugStore = drugStore;
                                                            _druggistRepository.Update(druggist);
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Druggist is successfully updated : id : {druggist.Id}, Name: {druggist.Name}, " +
                                                                $"surname :{druggist.Surname}, Age :{druggist.Age}, experience : {druggist.Experience} and works at drug store {druggist.DrugStore.Name}");
                                                        }
                                                        else if (optionInt == 2)
                                                        {
                                                            foreach (var drugS in drugStores)
                                                            {
                                                                if (drugS != druggist.DrugStore)
                                                                {

                                                                    druggist.Name = name;
                                                                    druggist.Surname = surname;
                                                                    druggist.Age = newAge;
                                                                    druggist.DrugStore = drugS;
                                                                    _druggistRepository.Update(druggist);
                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Druggist is successfully updated : id {druggist.Id}, Name: {druggist.Name}, " +
                                                                        $"surname :{druggist.Surname}, Age :{druggist.Age},experience : {druggist.Experience}  works at drug store {druggist.DrugStore.Name}");
                                                                }
                                                            }

                                                        }

                                                        else
                                                        {
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "there is no option with this digit");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "option should be in digits");
                                                        goto Digits;

                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "age should be at least 18 to be a druggist");

                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the age in the correct format");
                                                goto Age;
                                            }
                                        }
                                        else
                                        {

                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "this field is required");
                                            goto surname;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "this field is required");
                                        goto name;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No druggist found as indicated");

                                }


                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter Id in correct format");
                                goto Id;

                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No druggist found");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "drug store could not found with the id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter id in digits");
                    goto idInDigits;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found to delete drug from");
            }

        }

        #endregion
        #region DeleteDruggist
        public void Delete()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            idInDigits: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please choose one of the drug stores by id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "all drug stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id}, Name : {drugStore.Name}, Address : {drugStore.Address}," +
                        $" Contact Number: {drugStore.ContactNumber}, Drug store owner {drugStore.Owner.Name} {drugStore.Owner.Surname}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == choosenId);
                    if (drugStore != null)
                    {

                        if (drugStore.Druggists.Count > 0)
                        {

                        digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the druggists by id to delete");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"all druggists in {drugStore}");
                            foreach (var druggist in drugStore.Druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {druggist.Id} name : {druggist.Name} " +
                                    $"surname :{druggist.Surname}, age : {druggist.Age}, experience : {druggist.Experience}");
                            }
                            string choosentId = Console.ReadLine();
                            int Id;
                            result = int.TryParse(choosentId, out Id);
                            if (result)
                            {
                                var druggist = _druggistRepository.Get(d => d.Id == Id);
                                if (druggist != null)
                                {

                                    _druggistRepository.Delete(druggist);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"{druggist.Name} druggist is deleted from the drug store {drugStore.Name}");

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no druggist found with this id");

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter id in digits");
                                goto digit;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, $"no druggist found in the drugstore {drugStore.Name}");

                        }



                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "drug store could not found with the id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter id in digits");
                    goto idInDigits;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found to delete drug from");
            }


        }
        #endregion
        #region GetDruggist
        public void Get()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the druggists by id to get");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "all druggists");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {druggist.Id} name : {druggist.Name} ");
                }
                string id = Console.ReadLine();
                int druggistId;
                bool result = int.TryParse(id, out druggistId);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == druggistId);
                    if (druggist != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id : {druggist.Id}, name : {druggist.Name}, " +
                        $"surname :{druggist.Surname}, age : {druggist.Age}, experience : {druggist.Experience} ");

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no druggist found with this id");

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
        #region GetAllDruggists
        public void GetAll()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "all druggists");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {druggist.Id} name : {druggist.Name}, " +
                        $"surname : {druggist.Surname}, age : {druggist.Age} ");
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No druggist found");
            }
        }
        #endregion
        #region GetAllDruggistByDrugStore
        public void GetAllDruggistByDrugStore()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            idInDigits: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please choose one of the drug stores by id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "all drug stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id}, Name : {drugStore.Name}, Address : {drugStore.Address}," +
                        $" Contact Number: {drugStore.ContactNumber}, Drug store owner {drugStore.Owner.Name} {drugStore.Owner.Surname}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == choosenId);
                    if (drugStore != null)
                    {

                        if (drugStore.Druggists.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"all druggists in {drugStore}");
                            foreach (var druggist in drugStore.Druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {druggist.Id} name : {druggist.Name} " +
                                    $"surname :{druggist.Surname}, age : {druggist.Age}, experience : {druggist.Experience}");
                            }
                            
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, $"no druggist found in the drugstore {drugStore.Name}");

                        }



                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "drug store could not found with the id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter id in digits");
                    goto idInDigits;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found to delete drug from");
            }

        }
        #endregion
    }
}
