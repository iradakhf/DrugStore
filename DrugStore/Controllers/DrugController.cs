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
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drug's name");
            string name = Console.ReadLine();
        Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter drug's price");
            string price = Console.ReadLine();
            double drugPrice;
            bool result = double.TryParse(price, out drugPrice);
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








        #endregion
        #region UpdateDrug
        public void Update()
        {
            var drugs = _drugRepository.GetAll();
            if(drugs.Count> 0)
            {
              Id:  ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the drugs by id to update");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "all drugs");
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
                                drug.Name = newName;
                                drug.Price = newPrice;
                                drug.Amount = newAmount;
                                _drugRepository.Update(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"new name is : {drug.Name}, new price : {drug.Price}, new amount {drug.Amount}");
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, choose the correct id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No drug found");
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
