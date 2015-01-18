
$(document).ajaxStart(function () {
    toggleLoadingMask();
});
$(document).ajaxStop(function () {
    toggleLoadingMask();
    $(document).find('[title]').tooltip();
});
$(document).ajaxError(function () {
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