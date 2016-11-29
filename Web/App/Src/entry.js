
require("angular");
require('angular-ui-router');
require("angular-ui-bootstrap");
require("jquery");
require("./node_modules/font-awesome/css/font-awesome.min.css");
require("./node_modules/rdash-ui/dist/css/rdash.min.css");

require("./app.js");

  ////////Organisations////////
require('./DataServices/organisationsService.js');
require('./Features/Organisations/routes.js');
require('./Features/Organisations/Components/OrganisationsList/organisationsList.js');
  ////////Contacts////////
require('./DataServices/contactsService.js');
require('./Features/Contacts/routes.js');
require('./Features/Contacts/Components/ContactsList/contactsList.js');
		




		
		
	
		
