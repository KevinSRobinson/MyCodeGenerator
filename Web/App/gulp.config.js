module.exports = function() {

    var client = './src/';
    var clientApp = client + 'Features/';
    var temp = './.tmp/';
    var server = './src/server/' ;
    var config = {

        //all js to vet
        alljs: [
            './src/**/*.js',
            './*.js'
        ],
        build: './build/',
        fonts: './bower_components/font-awesome/fonts/**/*.*',
        images: client + './images/**/*.*',
        css: temp + 'styles.css',
        index: client + 'index.html',
           client: client,
        js: [
            clientApp + '**/*.module.js',
            clientApp + '**/*.js',
            '!' + clientApp + '**/*spec.js',
            '!' + './bower_components/**'
        ],
        less : client + 'styles/styles.less',
        server: server,
         temp : temp,
        browserReloadDelay: 1000,
        bower: {
            json: require('./bower.json'),
            directory: './bower_components/',
            ignorePath: '../..'
        },     
        defaultPort: 7203,
        nodeServer: './src/server/app.js',

    };

    config.getWiredepDefaultOptions = function(){
        return {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath
        };
    };

    return config;

};


