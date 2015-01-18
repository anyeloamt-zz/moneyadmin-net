$(document).ajaxStart(function() {
	toggleLoadingMask();
});
$(document).ajaxStop(function() {
	toggleLoadingMask();
	$(document).find('[title]').tooltip();
});
$(document).ajaxError(function() {
	alert("Se produjo un error en el request, por favor recarga la página");
	console.log("Se produjo un error en el request", arguments);
});

$(document).find('[title]').tooltip();

function loadPartial(url, divId, onCompleted) {
	$("#" + divId).load(url, onCompleted);
}

function toggleLoadingMask() {
	$('.loadingMask').fadeToggle();
}

$(function() {
	ko.bindingHandlers.fadeVisible = {
		init: function(element, valueAccessor) {
			$(element).toggle(ko.utils.unwrapObservable(valueAccessor()));
		},
		update: function(element, valueAccessor) {
			ko.utils.unwrapObservable(valueAccessor()) ? $(element).fadeIn() : $(element).fadeOut();
		}
	};

	ko.subscribable.fn.formatMoney = function(c, d, t) {
		var number = Number(this());
		if (!isNaN(number)) {
			return number.formatMoney(c, d, t);
		} else {
			throw new Error("Just number subscribable can formatMoney");
		}
	};
});