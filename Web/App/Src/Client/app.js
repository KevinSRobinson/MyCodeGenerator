
(function () {

  'use strict';

  angular
    .module('contacts', ['ui.router', 'ui.bootstrap','my-angular-components'])
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



