     

module.exports = function(app) {
    var api = '/api';
    var data = '/../../data/';
    var jsonfileservice = require('./utils/jsonfileservice')();

    app.get(api + '/organisations/:id', getorganisation);
    app.get(api + '/organisations', getorganisations);

    function getorganisation(req, res, next) {
        var json = jsonfileservice.getJsonFromFile(data + 'organisations.json');
        var organisation = json.filter(function(c) {
            return c.id === parseInt(req.params.id);
        });
        res.send(organisation[0]);
    }

    function getorganisations(req, res, next) {
        var json = jsonfileservice.getJsonFromFile(data + 'organisations.json');
        res.send(json);
    }
};




