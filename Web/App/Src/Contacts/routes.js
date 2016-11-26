


var config = function ($stateProvider, requireLogin) {
    
$stateProvider
    .state("contacts", {
        url: "/contacts",
        templateUrl: "Index.html"
    })
    .state("contact", {
        url: "/contact/:id",
        templateUrl: "Details.html"
    });
};

angular.module("Contacts").config(config);



	
		
