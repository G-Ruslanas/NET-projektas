using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using FreeMealAPI.Provider;
using System.Collections.Generic;

namespace MoqTestForProject
{
    [TestClass]
    public class MealsByAreaCountTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var provider = new Mock<IFreeMealDataProvider>(MockBehavior.Strict);
            var repo = new Repository(provider.Object);

            provider.Setup(m => m.GetFilteredMealsByArea("Polish")).Returns(new List<AreaModel>
            {
                new AreaModel {strMeal="Bigos (Hunters Stew)", idMeal="53018"},
                new AreaModel {strMeal="Gołąbki (cabbage roll)", idMeal="53021"},
                new AreaModel {strMeal="Paszteciki (Polish Pasties)", idMeal="53017"},
                new AreaModel {strMeal="Pierogi (Polish Dumplings)", idMeal="53019"},
                new AreaModel {strMeal="Polskie Naleśniki (Polish Pancakes)", idMeal="53022"},
                new AreaModel {strMeal="Rogaliki (Polish Croissant Cookies)", idMeal="53024"},
                new AreaModel {strMeal="Rosół (Polish Chicken Soup)", idMeal="53020"},
                new AreaModel {strMeal="Sledz w Oleju (Polish Herrings)", idMeal="53023"},

            });
            Assert.AreEqual(8, repo.CountMealsByArea("Polish"));

            provider.Setup(m => m.GetFilteredMealsByArea("Spanish")).Returns(new List<AreaModel>
            {
                new AreaModel {strMeal="Roast fennel and aubergine paella", idMeal="52942"},
                new AreaModel {strMeal="Seafood fideuà", idMeal="52836"},
                new AreaModel {strMeal="Spanish Tortilla", idMeal="52872"},
            });
            Assert.AreEqual(3, repo.CountMealsByArea("Spanish"));
        }
    }
}
