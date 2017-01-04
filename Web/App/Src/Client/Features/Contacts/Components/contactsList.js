		

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
templateUrl: "src/client/Features/Contacts/Components/contactsList.html",
controller: function (contactsService, contactsModalService) {
    var vm = this;
    vm.error = {};
    vm.contacts = [];

    vm.init = function(){
        vm.loadcontactss();
    };


    vm.loadcontactss = function(){
        var contactsPromise= contactsService.GetAll();
        contactsPromise.then(function(response){
	    vm.contacts = response.data;
console.log(response.data);
        }).catch(function(error){
	        vm.error = error;
        })
    };
	


    //////////////////////
    //Modals
    vm.create = function(){
        var modal = contactsModalService.Add();
        modal.result.then(function(response){
	        vm.contacts.push(response);
        });
    };

    vm.edit = function(contact){
        contactsModalService.Modify(contact);
    };

    vm.view = function(contacts){
		contactsModalService.View(contact);
	};

    vm.init();

    }
}


angular.module("contacts").component("contactsList", contactsList);



		
		
		