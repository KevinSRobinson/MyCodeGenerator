		

/**
* @memberof app
* @ngdoc service
* @name organisations
* @param {$http} Test
* @property {object} obj property of this service
* @ngInject
* @desc The siteLanguageServices provides information about available languges
* of a site.  
*/
var organisationsList = {
bindings: {
	allowChanges: "@"
},
controllerAs: "vm",
templateUrl: "organisationsList.html",
controller: function (organisationsService, OrganisationsModalService) {
    var vm = this;
    vm.error = {};
    vm.organisations = [];

    vm.init = function(){
        vm.loadorganisationss();
    };


    vm.loadorganisationss = function(){
        var organisationPromise= organisationsService.GetAll();
        organisationsPromise.then(function(response){
	    vm.organisations = response.data;
        }).catch(function(error){
	        vm.error = error;
        })
    };
	


    //////////////////////
    //Modals
    vm.create = function(){
        var modal = OrganisationsModalService.Add();
        modal.result.then(function(response){
	        vm.organisations.push(response);
        });
    };

    vm.edit = function(organisations){
        organisations.Edit(organisation);
    };

    vm.view = function(organisations){
		OrganisationsModalService.View(organisation);
	};

    vm.init();

    }
}


angular.module("contacts").component("organisationsList", organisationsList);



		
		
		