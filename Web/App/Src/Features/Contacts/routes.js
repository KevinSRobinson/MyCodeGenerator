


var config = function ($stateProvider) {
    
$stateProvider
    .state("contacts", {
        url: "/contacts",
        templateUrl: "contactsIndex.html",
         data: {
                requireLogin: true
            }
    })
};

angular.module("contacts").config(config);


		
