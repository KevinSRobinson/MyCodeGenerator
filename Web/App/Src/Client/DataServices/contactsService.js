		
var contactsService = function($http) {
	
    var apiBase = "/Api/Contacts/";


    var getAll = function(){
		return $http.get(apiBase);
	};

    var getById = function(id) {
		return $http.get(apiBase + id);
	};

    var modify = function(contact) {

        var url = "";

        if(contact.Id !== undefined)
            url = apiBase + "Update";
        else
            url = apiBase + "Add";
        

        return $http.post(url, contact);
    };    

    var del = function( contact) {
		return $http.post(apiBase + "Delete", contact);
	};

    return {
	    GetAll : getAll,
	    GetById : getById,
	    Modify : modify,
	    Delete : del
    };
};
	

angular.module("contacts").factory("contactsService", contactsService);


	
		
			