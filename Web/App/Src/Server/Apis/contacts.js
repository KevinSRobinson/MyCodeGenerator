
var express = require('express');
var app = express();

app.get('/ping', function(req, res, next) {
    console.log(req.body);
    res.send('pong');
});