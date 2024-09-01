using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authentication.Data;
using authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        // The Index Page (Register Form) ==>
        public IActionResult Register()
        {
            return View();
        }

        // Create account =>
        [HttpPost]
        public IActionResult Register(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Login));
        }

        // Log in page (LogIn Form) =>
        public IActionResult Login()
        {
            return View();  
        }

        // LogIn =>
        [HttpPost]
        public IActionResult Login(User user)
        {
            var isAUser = dbContext.Users.Where(x => x.Name == user.Name && x.Password == user.Password);
            if (isAUser.Any())
            {
                return RedirectToAction(nameof(UsersActive));
            }
            ViewBag.Error = "Invalid UserName / Password";
            return View("Login", user);
        }

        // User Page (Just Not Active) =>
        public IActionResult UsersActive()
        {
            var AllUser = dbContext.Users.ToList();
            return View("ActiveUser", AllUser);
        }

        // Change The User To Active =>
        public IActionResult ConvertToActive(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound(); 
            }

            user.IsAvtive = true; 
            dbContext.SaveChanges();

            return RedirectToAction(nameof(UsersActive));
        }
    }
}
