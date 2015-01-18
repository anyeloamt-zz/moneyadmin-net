var CategoryViewModel = function () {
    var self = this;

    self.Id = ko.observable();
    self.Name = ko.observable();
};

CategoryViewModel.prototype = Object.create(ViewModel.prototype);
CategoryViewModel.prototype.constructor = CategoryViewModel;