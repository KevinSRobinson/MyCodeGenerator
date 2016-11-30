


var config = function ($stateProvider) {
    
$stateProvider
    .state("organisations", {
        url: "/organisations",
        templateUrl: "organisations.html"
    })
    .state("organisation", {
        url: "/organisation/:id",
        templateUrl: "organisation.html"
    });
};

angular.module("contacts").config(config);



	
		
