using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Controllers
{
    public class AdminController
    {
        private AdminRepository _adminRepository;
        public AdminController()
        {
            _adminRepository = new AdminRepository();
        }
        public Admin Authenticate()
        {
        AdminAutetication: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please enter the username");
            string username = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Please enter password");
            string password = Console.ReadLine();
            var admin = _adminRepository.Get(a => a.Name.ToLower() == username.ToLower() && PasswordHasher.Decrypt(a.Password) == password);
            return admin;
        }
        public void LogOut()
        {
            Authenticate();
        }
    }
}
