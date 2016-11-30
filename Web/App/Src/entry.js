
require("angular");
require('angular-ui-router');
require("angular-ui-bootstrap");
require("angular-jwt");
require("jquery");


require("./bower_components/auth0-lock/build/lock.js");
require("./bower_components/angular-lock/dist/angular-lock.js");
require("./node_modules/font-awesome/css/font-awesome.min.css");
require("./node_modules/rdash-ui/dist/css/rdash.min.css");





require("./Features/Core/app.js");
require("./Features/Core/app.run.js");
require("./Features/Core/app.config.js");

require("./Features/Core/Login/login.js");
require("./Features/Core/Login/auth0.service.js")

require("./Features/Core/Home/homeController.js")
require("./Features/Core/Components/MenuItems/menu.js");

 ////////Organisations////////
require('./DataServices/organisationsService.js');
require('./Features/Organisations/routes.js');
require('./Features/Organisations/Components/OrganisationsList/organisationsList.js');

 
 ////////Contacts////////
require('./DataServices/contactsService.js');
require('./Features/Contacts/routes.js');
require('./Features/Contacts/Components/ContactsList/contactsList.js');
		




		
		
	
		
