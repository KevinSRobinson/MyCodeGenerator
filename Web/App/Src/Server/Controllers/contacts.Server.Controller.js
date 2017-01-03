var Contact = require('../Models/contactsModel.js');

exports.create = function (req, res) {
    var entry = new Contact({

        Id: req.body.Id,
        FirstName: req.body.FirstName,
        LastName: req.body.LastName,
        UserId: req.body.UserId



    });

    entry.save();

    res.redirect(301, '/');
};


exports.list = function (req, res) {
    var query = Organisation.find({}).then(function (results) {
        res.json({
            data: results
        });
    });


};



exports.get = function (req, res) {
    res.render('newnote', {
        title: 'Standup - New Note'
    });
};