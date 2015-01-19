var walletListObj, walletsContainer;

function initWalletScreen() {
    $.getJSON(Urls.Wallets.Recent).done(function(wallets) {
        var walletsArr = [];
        ko.utils.arrayForEach(wallets, function (wallet) {
            var walletVm = new WalletViewModel();
            ko.mapping.fromJS(wallet, {}, walletVm);
            walletsArr.push(walletVm);
        });
        walletListObj = new WalletList(walletsArr);
        walletsContainer = $('#walletsContainer')[0];
        ko.applyBindings(walletListObj, walletsContainer);
    });
}