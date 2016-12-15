


var config = function ($stateProvider) {
    
$stateProvider
    .state("contacts", {
        url: "/contacts",
        templateUrl: "src/client/Features/Contacts/Views/index.html"
    }) 
};

angular.module("contacts").config(config);


		
