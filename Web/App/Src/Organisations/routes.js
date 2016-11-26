


var config = function ($stateProvider, requireLogin) {
    
$stateProvider
    .state("organisations", {
        url: "/organisations",
        templateUrl: "Index.html"
    })
    .state("organisation", {
        url: "/organisation/:id",
        templateUrl: "Details.html"
    });
};

angular.module("Contacts").config(config);



	
		
