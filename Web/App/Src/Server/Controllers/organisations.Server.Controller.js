
    
    var Organisation = require('../Models/organisationsModel.js');

    exports.create = function (req, res) {
        var entry = new Organisation({
            
            Id: req.body.Id,Name: req.body.Name
          

            
        });

        entry.save();

        res.redirect(301, '/');
    };


    exports.list = function (req, res) { 
        var query = Organisation.find();
        query.sort({createdOnDate: 'desc'})
        .limit(10)
        .exec(function(err, results){
            res.render({Organisations: results});
        });

    };


    exports.get = function (req, res) { 
        res.render('newnote', { title: 'Standup - New Note'});
    };

 

