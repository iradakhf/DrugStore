using Core.Constants;
using Core.Helpers;
using Manager.Controllers;

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
                Initials: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please, select 1 for Owner, 2 for DrugStore, 3 for Druggist, 4 for Drug or 0 to exit");
                    string number = Console.ReadLine();

                    byte selectedNumber;
                    bool result = byte.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 4)
                        {
                            if (selectedNumber == 1)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit owner menu");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all owners");
                                string option = Console.ReadLine();
                                int choosenOption;
                                result = int.TryParse(option, out choosenOption);
                                if (result)
                                {
                                    if (choosenOption >= 0 && choosenOption <= 5)
                                    {
                                        OwnerController _ownerController = new OwnerController();
                                        switch (choosenOption)
                                        {
                                            case (int)Options1.CreateOwner:
                                                _ownerController.Create();
                                                goto Initials;
                                                break;
                                            case (int)Options1.UpdateOwner:
                                                _ownerController.Update();
                                                goto Initials;
                                                break;
                                            case (int)Options1.RemoveOwner:
                                                _ownerController.Delete();
                                                goto Initials;
                                                break;
                                            case (int)Options1.GetOwner:
                                                _ownerController.Get();
                                                goto Initials;
                                                break;
                                            case (int)Options1.GetAllOwners:
                                                _ownerController.GetAll();
                                                goto Initials;
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
                            
                            else if (selectedNumber == 2)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-get DrugStore");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-get all DrugStores");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6-get all DrugStores by owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "7-Sell drug");
                                string option = Console.ReadLine();
                                int choosenOption;
                                result = int.TryParse(option, out choosenOption);
                                if (result)
                                {
                                    if (choosenOption >= 0 && choosenOption <= 8)
                                    {
                                        DrugStoreController _drugStoreController = new DrugStoreController();
                                        switch (choosenOption)
                                        {
                                            case (int)Options2.CreateDrugStore:
                                                _drugStoreController.Create();
                                                goto Initials;
                                                break;
                                            case (int)Options2.UpdateDrugStore:
                                                _drugStoreController.Update();
                                                goto Initials;
                                                break;
                                            case (int)Options2.RemoveDrugStore:
                                                _drugStoreController.Delete();
                                                goto Initials;
                                                break;
                                            case (int)Options2.GetDrugStore:
                                                _drugStoreController.Get();
                                                goto Initials;
                                                break;
                                            case (int)Options2.GetAllDrugStores:
                                                _drugStoreController.GetAll();
                                                goto Initials;
                                            case (int)Options2.GetAllDrugStoresByOwner:
                                                _drugStoreController.GetAllDrugStoresByOwner();
                                                goto Initials;
                                                break;
                                               case(int)Options2.Sale:
                                                _drugStoreController.Sale();
                                                goto Initials;
                                                break;
                                            case (int)Options2.GetTheBudget:
                                                _drugStoreController.GetTheBudget();
                                                goto Initials;
                                                break;
                                            case (int)Options2.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from drug store menu");
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
                            else if (selectedNumber == 3)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit druggist menu");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update druggist");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete druggist");
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
                                            case (int)Options3.CreateDruggist:
                                                _druggistController.Create();
                                                goto Initials;
                                                break;
                                            case (int)Options3.UpdateDruggist:
                                                _druggistController.Update();
                                                goto Initials;
                                                break;
                                            case (int)Options3.RemoveDruggist:
                                                _druggistController.Delete();
                                                goto Initials;
                                                break;
                                            case (int)Options3.GetDruggist:
                                                goto Initials;
                                                _druggistController.Get();
                                                break;
                                            case (int)Options3.GetAllDruggists:
                                                _druggistController.GetAll();
                                                goto Initials;
                                                break;
                                            case (int)Options3.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from druggist");
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
                            else if (selectedNumber == 4)
                            {
                            Digit: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-exit drug menu");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-create drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-update drug");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-delete drug");
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
                                            case (int)Options4.CreateDrug:
                                                _drugController.Create();
                                                goto Initials;
                                                break;
                                            case (int)Options4.UpdateDrug:
                                                _drugController.Update();
                                                goto Initials;
                                                break;
                                            case (int)Options4.RemoveDrug:
                                                _drugController.Delete();
                                                goto Initials;
                                                break;
                                            case (int)Options4.GetDrug:
                                                _drugController.Get();
                                                goto Initials;
                                                break;
                                            case (int)Options4.GetAllDrugs:
                                                _drugController.GetAll();
                                                goto Initials;
                                                break;
                                            case (int)Options4.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "you exited from drug menu");
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
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You exited");
                                break;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Selection should be within 0-3");
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
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}