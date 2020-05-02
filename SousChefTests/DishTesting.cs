using System;
using Xunit;
using Newtonsoft.Json;
using MealPlanner.Models;

namespace SousChefTests
{
    public class DishTesting
    {
        [Fact]
        public void SerializeTest()
        {
            Dish testDish = new Dish()
            {
                Name = "TestDish",
                Carbohydrates = 25,
                Calories = 100,
                Fat = 5,
                Protein = 10
            };

            string jsonObject = JsonConvert.SerializeObject(testDish, Formatting.None);

            Dish extractedDish = JsonConvert.DeserializeObject<Dish>(jsonObject);

            Assert.Equal(testDish.Name, extractedDish.Name);
            Assert.Equal(testDish.Carbohydrates, extractedDish.Carbohydrates);
            Assert.Equal(testDish.Calories, extractedDish.Calories);
            Assert.Equal(testDish.Fat, extractedDish.Fat);
            Assert.Equal(testDish.Protein, extractedDish.Protein);
        }
    }
}
