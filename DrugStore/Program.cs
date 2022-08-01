using Core.Constants;
using Core.Helpers;
using Manager.Controllers;
using System;
namespace Manager
{
    public class Program
    {


        private DruggistController _druggistController;
        private DrugStoreController _drugStoreController;
        private AdminController _adminController;
        public Program()
        {

            _druggistController = new DruggistController();
            _drugStoreController = new DrugStoreController();
            _adminController = new AdminController();
        }
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                Digits: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please, select 1 for Drug, 2 for Druggist, 3 for Drugstore or 0 to exit");
                    string number = Console.ReadLine();

                    byte selectedNumber;
                    bool result = byte.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 3)
                        {
                            if (selectedNumber == 1)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit drug menu");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-delete drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-update drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all drugs");
                                string option = Console.ReadLine();
                                int choosenOption;
                                result = int.TryParse(option, out choosenOption);
                                if (result)
                                {
                                    if (choosenOption >= 0 && choosenOption <= 5)
                                    {
                                        DrugController _drugController = new DrugController();
                                        switch (choosenOption)
                                        {
                                            case (int)Options1.CreateDrug:
                                                _drugController.Create();
                                                break;
                                            case (int)Options1.UpdateDrug:
                                                _drugController.Update();
                                                break;
                                            case (int)Options1.RemoveDrug:
                                                _drugController.Delete();
                                                break;
                                            case (int)Options1.GetDrug:
                                                _drugController.Get();
                                                break;
                                            case (int)Options1.GetAllDrugs:
                                                _drugController.GetAll();
                                                break;
                                            case (int)Options1.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited");
                                                return;

                                        }

                                    }
                                    else
                                    {

                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-5");
                                        goto Digit;
                                    }

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be in digits");
                                    goto Digit;
                                }

                            }
                            else if (selectedNumber == 2)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit druggist menu");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-delete druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-update druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all druggists");
                                string option = Console.ReadLine();
                                int choosenOption;
                                result = int.TryParse(option, out choosenOption);
                                if (result)
                                {
                                    if (choosenOption >= 0 && choosenOption <= 5)
                                    {
                                        DruggistController _druggistController = new DruggistController();
                                        switch (choosenOption)
                                        {
                                            case (int)Options2.CreateDruggist:
                                                _druggistController.Create();
                                                break;
                                            case (int)Options2.UpdateDruggist:
                                                _druggistController.Update();
                                                break;
                                            case (int)Options2.RemoveDruggist:
                                                _druggistController.Delete();
                                                break;
                                            case (int)Options2.GetDruggist:
                                                _druggistController.Get();
                                                break;
                                            case (int)Options2.GetAllDruggists:
                                                _druggistController.GetAll();
                                                break;
                                            case (int)Options2.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited");
                                                return;


                                        }

                                    }
                                    else
                                    {

                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-5");
                                        goto Digit;
                                    }

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be in digits");
                                    goto Digit;
                                }

                            }
                            else if (selectedNumber == 3)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-delete DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-update DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all DrugStores");
                                string option = Console.ReadLine();
                                int choosenOption;
                                result = int.TryParse(option, out choosenOption);
                                if (result)
                                {
                                    if (choosenOption >= 0 && choosenOption <= 5)
                                    {
                                        DrugStoreController _drugStoreController = new DrugStoreController();
                                        switch (choosenOption)
                                        {
                                            case (int)Options3.CreateDrugStore:
                                                _drugStoreController.Create();
                                                break;
                                            case (int)Options3.UpdateDrugStore:
                                                _drugStoreController.Update();
                                                break;
                                            case (int)Options3.RemoveDrugStore:
                                                _drugStoreController.Delete();
                                                break;
                                            case (int)Options3.GetDrugStore:
                                                _drugStoreController.Get();
                                                break;
                                            case (int)Options3.GetAllDrugStores:
                                                _drugStoreController.GetAll();
                                                break;
                                            case (int)Options3.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited");
                                                return;


                                        }

                                    }
                                    else
                                    {

                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-5");
                                        goto Digit;
                                    }

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be in digits");
                                    goto Digit;
                                }

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You exited");
                                break;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-3");
                            goto Digits;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be digit");
                        goto Digits;
                    }

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}