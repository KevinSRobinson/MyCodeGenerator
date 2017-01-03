     


module.exports = function(app) {
    var express = require('express');
    var Controller = require('../controllers/organisations.server.controller.js');
    
    app.get('/api/organisations', function(req, res, next) {
       return Controller.list(req, res);
    });

    app.get('/api/organisations/:id', function (req, res, next) {
          return Controller.findById(req, res);
    });

    app.post('/api/organisation', function(req, res) {
       return Controller.create(req, res);
    });


    module.exports = app;

};




