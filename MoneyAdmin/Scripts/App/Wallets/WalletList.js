
var WalletList = function () { };

WalletList.prototype.wallets = ko.observableArray([WalletViewModel]);

WalletList.prototype.constructor = function(wallets) {
    this.wallets(wallets);
}