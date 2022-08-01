using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manager.Controllers
{
    public class DruggistController
    {
        private static int id;
        public DruggistRepository _druggistRepository;
        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
        }
        #region CreateDruggist
        public void Create()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's surname");
            string surname = Console.ReadLine();
        Number: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Druggist's Age");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"DrugStore is successfully created with the id {druggist.Id}, Name: {druggist.Name}, surname :{druggist.Surname} , age :{druggist.Age}");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter DrugStore's age in the correct format");
                goto Number;
            }
        }
        #endregion
        #region UpdateDruggist
        public void Update()
        {

        }
        #endregion
        #region DeleteDruggist
        public void Delete()
        {

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
