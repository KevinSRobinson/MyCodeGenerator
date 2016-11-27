		

/**
* @memberof app
* @ngdoc service
* @name organisationsService
* @param {$http} Test
* @property {object} obj property of this service
* @ngInject
* @desc The siteLanguageServices provides information about available languges
* of a site.  
*/
var organisationList = {
bindings: {
	allowChanges: "@"
},
controllerAs: "vm",
templateUrl: "organisationList.jsListTemplate",
controller: function (organisationsService, organisationModals) {
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
        var modal = organisationModals.AddOrganisation();
        modal.result.then(function(response){
	        vm.organisations.push(response);
        });
    };

    vm.edit = function(organisations){
        organisations.Edit(organisation);
    };

    vm.view = function(organisations){
		organisationModals.View(organisation);
	};

    vm.init();

    }
}


angular.module("app").component("organisationsList", organisationsList);



		
		
		