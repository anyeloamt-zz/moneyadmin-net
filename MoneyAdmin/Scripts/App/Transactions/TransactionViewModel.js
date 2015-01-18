var TransactionViewModel = function() {
	var self = this;
	
	self.Id = ko.observable();
	self.Note = ko.observable();
	self.Amount = ko.observable();	
	self.WalletId = ko.observable();
	self.CategoryId = ko.observable();
	
	self.Wallet = ko.observable();
	self.Category = ko.observable();
	self.Files = ko.observableArray();	

	self.AddFiles = ko.observable(false);
	
	self.WalletAvailableBalance = undefined;

	self.init = function() {
		self.WalletAvailableBalance = self.Wallet().AvailableBalance();
	};

	self.save = function() {
		
	};

	self.cancel = function() {
		
	};

	self.Amount.subscribe(function(value) {
		if (!self.Wallet()) return;
		self.Wallet().AvailableBalance(self.WalletAvailableBalance - value);
	});
};

TransactionViewModel.prototype = Object.create(ViewModel.prototype);
TransactionViewModel.prototype.constructor = TransactionViewModel;