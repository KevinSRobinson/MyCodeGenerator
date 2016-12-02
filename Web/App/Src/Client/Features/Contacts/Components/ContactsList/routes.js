


var config = function ($stateProvider) {
    
$stateProvider
    .state("contacts", {
        url: "/contacts",
        templateUrl: "contacts.html"
    })
    .state("contact", {
        url: "/contact/:id",
        templateUrl: "contact.html"
    });
};

angular.module("contacts").config(config);



	
		
