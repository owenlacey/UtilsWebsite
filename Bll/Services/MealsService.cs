using Bll.Services.Interfaces;
using Dal;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class MealsService : IMealsService, IBaseService<Meal>
    {
        public readonly MealsContext Context;
        public MealsService()
        {
            Context = new MealsContext();
        }

        public List<Meal> GetMeals(string searchTerm)
        {
            var meals = Context.Meals.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                meals = meals.Where(m => m.Name.ToUpper().Contains(searchTerm.ToUpper()));
            }

            meals.OrderBy(m => m.Name);

            return meals.ToList();
        }

        public Meal GetOrCreate(int? id)
        {
            return id.HasValue
                ? Context.Meals.Single(m => m.MealId == id.Value)
                : new Meal();
        }

        public void AddOrUpdate(Meal meal)
        {
            var mealToSave = Context.Meals.SingleOrDefault(m => m.MealId == meal.MealId);
            if (mealToSave != null)
            {
                Context.Entry(mealToSave).CurrentValues.SetValues(meal);
            }
            else
            {
                Context.Meals.Add(meal);
            }
            Context.SaveChanges();
        }

        public void Remove(int mealId)
        {
            var meal = Context.Meals.Find(mealId);
            Context.Meals.Remove(meal);
            Context.SaveChanges();
        }
    }
}
