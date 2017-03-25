var MealsIndex = (function () {
    function MealsIndex() {
        var _this = this;
        this.newMeal = ko.observable(null);
        this.loadData = function () {
            _this.mealsTable.loadData();
        };
        this.delete = function (meal) {
            window.displayMessage('Confirm', 'Are you sure you want to delete \'' + meal.name() + '\'?', 'Yes', window.apiRoute('MealsApi', 'Delete'), _this.mealsTable.loadData, meal.id);
        };
        this.mealsTable = new MealsPagedTable(window.apiRoute('MealsApi', 'GetMeals'));
        this.newMeal(new MealViewModel());
    }
    return MealsIndex;
}());
//# sourceMappingURL=MealsIndex.js.map