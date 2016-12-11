


var config = function ($stateProvider) {
    
$stateProvider
    .state("contacts", {
        url: "/contacts",
        templateUrl: "contactsIndex.html"
    })
};

angular.module("contacts").config(config);


		
