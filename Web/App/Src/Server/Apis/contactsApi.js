     


module.exports = function(app) {
    var express = require('express');
    var Controller = require('../controllers/contacts.server.controller.js');
    
    app.get('/api/contacts', function(req, res, next) {
       return Controller.list(req, res);
    });

    app.get('/api/contacts/:id', function (req, res, next) {
          return Controller.findById(req, res);
    });

    app.post('/api/contact', function(req, res) {
       return Controller.create(req, res);
    });


    module.exports = app;

};




