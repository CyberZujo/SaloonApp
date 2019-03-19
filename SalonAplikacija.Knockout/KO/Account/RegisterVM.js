$(function () {
    const container = document.querySelector('[data-ko-component="register-component"]');
    if (container) ko.applyBindings(new RegisterViewModel(), container);
});



export default class RegisterViewModel {
    constructor() {
        this.username = ko.observable(null);
        this.password = ko.observable(null);
        this.confirmPassword = ko.observable(null);
    }

    submit() {
        alert("Hello");
    }
    
    
}