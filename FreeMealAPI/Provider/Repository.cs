using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeMealAPI.Provider;

namespace FreeMealAPI.Provider
{
    public class Repository
    {
        private readonly IFreeMealDataProvider m_provider;
        public Repository(IFreeMealDataProvider provider)
        {
            m_provider = provider;
        }

        public int CountMealsByArea(string area)
        {
            return m_provider.GetFilteredMealsByArea(area).Count();
        }

        public int CountMealsByLetter(string search)
        {
            return m_provider.GetMealsByLetter(search).Where(o => o.strMeal.StartsWith(search)).Count();
        }


    }
}
