class MealsPagedTable {
    constructor(sourceUrl: string) {
        this.sourceUrl = sourceUrl;

        this.loading = ko.observable(false);

        this.data = ko.observableArray([]);

        this.searchTerm.subscribe(() => {
            this.loadData();
        });
    }

    sourceUrl: string;
    data: KnockoutObservableArray<MealViewModel>;
    loading: KnockoutObservable<boolean>;
    searchTerm: KnockoutObservable<string> = ko.observable(null);
    
    loadData = (callback?: () => any) => {
        this.loading(true);
        var model = { searchTerm: this.searchTerm() };
        $.get(this.sourceUrl, model, (data: any[]) => {
            if (data) {
                this.data(ko.utils.arrayMap(data, (datum: any) => {
                    return new MealViewModel(datum.id, datum);
                }));
            }

            if (callback) {
                callback();
            }
            this.loading(false);
        });
    }
}