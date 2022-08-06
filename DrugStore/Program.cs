using Core.Constants;
using Core.Helpers;
using Manager.Controllers;

namespace Manager
{
    public class Program
    {

        public static void Main(string[] args)
        {

            while (true)
            {
                AdminController _adminController = new AdminController();
            AdminAutetication: var admin = _adminController.Authenticate();
                if (admin != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Welcome {admin.Name}");
                    Console.WriteLine("   ");

                    while (true)
                    {


                    Initials: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please, select one of the displayed ");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "1 for Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "2 for DrugStore ");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "3 for Druggist ");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "4 for Drug  ");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "0 for log out ");
                        string number = Console.ReadLine();

                        int selectedNumber;
                        bool result = int.TryParse(number, out selectedNumber);
                        if (result)
                        {
                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {
                                    case 1:
                                        while (true)
                                        {

                                        Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit owner menu");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create owner");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update owner");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete owner");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get owner");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all owners");
                                            string option1 = Console.ReadLine();
                                            int choosenOption1;
                                            result = int.TryParse(option1, out choosenOption1);
                                            if (result)
                                            {
                                                if (choosenOption1 >= 0 && choosenOption1 <= 5)
                                                {
                                                    OwnerController _ownerController = new OwnerController();
                                                    switch (choosenOption1)
                                                    {
                                                        case (int)Options1.CreateOwner:
                                                            _ownerController.Create();
                                                            goto Digit;
                                                            break;
                                                        case (int)Options1.UpdateOwner:
                                                            _ownerController.Update();
                                                            goto Digit;
                                                            break;
                                                        case (int)Options1.RemoveOwner:
                                                            _ownerController.Delete();
                                                            goto Digit;
                                                            break;
                                                        case (int)Options1.GetOwner:
                                                            _ownerController.Get();
                                                            goto Digit;
                                                            break;
                                                        case (int)Options1.GetAllOwners:
                                                            _ownerController.GetAll();
                                                            goto Digit;
                                                            break;
                                                        case (int)Options1.Exit:
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from owner menu");
                                                            goto Initials;

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
                                        break;

                                    case 2:
                                        while (true)
                                        {
                                        Digit1: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit DrugStore");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create DrugStore");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update DrugStore");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete DrugStore");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get DrugStore");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all DrugStores");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6-get all DrugStores by owner");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "7-Sell drug");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "8-get the budget");
                                            string option2 = Console.ReadLine();
                                            int choosenOption2;
                                            result = int.TryParse(option2, out choosenOption2);
                                            if (result)
                                            {
                                                if (choosenOption2 >= 0 && choosenOption2 <= 8)
                                                {
                                                    DrugStoreController _drugStoreController = new DrugStoreController();
                                                    switch (choosenOption2)
                                                    {
                                                        case (int)Options2.CreateDrugStore:
                                                            _drugStoreController.Create();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.UpdateDrugStore:
                                                            _drugStoreController.Update();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.RemoveDrugStore:
                                                            _drugStoreController.Delete();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.GetDrugStore:
                                                            _drugStoreController.Get();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.GetAllDrugStores:
                                                            _drugStoreController.GetAll();
                                                            goto Digit1;
                                                        case (int)Options2.GetAllDrugStoresByOwner:
                                                            _drugStoreController.GetAllDrugStoresByOwner();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.Sale:
                                                            _drugStoreController.Sale();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.GetTheBudget:
                                                            _drugStoreController.GetTheBudget();
                                                            goto Digit1;
                                                            break;
                                                        case (int)Options2.Exit:
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from drug store menu");
                                                            goto Initials;


                                                    }

                                                }
                                                else
                                                {

                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-5");
                                                    goto Digit1;
                                                }

                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be in digits");
                                                goto Digit1;
                                            }
                                        }



                                        break;
                                    case 3:
                                        while (true)
                                        {

                                        Digit2: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit druggist menu");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create druggist");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update druggist");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete druggist");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get druggist");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all druggists");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6-Get All Druggist By Drug Store");

                                            string option3 = Console.ReadLine();
                                            int choosenOption3;
                                            result = int.TryParse(option3, out choosenOption3);
                                            if (result)
                                            {
                                                if (choosenOption3 >= 0 && choosenOption3 <= 6)
                                                {
                                                    DruggistController _druggistController = new DruggistController();
                                                    switch (choosenOption3)
                                                    {
                                                        case (int)Options3.CreateDruggist:
                                                            _druggistController.Create();
                                                            goto Digit2;
                                                            break;
                                                        case (int)Options3.UpdateDruggist:
                                                            _druggistController.Update();
                                                            goto Digit2;
                                                            break;
                                                        case (int)Options3.RemoveDruggist:
                                                            _druggistController.Delete();
                                                            goto Digit2;
                                                            break;
                                                        case (int)Options3.GetDruggist:
                                                            _druggistController.Get();
                                                            goto Digit2;
                                                            break;
                                                        case (int)Options3.GetAllDruggists:
                                                            _druggistController.GetAll();
                                                            goto Digit2;
                                                            break;
                                                        case (int)Options3.GetAllDruggistByDrugStore:
                                                            _druggistController.GetAllDruggistByDrugStore();
                                                            goto Digit2;
                                                            break;
                                                        case (int)Options3.Exit:
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from druggist");
                                                            goto Initials;


                                                    }

                                                }
                                                else
                                                {

                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-5");
                                                    goto Digit2;
                                                }

                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be in digits");
                                                goto Digit2;
                                            }

                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                        Digit4: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit drug menu");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create drug");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update drug");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete drug");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get drug");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all drugs");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6-get all drugs by drug store");
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "7-filter");
                                            string option = Console.ReadLine();
                                            int choosenOption;
                                            result = int.TryParse(option, out choosenOption);
                                            if (result)
                                            {
                                                if (choosenOption >= 0 && choosenOption <= 7)
                                                {
                                                    DrugController _drugController = new DrugController();
                                                    switch (choosenOption)
                                                    {
                                                        case (int)Options4.CreateDrug:
                                                            _drugController.Create();
                                                            goto Digit4;
                                                            break;
                                                        case (int)Options4.UpdateDrug:
                                                            _drugController.Update();
                                                            goto Digit4;
                                                            break;
                                                        case (int)Options4.RemoveDrug:
                                                            _drugController.Delete();
                                                            goto Digit4;
                                                            break;
                                                        case (int)Options4.GetDrug:
                                                            _drugController.Get();
                                                            goto Digit4;
                                                            break;
                                                        case (int)Options4.GetAllDrugs:
                                                            _drugController.GetAll();
                                                            goto Digit4;
                                                            break;
                                                        case (int)Options4.GetAllDrugsByDrugStore:
                                                            _drugController.GetAllDrugsByDrugStore();
                                                            goto Digit4;
                                                        case (int)Options4.Filter:
                                                            _drugController.Filter();
                                                            goto Digit4;
                                                        case (int)Options4.Exit:
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from drug menu");
                                                            goto Initials;

                                                    }

                                                }
                                                else
                                                {

                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-5");
                                                    goto Digit4;
                                                }

                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be in digits");
                                                goto Digit4;
                                            }
                                        }


                                        break;

                                    case 0:
                                        
                                            _adminController.LogOut();
                                        break;


                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-4");
                                goto Initials;
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be digit");
                            goto Initials;
                        }
                    }

                }
                else
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please enter the correct password");
                    goto AdminAutetication;

                }
            }
        }


    }
}