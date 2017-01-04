
    
    var Organisation = require('../Models/organisationsModel.js');

    exports.create = function (req, res) {
        var entry = new Organisation({
            
            Id: req.body.Id,Name: req.body.Name
          

            
        });

        entry.save();

        res.redirect(301, '/');
    };


    exports.list = function (req, res) { 
         var query = Organisation.find({}).then(function (results) {
         res.json(results);
    });


    };



   exports.findById = function (req, res) {
    var query = Organisation.findById(req.params.id).then(function (results) {
        res.json(results);
    });
};

 

