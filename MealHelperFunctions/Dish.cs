using System;
using System.Collections.Generic;
using System.Text;

namespace MealLib
{
    public class Dish
    {
        public string Recipe { get; set; }      // Title of the recipe
        public float Calories { get; set; }     // Total calories
        public float Carbs { get; set; }        // Grams carbs
        public float Fat { get; set; }          // Grams fat
        public float Protein { get; set; }      // Grams protein
    }
}
