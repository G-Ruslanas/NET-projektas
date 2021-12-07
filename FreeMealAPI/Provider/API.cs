using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreeMealAPI.Provider
{
    public class API : IFreeMealDataProvider
    {
        private IRestClient m_client;

        public API(IRestClient restClient)
        {
            m_client = restClient;
        }

        public API()
        {
            m_client = new RestClient($"https://themealdb.com/api/json/v1/1/");
            m_client.Timeout = -1;
        }
        public IList<CategoriesModel> GetCategories()
        {
            var request = new RestRequest($"categories.php", Method.GET);
            IRestResponse response = m_client.Execute(request);
            JObject o = JObject.Parse(response.Content);
            List<CategoriesModel> list = JsonConvert.DeserializeObject<List<CategoriesModel>>(o["categories"].ToString());
            return list;
        }

        public IList<MealModel> GetRandomMeal()
        {
            var request = new RestRequest($"random.php", Method.GET);
            IRestResponse response = m_client.Execute(request);
            JObject o = JObject.Parse(response.Content);
            List<MealModel> list = JsonConvert.DeserializeObject<List<MealModel>>(o["meals"].ToString());
            return list;
        }
        public IList<MealsModel> GetMealsByLetter(string search)
        {
            var request = new RestRequest($"search.php?f={search}", Method.GET);
            IRestResponse response = m_client.Execute(request);
            JObject o = JObject.Parse(response.Content);
            List<MealsModel> list = JsonConvert.DeserializeObject<List<MealsModel>>(o["meals"].ToString());
            return list;
        }
        public IList<AreaModel> GetFilteredMealsByArea(string area)
        {
            var request = new RestRequest($"filter.php?a={area}", Method.GET);
            IRestResponse response = m_client.Execute(request);
            JObject o = JObject.Parse(response.Content);
            List<AreaModel> list = JsonConvert.DeserializeObject<List<AreaModel>>(o["meals"].ToString());
            return list;
        }

    }
}
