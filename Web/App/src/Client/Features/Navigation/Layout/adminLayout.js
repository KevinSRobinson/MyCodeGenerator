		/**
		 * @memberof app
		 * @ngdoc service
		 * @param {$http} Test
		 * @property {object} obj property of this service
		 * @ngInject
		 * @desc The siteLanguageServices provides information about available languges
		 * of a site.  
		 */
		var adminLayout1 = {
			bindings: {
				allowChanges: "@"
			},
			controllerAs: "vm",
			templateUrl: "src/Client/Features/Navigation/Layout/adminLayoutTemplate.html",
			controller: function () {
				var vm = this;

				vm.userName = "Test Username";

				vm.sideMenuItems = [{
					state: "hello",
					linkText: "hello",
					icon: "check"
				}, {
					state: "about",
					linkText: "about",
					icon: "users"
				}];

				vm.userMenuItems = [{
					state: "userprofile",
					linkText: "User Profile",
					icon: "user"
				}, {
					state: "useroptions",
					linkText: "User Options",
					icon: "cogs"
				}, {
					state: "logout",
					linkText: "Logout",
					icon: "cogs"
				}, {
					state: "login",
					linkText: "Login",
					icon: "check"
				}];

				vm.alertMenuItems = [{
					state: "alert1",
					linkText: "Alert 1",
					icon: "bell"
				}, {
					state: "alert2",
					linkText: "Alert 3",
					icon: "bell"
				}];

				vm.footerLinks = [{
						state: 'link1',
						linkText: "Link 1"
					}, {
						state: 'link2',
						linkText: "Link 2"
					}, {
						state: 'link3',
						linkText: "Link 3"
					},

				]
			},
		}

		angular.module("contacts").component("adminLayout1", adminLayout1);