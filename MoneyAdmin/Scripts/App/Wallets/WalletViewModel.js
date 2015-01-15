
var WalletViewModel = function (name) {
	var self = this;

	self.Id = ko.observable();
	self.Name = ko.observable(name);
	self.InitialBalance = ko.observable();
	self.AvailableBalance = ko.observable();

	self.Transactions = ko.observableArray();
};

WalletViewModel.prototype = Object.create(ViewModel.prototype);
WalletViewModel.prototype.constructor = WalletViewModel;