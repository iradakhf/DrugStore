﻿

using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manager.Controllers
{
    public class OwnerController
    {
        private static int id;
        private OwnerRepository _ownerRepository;


        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();

        }

        #region CreateOwner
        public void Create()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter Owner's name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter owner's surname");
            string surname = Console.ReadLine();
        Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter owner's age");
            string Age = Console.ReadLine();
            byte age;
            bool result = byte.TryParse(Age, out age);
            if (result)
            {
                Owner owner = new Owner();
                owner.Name = name;
                owner.Surname = surname;
                owner.Age = age;
                _ownerRepository.Create(owner);
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter age in digits");
                goto Age;
            }

        }


        #endregion
        #region UpdateOwner
        public void Update()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the owners by id");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {owner.Id}, Name :{owner.Name}," +
                        $" surname: {owner.Surname}, Age:  {owner.Age}");
                }
                string id = Console.ReadLine();
                int ownerId;
                bool result = int.TryParse(id, out ownerId);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == ownerId);
                    if (owner != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter owner's new name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter owner's new surname");
                        string surname = Console.ReadLine();
                    Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter owner's new age");
                        string age = Console.ReadLine();
                        byte newAge;
                        result = byte.TryParse(age, out newAge);
                        if (result)
                        {

                            Owner owner1 = new Owner();
                            owner1.Name = name;
                            owner1.Surname = surname;
                            owner1.Age = newAge;

                            _ownerRepository.Update(owner1);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Owner is successfully updated : id {owner1.Id}, Name: {owner1.Name}, surname :{owner1.Surname}, Age :{owner1.Age}");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter the age in the correct format");
                            goto Age;
                        }
                    }
                    else
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found as indicated");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found to update");
            }
        }
        #endregion
        #region DeleteOwner
        public void Delete()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the owners by ID");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {owner.Id}, Name :{owner.Name}, surname: {owner.Surname}, age :{owner.Age}");
                }
                string id = Console.ReadLine();
                int ownerId;
                bool result = int.TryParse(id, out ownerId);
                if (result)
                {
                    var owner = _ownerRepository.Get(ds => ds.Id == ownerId);
                    if (owner != null)
                    {
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"Owner : {owner.Name} is successfully deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No Owner found as indicated");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found to delete");
            }

        }
        #endregion
        #region GetDrugStore
        public void Get()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please, choose one of the owners by id");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID: {owner.Id}, Name :{owner.Name}, Surname :{owner.Surname}");
                }
                string id = Console.ReadLine();
                int ownerId;
                bool result = int.TryParse(id, out ownerId);
                if (result)
                {
                    var owner = _ownerRepository.Get(ds => ds.Id == ownerId);
                    if (owner != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Id : {owner.Id}, Name : {owner.Name}");
                    }
                    else
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No Owner found as indicated");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found to get information about");
            }


        }
        #endregion
        #region GetAllDrugStores
        public void GetAll()
        {

            DrugStore drugStore1 = new DrugStore();
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "All Drug Stores");
                foreach (var owner in owners)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id : {owner.Id} Name : {owner.Name} Surname : {owner.Surname} Age: {owner.Age}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No owner found");
            }

        }
        #endregion


    }
}
