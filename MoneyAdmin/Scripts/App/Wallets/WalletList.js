var WalletList = function(wallets) {
	var self = this;

	self.wallets = ko.observableArray(wallets || [new WalletViewModel()]);
};