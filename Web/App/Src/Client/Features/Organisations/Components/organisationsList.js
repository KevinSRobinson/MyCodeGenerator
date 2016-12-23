		

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
templateUrl: "src/client/Features/Organisations/Components/organisationsList.html",
controller: function (organisationsService, organisationsModalService) {
    var vm = this;
    vm.error = {};
    vm.organisations = [];

    vm.init = function(){
        vm.loadorganisationss();
    };


    vm.loadorganisationss = function(){
        var organisationsPromise= organisationsService.GetAll();
        organisationsPromise.then(function(response){
	    vm.organisations = response.data;
console.log(response.data);
        }).catch(function(error){
	        vm.error = error;
        })
    };
	


    //////////////////////
    //Modals
    vm.create = function(){
        var modal = organisationsModalService.Add();
        modal.result.then(function(response){
	        vm.organisations.push(response);
        });
    };

    vm.edit = function(organisation){
        organisationsModalService.Modify(organisation);
    };

    vm.view = function(organisations){
		organisationsModalService.View(organisation);
	};

    vm.init();

    }
}


angular.module("contacts").component("organisationsList", organisationsList);



		
		
		