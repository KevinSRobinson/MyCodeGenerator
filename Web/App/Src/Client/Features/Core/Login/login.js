
 var loginController = function( authService ) {
    var vm = this;
    vm.authService = authService;
    console.log(authService);
 };


 angular.module('contacts').controller("loginController", loginController);