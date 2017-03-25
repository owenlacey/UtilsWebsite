using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services.Interfaces
{
    public interface IMealsService
    {
        List<Meal> GetMeals(string searchTerm);

        Meal GetOrCreate(int? id);

        void AddOrUpdate(Meal meal);

        void Remove(int mealId);
    }
}
