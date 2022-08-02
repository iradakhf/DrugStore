using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manager.Controllers
{
    public class DrugController
    {
        private static int id;
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
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, choose one of the drugstores by id to create drug in");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All drugStores");
                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"id : {drugStore.Id},name : {drugStore.Name}, " +
                        $"address  :{drugStore.Address}, contactNumber : {drugStore.ContactNumber}");
                }
                string choosenIdStr = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(choosenIdStr, out choosenId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == choosenId);
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
                                drug.Id = id;
                                drug.DrugStore = drugStore;
                                drugStore.Drugs.Add(drug);
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Drug is successfully " +
                                    $"created with the id {drug.Id}, Name: {drug.Name}, price :{drug.Price}, " +
                                    $"amount :{drug.Amount}" +
                                    $" and added to the drugstore : {drug.DrugStore.Name}");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the amount in the correct format");
                                goto Amount;
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No Drug Store found with the choosen id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter id in digits");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drugStore found to create drug");

            }

        }

        #endregion
        #region UpdateDrug
        public void Update()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            drugStoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, choose one of the drugstores by id to update the drug in");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All drugStores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id}," +
                        $" Name : {drugStore.Name}, Address : {drugStore.Address}," +
                        $"Contact Number: {drugStore.ContactNumber}");
                }
                string Id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(Id, out choosenId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == choosenId);
                    if (drugStore != null)
                    {
                        if (drugStore.Drugs.Count > 0)
                        {
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please, choose one of the drugs by id to update");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"All drugs in the drug store {drugStore.Name}");
                            foreach (var drug in drugStore.Drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id : {drug.Id}, Name : {drug.Name}, " +
                                    $"price :{drug.Price}, amount : {drug.Amount}");
                            }
                            string drugId = Console.ReadLine();
                            int choosenDrugId;
                            result = int.TryParse(drugId, out choosenDrugId);
                            if (result)
                            {
                                var drug = _drugRepository.Get(d => d.Id == choosenDrugId);
                                if (drug != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new name");
                                    string newName = Console.ReadLine();
                                Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new price");
                                    string newPriceStr = Console.ReadLine();
                                    double newPrice;
                                    result = double.TryParse(newPriceStr, out newPrice);
                                    if (result)
                                    {
                                    Amount: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new amount");
                                        string newAmountStr = Console.ReadLine();
                                        int newAmount;
                                        result = int.TryParse(newAmountStr, out newAmount);
                                        if (result)
                                        {

                                        Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "if you want to keep the drug in the same drugstore press 1," +
                                               " else press 2");
                                            string option = Console.ReadLine();
                                            byte optionInt;
                                            result = byte.TryParse(option, out optionInt);
                                            if (result)
                                            {
                                                if (optionInt == 1 || optionInt == 2)
                                                {
                                                    if (optionInt == 1)
                                                    {

                                                        drug.Name = newName;
                                                        drug.Price = newPrice;
                                                        drug.Amount = newAmount;
                                                        drug.DrugStore = drugStore;
                                                        _drugRepository.Update(drug);
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"new name is : {drug.Name}," +
                                                            $" new price : {drug.Price}, new amount : {drug.Amount}, stored in drugstore {drug.DrugStore.Name}");
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, choose one of the drugstores by id");
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All drugStores");

                                                        foreach (var drugStore1 in drugStores)
                                                        {
                                                            if (drugStore1 != drug.DrugStore)
                                                            {

                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore1.Id}," +
                                                                    $" Name : {drugStore1.Name}, Address : {drugStore1.Address}," +
                                                                    $"Contact Number: {drugStore1.ContactNumber}");

                                                            }
                                                            else
                                                            {
                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found");
                                                            }

                                                        }
                                                        Id = Console.ReadLine();
                                                        int intId;
                                                        result = int.TryParse(Id, out intId);
                                                        if (result)
                                                        {
                                                            var dStore = _drugStoreRepository.Get(ds => ds.Id == intId);
                                                            if (dStore != null)
                                                            {
                                                                drug.DrugStore = dStore;
                                                                drug.Name = newName;
                                                                drug.Price = newPrice;
                                                                drug.Amount = newAmount;
                                                                _drugRepository.Update(drug);
                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"new name is : {drug.Name}," +
                                                                    $" new price : {drug.Price}, new amount : {drug.Amount}, stored in drugstore {drug.DrugStore.Name}");

                                                            }
                                                            else
                                                            {
                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug store found with this id ");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter drug store id in digits");
                                                            goto drugStoreId;
                                                        }


                                                    }

                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Options should be within 1-2");
                                                    goto Digit;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please type option in digits");
                                                goto Digit;
                                            }
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the amount in correct format");
                                            goto Amount;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the price in correct format");
                                        goto Price;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug found with this id");

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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug found");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found with this id");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter drug store id in digits");
                    goto drugStoreId;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found to update drug in");
            }

        }
        #endregion
        #region DeleteDrug
        public void Delete()
        {
            DrugStore drugStore1 = new DrugStore();
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please choose one of the drug stores by id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "all drug stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id} Name : {drugStore.Name} Address : {drugStore.Address} Contact Number: {drugStore.ContactNumber}");
                }

                var drugs = _drugRepository.GetAll();
                if (drugs.Count > 0)
                {
                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the drugs by id to delete");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "all drugs");
                    foreach (var drug in drugs)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {drug.Id} name : {drug.Name} " +
                            $"price :{drug.Price}, amount : {drug.Amount}");
                    }
                    string id = Console.ReadLine();
                    int drugId;
                    bool result = int.TryParse(id, out drugId);
                    if (result)
                    {
                        var drug = _drugRepository.Get(d => d.Id == drugId);
                        if (drug != null)
                        {

                            _drugRepository.Delete(drug);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"{drug.Name} drug is deleted");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug found with this id");

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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug found ");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found to delete drug from");
            }
        }
        #endregion
        #region GetDrug
        public void Get()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the drugs by id to get");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "all drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {drug.Id}, name : {drug.Name} ");
                }
                string id = Console.ReadLine();
                int drugId;
                bool result = int.TryParse(id, out drugId);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == drugId);
                    if (drug != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id : {drug.Id} name : {drug.Name} " +
                        $"price :{drug.Price}, amount : {drug.Amount}");

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug found with this id");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug found");
            }
        }
        #endregion
        #region GetAllDrugs
        public void GetAll()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "all drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {drug.Id} name : {drug.Name}, " +
                        $"price : {drug.Price}, amount : {drug.Amount} ");
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug found");
            }
        }
        #endregion
    }

}
