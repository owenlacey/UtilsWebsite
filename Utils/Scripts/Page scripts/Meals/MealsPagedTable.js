var MealsPagedTable = (function () {
    function MealsPagedTable(sourceUrl) {
        var _this = this;
        this.searchTerm = ko.observable(null);
        this.loadData = function (callback) {
            _this.loading(true);
            var model = { searchTerm: _this.searchTerm() };
            $.get(_this.sourceUrl, model, function (data) {
                if (data) {
                    _this.data(ko.utils.arrayMap(data, function (datum) {
                        return new MealViewModel(datum.id, datum);
                    }));
                }
                if (callback) {
                    callback();
                }
                _this.loading(false);
            });
        };
        this.sourceUrl = sourceUrl;
        this.loading = ko.observable(false);
        this.data = ko.observableArray([]);
        this.searchTerm.subscribe(function () {
            _this.loadData();
        });
    }
    return MealsPagedTable;
}());
//# sourceMappingURL=MealsPagedTable.js.map