interface Window {
    apiRoute(controllerName: string, actionName: string): string;
    displayMessage(title: string, message: string, yesButton: string, confirmRoute: string, callback: () => any, id?: number): void;
    confirmFunction(): any;
    confirmCallback(callback?: () => any): any;

    id: number;
    confirmRoute: string;
}

window.displayMessage = (title: string, message: string, yesButton: string, confirmRoute: string, callback: () => any, id?: number) => {
    $('#confirm-modal-title').text(title);
    $('#confirm-modal-message').text(message);
    $('#confirm-modal-yesButton').text(yesButton);
    (<any>$('#confirm-modal')).modal('show');
    window.confirmRoute = confirmRoute;
    window.confirmCallback = callback;
    window.id = id;
};

window.confirmFunction = () => {
    $.ajax({
        url: window.confirmRoute + '?' + $.param({ "id": window.id }),
        type: 'DELETE',
        success: (data: any) => {
            if (window.confirmCallback) {
                window.confirmCallback(() => { (<any>$('#confirm-modal')).modal('hide'); });
            }
        }
    });
}

window.apiRoute = (controllerName: string, actionName: string): string => {
    return 'https://localhost:50355/api/' + controllerName + '/' + actionName; 
};