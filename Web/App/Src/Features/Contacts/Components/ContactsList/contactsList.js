		

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
controller: function (contactsService, contactModals) {
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
	


    //////////////////////
    //Modals
    vm.create = function(){
        var modal = contactModals.AddContact();
        modal.result.then(function(response){
	        vm.contacts.push(response);
        });
    };

    vm.edit = function(contacts){
        contacts.Edit(contact);
    };

    vm.view = function(contacts){
		contactModals.View(contact);
	};

    vm.init();

    }
}


angular.module("contacts").component("contactsList", contactsList);



		
		
		