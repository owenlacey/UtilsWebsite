using Bll.Services;
using Bll.Services.Interfaces;
using Dal.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Utils.Models.Shared;

namespace Utils.Controllers.API
{
    public class MealsApiController : ApiController
    {
        protected readonly IMealsService _mealsService;

        public MealsApiController ()
        {
            _mealsService = new MealsService();
        }

        #region Get
        [HttpGet]
        public HttpResponseMessage GetMeals(string searchTerm)
        {
            var dbMeals = _mealsService.GetMeals(searchTerm);
            var model = dbMeals.Select(m => new IdNameJsonModel
            {
                Id = m.MealId,
                Name = m.Name
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<HttpResponseMessage> Meal(HttpRequestMessage request)
        {
            var content = await request.Content.ReadAsStringAsync();
            var meal =  JsonConvert.DeserializeObject<IdNameJsonModel>(content);

            var mealToSave = new Meal
            {
                MealId = meal.Id,
                Name = meal.Name
            };

            _mealsService.AddOrUpdate(mealToSave);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        { 
            _mealsService.Remove(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion
    }
}
