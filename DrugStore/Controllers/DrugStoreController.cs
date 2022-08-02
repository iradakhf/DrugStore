using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;


namespace Manager.Controllers
{
    public class DrugStoreController
    {
        private static int id;
        private DrugRepository _drugRepository;
        private DrugStoreRepository _drugStoreRepository;
        private OwnerRepository _ownerRepository;
        public DrugStoreController()
        {
            _drugRepository = new DrugRepository();
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
        }

        #region CreateDrugStore
        public void Create()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
             ID:   ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Please choose one of the owners by id to create drugstore for");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, $"owner's id : {owner.Id}, name: {owner.Surname}, surname : {owner.Surname}, age: {owner.Age}");
                }
                string Id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(Id, out choosenId);
                if (result)
                {
                    var owner = _ownerRepository.Get(o=> o.Id==choosenId);
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
                            Owner owner1 = new Owner();
                            owner.DrugStores.Add(drugStore);
                            _drugStoreRepository.Create(drugStore);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore is successfully created with the id {drugStore.Id}, Name: {drugStore.Name}, " +
                                $"address :{drugStore.Address} , contact number :{drugStore.ContactNumber}, owner : {drugStore.Owner}");

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
                        $" Address: {drugStore.Address}, Owner : {drugStore.Owner}");
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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore is successfully updated : id {newDrugStore.Id}, Name: {newDrugStore.Name}, address :{newDrugStore.Address}, Contact Number :{newDrugStore.ContactNumber}");

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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {drugStore.Id}, Name :{drugStore.Name}, Address: {drugStore.Address}");
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id : {drugStore.Id}, Name : {drugStore.Name}, Address : {drugStore.Address}, Contact Number: {drugStore.ContactNumber}");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "All Drug Stores");
                foreach (var drugStore in drugStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {drugStore.Id} Name : {drugStore.Name} Address : {drugStore.Address} Contact Number: {drugStore.ContactNumber}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drugStore found");
            }

        }
        #endregion
        

    }
}
