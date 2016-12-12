		

var modifyContactModalController = function ($uibModalInstance,  contactsService, contact) {
  var vm = this;
  vm.contact  = {}

  vm.init = function () {
    if (contact != null) {
      vm.contact = contact;
    };
  };
  
  vm.save = function () {
    var contactPromise = contactsService.Modify(vm.contact);
    contactPromise.then(function (response) {
      $uibModalInstance.close(response);
    });
  };

  vm.close = function () {
    $uibModalInstance.close();
  };

  vm.init();

};
angular.module("contacts").controller("modifyContactModalController", modifyContactModalController);

