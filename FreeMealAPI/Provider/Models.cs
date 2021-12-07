using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeMealAPI.Provider
{
    public class CategoriesModel
    {
        public string idCategory { get; set; }
        public string strCategory { get; set; }
        public string strCategoryThumb { get; set; }
        public string strCategoryDescription { get; set; }
    }

    public class MealModel
    {
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strArea { get; set; }
        public string strInstructions { get; set; }
        public string strMealThumb { get; set; }
        public string strYoutube { get; set; }
    }

    public class MealsModel
    {
        public string strMeal { get; set; }
        public string strCategory { get; set; }
        public string strArea { get; set; }
        public string strTags { get; set; }
    }
    public class AreaModel
    {
        public string strMeal { get; set; }
        public string idMeal { get; set; }
    }

}
