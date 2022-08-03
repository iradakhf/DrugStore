using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;


namespace Manager.Controllers
{
    public class DrugStoreController
    {
        private static int id;

        private DrugStoreRepository _drugStoreRepository;
        private OwnerRepository _ownerRepository;
        private DrugRepository _drugRepository;
        public DrugStoreController()
        {

            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _drugRepository = new DrugRepository();
        }

        #region CreateDrugStore
        public void Create()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Please choose one of the owners by id to create drugstore for");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, $"owner's id : {owner.Id}, name: {owner.Name}, surname : {owner.Surname}, age: {owner.Age}");
                }
                string Id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(Id, out choosenId);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == choosenId);
                    if (owner != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter DrugStore's name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter DrugStore's Address");
                        string address = Console.ReadLine();
                    Number: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter DrugStore's ContactNumber");
                        string number = Console.ReadLine();
                        int contactNumber;
                        result = int.TryParse(number, out contactNumber);
                        if (result)
                        {
                            DrugStore drugStore = new DrugStore();
                            drugStore.Name = name;
                            drugStore.Address = address;
                            drugStore.ContactNumber = contactNumber.ToString();
                            drugStore.Id = id;
                            drugStore.Owner = owner;
                            drugStore.Owner.DrugStores.Add(drugStore);
                            _drugStoreRepository.Create(drugStore);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore is successfully created with the id {drugStore.Id}, Name: {drugStore.Name}, " +
                                $"address :{drugStore.Address} , contact number :{drugStore.ContactNumber}, owner : {drugStore.Owner.Name} {drugStore.Owner.Surname}");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter DrugStore's ContactNumber in digits");
                            goto Number;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found with this id");

                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter Id in the correct format");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found");
            }


        }


        #endregion
        #region UpdateDrugStore
        public void Update()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the drugstores by id");
                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {drugStore.Id}, Name :{drugStore.Name}," +
                        $" Address: {drugStore.Address}, Owner : {drugStore.Owner.Name}  {drugStore.Owner.Surname}");
                }
                string id = Console.ReadLine();
                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == drugStoreId);
                    if (drugStore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drugStore's new name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drugStore's new address");
                        string address = Console.ReadLine();
                    Contact: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drugStore's new contact number");
                        string contactNumber = Console.ReadLine();
                        int newContactNumber;
                        result = int.TryParse(contactNumber, out newContactNumber);
                        if (result)
                        {

                            DrugStore newDrugStore = new DrugStore();
                            newDrugStore.Name = name;
                            newDrugStore.Address = address;
                            newDrugStore.ContactNumber = newContactNumber.ToString();

                            _drugStoreRepository.Update(newDrugStore);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore is successfully updated : ID : {newDrugStore.Id}, Name: {newDrugStore.Name}, Address :{newDrugStore.Address}, Contact Number :{newDrugStore.ContactNumber}");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the contact number in the correct format");
                            goto Contact;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found to update");
            }
        }
        #endregion
        #region DeleteDrugStore
        public void Delete()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the drugstores by ID");
                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {drugStore.Id}, Name :{drugStore.Name}, Address: {drugStore.Address}, Owner : {drugStore.Owner.Name} {drugStore.Owner.Surname}");
                }
                string id = Console.ReadLine();
                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == drugStoreId);
                    if (drugStore != null)
                    {
                        _drugStoreRepository.Delete(drugStore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore : {drugStore.Name} is successfully deleted");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found to delete");
            }

        }
        #endregion
        #region GetDrugStore
        public void Get()
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id : {drugStore.Id}, Name : {drugStore.Name}, Address : {drugStore.Address}, Contact Number: {drugStore.ContactNumber}, owner : {drugStore.Owner.Name} {drugStore.Owner.Surname} ");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found to get information about");
            }


        }
        #endregion
        #region GetAllDrugStores
        public void GetAll()
        {

            DrugStore drugStore1 = new DrugStore();
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "All Drug Stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id},  Name : {drugStore.Name} , Address : {drugStore.Address} , Contact Number: {drugStore.ContactNumber}, Owner : {drugStore.Owner.Name} {drugStore.Owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found");
            }

        }
        #endregion
        #region GetAllDrugStoresByOwner
        public void GetAllDrugStoresByOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one owner by id to get drugstores of them");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "owners list");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"owner id :{owner.Id}, name : {owner.Name}," +
                        $" surname :{owner.Surname}, age : {owner.Age} ");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {
                        var drugStores = _drugStoreRepository.GetAll();
                        if (drugStores != null)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"All drug stores owned by  {owner.Name} {owner.Surname}");
                            if (owner.DrugStores.Count > 0)
                            {
                                foreach (var ownerDrugStore in owner.DrugStores)
                                {
                                     ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id is {ownerDrugStore.Id}, name : {ownerDrugStore.Name}," +
                                            $" address : {ownerDrugStore.Address}, contact number : {ownerDrugStore.ContactNumber}");
                                }

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner store found");
                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug store found");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please, enter id in digits");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found");
            }
        }
        #endregion
        #region Sale
        public void Sale()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the drugstores by ID");
                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {drugStore.Id}, Name :{drugStore.Name}, Address: {drugStore.Address}, Owner : {drugStore.Owner.Name}");
                }
                string id = Console.ReadLine();
                int drugStoreId;
                bool result = int.TryParse(id, out drugStoreId);
                if (result)
                {
                    var drugStore = _drugStoreRepository.Get(ds => ds.Id == drugStoreId);
                    if (drugStore != null)
                    {
                        if (drugStore.Drugs.Count > 0)
                        {
                        Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please choose one of the drugs from the list by id");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Drug list");
                            foreach (var drug in drugStore.Drugs)
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {drug.Id}, Name :{drug.Name}, Price: {drug.Price}");
                            }
                            string Id = Console.ReadLine();
                            int choosenId;
                            result = int.TryParse(Id, out choosenId);
                            if (result)
                            {
                                var drug = _drugRepository.Get(d => d.Id == choosenId);
                                if (drug != null)
                                {
                                    Digits: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "please enter the amount of the drug you want to buy");
                                    string amount = Console.ReadLine();
                                    int drugAmount;
                                    result = int.TryParse(amount, out drugAmount);
                                    if (result)
                                    {
                                        if(drugAmount <= drug.Amount)
                                        {
                                        double soldDrugsPrice = drugAmount * drug.Price;
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"price is  : {soldDrugsPrice}");
                                            MoneyInDigits: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the displayed amount of money to buy drug");
                                            string amountOfMoney = Console.ReadLine();
                                             double damountOfMoney;
                                            result = double.TryParse(amountOfMoney, out damountOfMoney);
                                            if (result)
                                            {
                                                if (damountOfMoney == soldDrugsPrice)
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $" {drugAmount} {drug.Name} drug is sold");
                                                    drugStore.Drugs.RemoveRange(0, drugAmount);
                                                    double budget = drugStore.Budget + damountOfMoney;
                                                    drugStore.Budget = budget;
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"Budget is {drugStore.Budget}");
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Not enough money is provided, you can not buy the drug");
                                                    
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the money in digits");
                                                goto MoneyInDigits;

                                            }
                                        }
                                        else
                                        {

                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "drug store has not got that much drug");
                                            
                                        }
                                        
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please enter amount in digits");
                                        goto Digits;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug found with this id");
                                   
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please enter id in digits");
                                goto Digit;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no drug found in the store");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No Drug Store found as indicated with the id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found to buy drug from");
            }

        }
        #endregion


    }
}
