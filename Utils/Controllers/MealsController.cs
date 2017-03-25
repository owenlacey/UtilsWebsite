using Bll.Services.Interfaces;
using System.Web.Mvc;

namespace Utils.Controllers
{
    public class MealsController : Controller
    {
        protected readonly IMealsService _mealsService;

        public MealsController(IMealsService mealsService)
        {
            _mealsService = mealsService;
        }
        // GET: Meals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Meal(int? id)
        {
            _mealsService.GetOrCreate(id);
            return View();
        }
    }
}