		
var organisationsService = function($http) {
	
    var apiBase = "/Api/Organisations/";


    var getAll = function(){
		return $http.get(apiBase);
	};

    var getById = function(id) {
		return $http.get(apiBase + id);
	};

    var modify = function(organisation) {

        var url = "";

        if(organisation.Id !== undefined)
            url = apiBase + "Update";
        else
            url = apiBase + "Add";
        

        return $http.post(url, organisation);
    };    

    var del = function( organisation) {
		return $http.post(apiBase + "Delete", organisation);
	};

    return {
	    GetAll : getAll,
	    GetById : getById,
	    Modify : modify,
	    Delete : del
    };
};
	

angular.module("contacts").factory("organisationsService", organisationsService);


	
		
			