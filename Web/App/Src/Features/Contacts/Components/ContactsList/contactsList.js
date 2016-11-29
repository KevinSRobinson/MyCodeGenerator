		

/**
* @memberof app
* @ngdoc service
* @name contacts
* @param {$http} Test
* @property {object} obj property of this service
* @ngInject
* @desc The siteLanguageServices provides information about available languges
* of a site.  
*/
var contactsList = {
bindings: {
	allowChanges: "@"
},
controllerAs: "vm",
templateUrl: "contactsListTemplate.html",
controller: function (contactsService) {
    var vm = this;
    vm.error = {};
    vm.contacts = [];

    vm.init = function(){
        vm.loadcontactss();
    };


    vm.loadcontactss = function(){
        var contactPromise= contactsService.GetAll();
        contactsPromise.then(function(response){
	    vm.contacts = response.data;
        }).catch(function(error){
	        vm.error = error;
        })
    };
	


   
    vm.init();

    }
}


angular.module("contacts").component("contactsList", contactsList);



		
		
		