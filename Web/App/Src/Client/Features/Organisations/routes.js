


var config = function ($stateProvider) {
    
$stateProvider
    .state("organisations", {
        url: "/organisations",
        templateUrl: "organisationsIndex.html"
    })
};

angular.module("contacts").config(config);


		
