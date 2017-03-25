class MealsIndex {
    constructor() {
        this.mealsTable = new MealsPagedTable(window.apiRoute('MealsApi', 'GetMeals'));

        this.newMeal(new MealViewModel());
    }

    mealsTable: MealsPagedTable;
    newMeal: KnockoutObservable<MealViewModel> = ko.observable(null);

    loadData = () => {
        this.mealsTable.loadData();
    }

    delete = (meal: MealViewModel) => {
        window.displayMessage(
            'Confirm',
            'Are you sure you want to delete \'' + meal.name() + '\'?',
            'Yes',
            window.apiRoute('MealsApi', 'Delete'),
            this.mealsTable.loadData,
            meal.id);
    }
}