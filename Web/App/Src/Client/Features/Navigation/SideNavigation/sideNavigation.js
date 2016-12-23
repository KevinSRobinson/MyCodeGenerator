		

/**
* @memberof app
* @ngdoc service
* @param {$http} Test
* @property {object} obj property of this service
* @ngInject
* @desc The siteLanguageServices provides information about available languges
* of a site.  
*/
var sideNavigation = {
bindings: {
	allowChanges: "@"
},
controllerAs: "vm",
templateUrl: "src/client/Features/Navigation/SideNavigation/sideNavigation.html",
controller: function () {
    var vm = this;
   
}
}

angular.module("contacts").component("sideNavigation", sideNavigation);



		
		
		