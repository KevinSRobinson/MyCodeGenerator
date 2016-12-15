     

module.exports = function(app) {
    var api = '/api';
    var data = '/../../data/';
    var jsonfileservice = require('./utils/jsonfileservice')();

    app.get(api + '/contacts/:id', getcontact);
    app.get(api + '/contacts', getcontacts);

    function getcontact(req, res, next) {
        var json = jsonfileservice.getJsonFromFile(data + 'contacts.json');
        var contact = json.filter(function(c) {
            return c.id === parseInt(req.params.id);
        });
        res.send(contact[0]);
    }

    function getcontacts(req, res, next) {
        var json = jsonfileservice.getJsonFromFile(data + 'contacts.json');
        res.send(json);
    }
};




