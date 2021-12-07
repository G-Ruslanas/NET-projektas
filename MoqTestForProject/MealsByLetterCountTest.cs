using FreeMealAPI.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace MoqTestForProject
{
    [TestClass]
    public class MealsByLetterCountTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var provider = new Mock<IFreeMealDataProvider>(MockBehavior.Strict);
            var repo = new Repository(provider.Object);
            provider.Setup(m => m.GetMealsByLetter("A")).Returns(new List<MealsModel>
            {
                    new MealsModel {strMeal = "Apple Frangipan Tart", strCategory = "Dessert", strArea = "British", strTags = "Tart,Baking,Fruity"},
                    new MealsModel {strMeal = "Apple & Blackberry Crumble", strCategory = "Dessert", strArea = "British", strTags = "Pudding"},
                    new MealsModel {strMeal = "Apam balik", strCategory = "Dessert", strArea = "Malaysian", strTags = ""},
                    new MealsModel {strMeal = "Ayam Percik", strCategory = "Chicken", strArea = "Malaysian", strTags = ""},
            });
            Assert.AreEqual(4, repo.CountMealsByLetter("A"));

            provider.Setup(m => m.GetMealsByLetter("W")).Returns(new List<MealsModel>
            {
                    new MealsModel {strMeal = "White chocolate creme brulee", strCategory = "Dessert", strArea = "French", strTags = "Desert,DinnerParty,Pudding"},
                    new MealsModel {strMeal = "Wontons", strCategory = "Pork", strArea = "Chinese", strTags = "MainMeal"},
                    new MealsModel {strMeal = "Walnut Roll Gužvara", strCategory = "Dessert", strArea = "Croatian", strTags = "Nutty"},
            });
            Assert.AreEqual(3, repo.CountMealsByLetter("W"));

            provider.Setup(m => m.GetMealsByLetter("Q")).Returns(new List<MealsModel>());

            Assert.AreEqual(0, repo.CountMealsByLetter("Q"));
        }
    }
}
