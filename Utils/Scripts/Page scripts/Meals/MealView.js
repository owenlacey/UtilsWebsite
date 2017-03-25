var MealViewModel = (function () {
    function MealViewModel(id, meal) {
        var _this = this;
        this.id = id;
        this.saving = ko.observable(false);
        this.name = ko.observable('');
        this.loadFromJson = function (meal) {
            _this.name(meal.name);
        };
        this.save = function (callback) {
            _this.saving(true);
            var route = window.apiRoute('MealsApi', 'Meal');
            var model = { name: _this.name(), mealId: _this.id };
            $.post(route, JSON.stringify(model), function () {
                _this.saving(false);
                if (callback) {
                    callback();
                }
            });
        };
        this.clear = function () {
            _this.name('');
            _this.id = null;
        };
        this.delete = function () {
            $.ajax({
                url: '/script.cgi',
                type: 'DELETE',
                success: function (result) {
                    // Do something with the result
                }
            });
        };
        if (meal) {
            this.loadFromJson(meal);
        }
    }
    return MealViewModel;
}());
