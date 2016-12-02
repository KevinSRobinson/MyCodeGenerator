var homeController =  function HomeController(authService) {

    var vm = this;
    vm.authService = authService;
 console.log(vm.authService.isAuthenticated);
};





angular.module('contacts').controller('homeController', homeController);