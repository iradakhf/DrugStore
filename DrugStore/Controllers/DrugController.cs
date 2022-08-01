using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manager.Controllers
{
    public class DrugController
    {

        private DrugRepository _drugRepository;
        private DrugStoreRepository _drugStoreRepository;
        public DrugController()
        {
            _drugRepository = new DrugRepository();
            _drugStoreRepository = new DrugStoreRepository();
        }
        #region CreateDrug
        public void Create()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the drugstores by id");
                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {drugStore.Id}, Name :{drugStore.Name}");
                }
                string id = Console.ReadLine();
                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == drugStoreId);
                    if (drugStore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drug's name");
                        string name = Console.ReadLine();
                    Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drug's price");
                        string price = Console.ReadLine();
                        double drugPrice;
                        result = double.TryParse(price, out drugPrice);
                        if (result)
                        {
                        Amount: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drug's amount");
                            string amount = Console.ReadLine();
                            int drugAmount;
                            result = int.TryParse(amount, out drugAmount);
                            if (result)
                            {
                                Drug drug = new Drug();
                                drug.Name = name;
                                drug.Price = drugPrice;
                                drug.Amount = drugAmount;

                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Drug is successfully created with the id {drug.Id}, Name: {drug.Name}, price :{drug.Price}, amount :{drug.Amount}");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the amount in the correct format");
                                goto Price;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the price in the correct format");
                            goto Price;
                        }
                    }
                    else
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No Drug Store found as indicated");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found");
            }
        }
        #endregion
        #region UpdateDrug
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
                    Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the drugs by id");

                        foreach (var drug in drugStore)
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
        #region DeleteDrug
        public void Delete()
        {

        }
        #endregion
        #region GetDrug
        public void Get()
        {

        }
        #endregion
        #region GetAllDrugs
        public void GetAll()
        {

        }
        #endregion
    }

}
