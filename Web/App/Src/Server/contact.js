

var express = require('express');
var app = express();

app.get('api/contacts', function(req, res, next) {

    var contacts = [
{
Id:1,
FirstName:'Test Value',
LastName:'Test Value',
UserId:'716354bf-f3e8-458b-bc4f-17734ad37924',
}
,
{
Id:2,
FirstName:'Test Value',
LastName:'Test Value',
UserId:'13869cf3-9413-4ce0-b5e6-6f1eb25cdfea',
}
,
{
Id:3,
FirstName:'Test Value',
LastName:'Test Value',
UserId:'ee29464c-9493-4852-9677-998aad7baf51',
}
,
{
Id:4,
FirstName:'Test Value',
LastName:'Test Value',
UserId:'176ba983-a070-4157-ab0b-d638ec6ffd1d',
}
,
];
    
    res.send( contacts );
});


