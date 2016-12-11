
(function () {

  'use strict';

  angular
    .module('contacts', ['ui.router'])
    .config(config);


  function config($stateProvider, $urlRouterProvider) {

    $stateProvider
      .state('home', {
        url: '/home',
        template: '<h1>Home</h1>',
        
      })


    $urlRouterProvider.otherwise('/home');
  }

})();



