class MealViewModel {
    constructor(public id?: number, meal?: any) {
        if (meal) {
            this.loadFromJson(meal);
        }
    }

    saving: KnockoutObservable<boolean> = ko.observable(false);
    name: KnockoutObservable<string> = ko.observable('');

    loadFromJson = (meal: any) => {
        this.name(meal.name);
    }

    save = (callback?: () => any) => {
        this.saving(true);
        var route = window.apiRoute('MealsApi', 'Meal');
        var model = { name: this.name(), mealId: this.id }

        $.post(route, JSON.stringify(model), () => {
            this.saving(false);

            if (callback) {
                callback();
            }
        });
    }

    clear = () => {
        this.name('');
        this.id = null;
    }

    delete = () => {
        $.ajax({
            url: '/script.cgi',
            type: 'DELETE',
            success: function (result) {
                // Do something with the result
            }
        });
    }
}