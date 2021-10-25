using Microsoft.AspNetCore.Mvc;
using RistoWeb.Models;
using RistoWeb.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RistoWeb.Repository;

namespace RistoWeb.Controllers
{
    public class HomeController : Controller
    {
        private DBManagerRepo dbManager;
        public HomeController(DBManagerRepo dbManager)
        {
            this.dbManager = dbManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Location()
        {
            return View();
        }
        public IActionResult SignIn(string email, string password)
        {
            if (email != null && password != null)
            {
                if (dbManager.SignIn(email, password))
                    return View("Index");
                else
                    return View(false);
            }
            else
                return View(true);
        }
        public IActionResult LogOut()
        {
            dbManager.LogOut();
            return View("Index");
        }
        public IActionResult Register(string firstname, string lastname, string email, string password)
        {
            User user = new User()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Password = password
            };
            UserModel model = new UserModel()
            {
                user = user,
                userState = dbManager.Register(user)
            };
            return View(model);
        }
        public IActionResult DailyMenu()
        {
            return View(dbManager.GetDailyMenu());
        }
        public IActionResult Reservation(DateTime date, int seats, bool lunch, bool dinner)
        {
            return View(dbManager.Reserve(date, seats, lunch, dinner));
        }
        public IActionResult CancelReservation()
        {
            List<Reservation> reservations = dbManager.GetUserReservation();
            if (reservations.Count > 0)
                return View(reservations);
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ViewAllUsers()
        {
            return View(dbManager.GetAllUsers());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
