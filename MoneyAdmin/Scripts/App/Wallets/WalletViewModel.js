var WalletViewModel = function(name) {
	var self = this;

	self.Id = ko.observable();
	self.Name = ko.observable(name);
	self.InitialBalance = ko.observable();
	self.AvailableBalance = ko.observable();

	self.Transactions = ko.observableArray();

	self.hasTransactions = function() {
		return self.Transactions().length > 0;
	};

	self.actionClass = ko.pureComputed(function() {
		return self.hasTransactions() ? "col-md-6 col-xs-6" : "col-md-12 col-xs-12";
	});

	self.addTransaction = function() {
		loadPartial(Urls.Transactions.New + "?walletId=" + self.Id(), container);
	};

	self.viewTransactions = function() {
		console.log("VIEW TRANSACTIONS");
	};
};

WalletViewModel.prototype = Object.create(ViewModel.prototype);
WalletViewModel.prototype.constructor = WalletViewModel;