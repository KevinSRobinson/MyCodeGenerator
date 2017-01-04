
    
    var Contact = require('../Models/contactsModel.js');

    exports.create = function (req, res) {
        var entry = new Contact({
            
            Id: req.body.Id,FirstName: req.body.FirstName,LastName: req.body.LastName,UserId: req.body.UserId
          

            
        });

        entry.save();

        res.redirect(301, '/');
    };


    exports.list = function (req, res) { 
         var query = Contact.find({}).then(function (results) {
         res.json(results);
    });


    };



   exports.findById = function (req, res) {
    var query = Contact.findById(req.params.id).then(function (results) {
        res.json(results);
    });
};

 

