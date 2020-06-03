using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SousChef.Models
{
    public class Dish
    {
        public enum ServingMeasurement { oz = 0, g = 1, ml = 1 }
        public Dish() { }

        public Dish(int id, string name, string servingSize, int calories, int carbohydrates, int protein, int fat)
        {
            DishId = id;
            Name = name;
            ServingSize = servingSize;
            Calories = calories;
            Carbohydrates = carbohydrates;
            Protein = protein;
            Fat = fat;
        }

        [Key]
        [JsonProperty("dishId")]
        public int DishId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serving")]
        public string ServingSize { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("carbohydrates")]
        public int Carbohydrates { get; set; }

        [JsonProperty("protein")]
        public int Protein { get; set; }

        [JsonProperty("fat")]
        public int Fat { get; set; }

    }
}
