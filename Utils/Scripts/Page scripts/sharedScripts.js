window.displayMessage = function (title, message, yesButton, confirmRoute, callback, id) {
    $('#confirm-modal-title').text(title);
    $('#confirm-modal-message').text(message);
    $('#confirm-modal-yesButton').text(yesButton);
    $('#confirm-modal').modal('show');
    window.confirmRoute = confirmRoute;
    window.confirmCallback = callback;
    window.id = id;
};
window.confirmFunction = function () {
    $.ajax({
        url: window.confirmRoute + '?' + $.param({ "id": window.id }),
        type: 'DELETE',
        success: function (data) {
            if (window.confirmCallback) {
                window.confirmCallback(function () { $('#confirm-modal').modal('hide'); });
            }
        }
    });
};
window.apiRoute = function (controllerName, actionName) {
    return 'https://localhost:50355/api/' + controllerName + '/' + actionName;
};
//# sourceMappingURL=sharedScripts.js.map