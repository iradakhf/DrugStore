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
