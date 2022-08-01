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
        public DrugStoreController()
        {
            _drugRepository = new DrugRepository();
            _drugStoreRepository = new DrugStoreRepository();
        }

        #region CreateDrugStore
        public void Create()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter DrugStore's name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter DrugStore's Address");
            string address = Console.ReadLine();
        Number: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter DrugStore's ContactNumber");
            string number = Console.ReadLine();
            int contactNumber;
            bool result = int.TryParse(number, out contactNumber);
            if (result)
            {
                DrugStore drugStore = new DrugStore();
                drugStore.Name = name;
                drugStore.Address = address;
                drugStore.ContactNumber = contactNumber.ToString();
                drugStore.Id = id;
                _drugStoreRepository.Create(drugStore);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore is successfully created with the id {drugStore.Id}, Name: {drugStore.Name}, address :{drugStore.Address} , contact number :{drugStore.ContactNumber}");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter DrugStore's ContactNumber in digits");
                goto Number;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug store found");
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id : {drugStore.Id} Name : {drugStore.Name} Address : {drugStore.Address} Contact Number: {drugStore.ContactNumber}");
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
        #region GetAllDrugStores
        public void GetAll()
        {

            DrugStore drugStore1 = new DrugStore();
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {

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
