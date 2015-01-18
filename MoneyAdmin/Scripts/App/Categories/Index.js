var CategoryList = function(categories) {
    this.categories = ko.observableArray();
}

var categoryList = new CategoryList;
var categoriesContainer;

function initCategoryScreen() {
    $.getJSON(Urls.Categories.All).done(function (response) {
        ko.utils.arrayForEach(response, function(category) {
            var categoryVm = ko.mapping.fromJS(category, {}, new CategoryViewModel);
            categoryList.categories.push(categoryVm);
        });
        categoriesContainer = $('#categoriesContainer').get(0);
        ko.applyBindings(categoryList, categoriesContainer);
    });
}