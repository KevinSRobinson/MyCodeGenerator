
    
    var Contact = require('../Models/contactsModel.js');

    exports.create = function (req, res) {
        var entry = new Contact({
            
            Id: req.body.Id,FirstName: req.body.FirstName,LastName: req.body.LastName,UserId: req.body.UserId
          

            
        });

        entry.save();

        res.redirect(301, '/');
    };


    exports.list = function (req, res) { 
        var query = Contact.find();
        query.sort({createdOnDate: 'desc'})
        .limit(10)
        .exec(function(err, results){
            res.render({Contacts: results});
        });

    };


    exports.get = function (req, res) { 
        res.render('newnote', { title: 'Standup - New Note'});
    };

 

