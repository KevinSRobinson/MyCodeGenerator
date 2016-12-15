


var config = function ($stateProvider) {
    
$stateProvider
    .state("organisations", {
        url: "/organisations",
        templateUrl: "src/client/Features/Organisations/Views/index.html"
    }) 
};

angular.module("contacts").config(config);


		
