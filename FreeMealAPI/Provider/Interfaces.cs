using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeMealAPI.Provider
{

    public interface IFreeMealDataProvider
    {
        IList<CategoriesModel> GetCategories();
        IList<MealModel> GetRandomMeal();
        IList<MealsModel> GetMealsByLetter(string search);
        IList<AreaModel> GetFilteredMealsByArea(string area);

    }

}
