var transactionContainer, transactionVm;

var categoriesVm = ko.observableArray();

function initTransactionForm(transactionJson) {
    transactionContainer = $('#transactionContainer').get(0);
    var mapping = {
        'Wallet': {
            create: function(options) {
                return ko.mapping.fromJS(options.data, {}, new WalletViewModel);
            }
        }
    };
    transactionVm = ko.mapping.fromJS(transactionJson, mapping, new TransactionViewModel);
    transactionVm.init();
    ko.applyBindings(transactionVm, transactionContainer);
}