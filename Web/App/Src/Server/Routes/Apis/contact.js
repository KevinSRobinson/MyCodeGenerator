

var express = require('express');
var app = express();

app.get('api/contacts', function(req, res, next) {
    
var contacts  = [];
    res.send( contacts );
});


