

var express = require('express');
var app = express();

app.get('api/organisations', function(req, res, next) {
    
var organisations  = [];
    res.send( organisations );
});


