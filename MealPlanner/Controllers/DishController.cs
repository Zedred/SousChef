using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SousChef.Models;
using Microsoft.AspNetCore.Mvc;

namespace SousChef.Controllers
{
    public class DishController : Controller
    {
        private IDishRepository _dishRepository;
        public DishController(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public ViewResult GetDish()
        {
            Dish dish = _dishRepository.GetDish(1);
            ViewData["Dish"] = dish;
            ViewData["Title"] = "Dish Results";
            return View(dish);
        }
    }
}