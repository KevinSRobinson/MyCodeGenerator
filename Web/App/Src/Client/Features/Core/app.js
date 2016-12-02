
(function () {

  'use strict';

  angular
    .module('contacts', ['auth0.lock', 'angular-jwt', 'ui.router'])
    .config(config);

  config.$inject = ['$stateProvider', 'lockProvider', '$urlRouterProvider'];

  function config($stateProvider, lockProvider, $urlRouterProvider) {

    $stateProvider
      .state('home', {
        url: '/home',
        controller: 'homeController',
        templateUrl: 'home.html',
        controllerAs: 'vm'
      })
      .state('login', {
        url: '/login',
        controller: 'loginController',
        templateUrl: 'login.html',
        controllerAs: 'vm'
      });

    lockProvider.init({
      clientID: 'UY5BHrujRwp7y1TZQl1Bif88aeeVRkrU',
       domain: 'volunteernow.auth0.com'
    });

    $urlRouterProvider.otherwise('/home');
  }

})();
