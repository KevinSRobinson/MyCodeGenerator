		

var modifyOrganisationModalController = function ($uibModalInstance,  organisationsService, organisation) {
  var vm = this;
  vm.organisation  = {}

  vm.init = function () {
    if (organisation != null) {
      vm.organisation = organisation;
    };
  };
  
  vm.save = function () {
    var organisationPromise = organisationsService.Modify(vm.organisation);
    organisationPromise.then(function (response) {
      $uibModalInstance.close(response);
    });
  };

  vm.close = function () {
    $uibModalInstance.close();
  };

  vm.init();

};
angular.module("contacts").controller("modifyOrganisationModalController", modifyOrganisationModalController);

