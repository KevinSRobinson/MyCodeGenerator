var menuItems = {
    controllerAs:"vm",
    controller: function (authService,authManager, $rootScope){

        var vm = this;
        vm.isAuthenticated = $rootScope.isAuthenticated;

        vm.authService = authService;

        vm.logout = function(){
            console.log('loggin out');
            authManager.unauthenticate();
        };
    },
    templateUrl: "menuTemplate.html"
};


angular.module("contacts").component("menuItems", menuItems);