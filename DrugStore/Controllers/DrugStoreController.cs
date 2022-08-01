using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;


namespace Manager.Controllers
{
    public class DrugStoreController
    {
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
                    var drugStore = _drugRepository.Get(ds => ds.Id == drugStoreId);
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
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Drus is successfully created with the id {drug.Id}, Name: {drug.Name} price :{drug.Price} amount :{drug.Amount}");

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
        #region UpdateDrugStore
        public void Update()
        {

        }
        #endregion
        #region DeleteDrugStore
        public void Delete()
        {

        }
        #endregion
        #region GetDrugStore
        public void Get()
        {

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
