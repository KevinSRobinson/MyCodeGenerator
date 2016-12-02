var gulp = require("gulp");
var templateCache = require("gulp-angular-templatecache");
var webpack = require("gulp-webpack");
var open = require('gulp-open');
var protractor = require("gulp-protractor").protractor;
var shell = require("gulp-shell");
var jasmineBrowser = require('gulp-jasmine-browser');
var watch = require("gulp-watch");
var config = require('./gulp.config')();
var wiredep = require('wiredep').stream;

var $ = require('gulp-load-plugins')({lazy : true});

gulp.task("default", ["build", "html-templates", "watch-templates"]);


gulp.task("build", function() {
    return gulp.src("entry.js")
        .pipe(webpack( require("./webpack.config.js") ))
        .pipe(gulp.dest("./dist"));
});


//Webpack
gulp.task('client', function() {
   return gulp.src('./webpack/clientEntry.js')
    .pipe(webpack( require('./webpack/client.config.js') ))
    .pipe(gulp.dest('dist/'));                     
});
gulp.task('vendor', function() {
  return gulp.src('webpack/vendorEntry.js')
   .pipe(webpack( require('./webpack/vendor.config.js') ))
    .pipe(gulp.dest('dist/'));      
});





gulp.task('serve-dev', function(){
    var isDev= true;

    var nodeOptions = {
        script: config.nodeServer,
        delayTime: 1,
        env: {
            'PORT': config.defaultPort,
            'NODE_ENV': isDev ? 'dev' : 'build'
        },
        watch: [config.server]
    };

    return $.nodemon(nodeOptions)
        .on('restart', function(ev) {
            log('node server restarted');            
            log(ev);

            setTimeout(function(){
                browserSync.notify('reloading now ...');
                browserSync.reload({stream: false});
            }, config.browserReloadDelay);
        })
        .on('start', function() {
            log('noode server started');
            startBrowserSync();
        })
        .on('crash', function() {
            log('noode server crashed');
        })
        .on('exit', function() {
           log('noode server exit');
        });

});






gulp.task('wiredep', function(){

    log('wiredep starting');

    var options = config.getWiredepDefaultOptions();

    return gulp
            .src(config.index)
            .pipe(wiredep(options))
            .pipe($.inject(gulp.src(config.js)))
            .pipe(gulp.dest(config.client));
});

gulp.task('inject', ['wiredep', 'styles'], function(){

    log('inject starting');

    return gulp
            .src(config.index)
            .pipe($.inject(gulp.src(config.css)))
            .pipe(gulp.dest(config.client));
});

function changeEvent(event){
    var srcPattern = new RegExp('./.*(?=/' + config.source + ')/');

    log('file ' + event.path.replace(srcPattern, '') + ' ' + event.type);


}















function  startBrowserSync(){
    if(args.nosync || browserSync.active){
        return;
    }

    log('starting browser-sync');

gulp.watch([config.less], ['styles'])
    .on('change', function(event) { changeEvent(event); });

    var options = {
            proxy: 'localhost:' + port,
            port: 4000,
            files:[
                    config.client + '**/*.*',
                    '!' + config.less,
                    config.temp + '**/*.css'
                ],

            ghostMode:{
                clicks: true,
                location: false,
                forms: true,
                scroll: true
            },
            injectChangees: true,
            logFileChanges: true,
            logLevel: 'debug',
            logPrefix: 'gulp-patterns',
            notify: true,
            reloadDelay: 0
            
    };

    browserSync(options);    
} 







//////////////////////////////////////////////
///////////   Templates   //////////////
///////////////////////////////////////////
gulp.task("watch-templates", function() {
    gulp.watch('src/**/*.html', ['html-templates']);
});

gulp.task('html-templates', function() {
    return gulp.src(config.srcTemplates)
        .pipe(templateCache('templateCache.js', config))
        .pipe(gulp.dest(config.destPartials));
});



//////////////////////////////////////////////
///////////   Protractor   //////////////
///////////////////////////////////////////
gulp.task("all", ["e2e", "open"]);

    

gulp.task("e2e", function() {

    gulp.src(["app/Tests/testClients.js"])
        .pipe(protractor({
            "configFile": "Tests/conf.js",
        }));

});

gulp.task('protractor-run', function (done) {
    var argv = process.argv.slice(3); // forward args to protractor
    child_process.spawn(getProtractorBinary('protractor'), argv, {
        stdio: 'inherit'
    }).once('close', done);
});
function getProtractorBinary(binaryName){
    var winExt = /^win/.test(process.platform)? '.cmd' : '';
    var pkgPath = require.resolve('protractor');
    var protractorDir = path.resolve(path.join(path.dirname(pkgPath), '..', 'bin'));
    return path.join(protractorDir, '/'+binaryName+winExt);
}

		
		
			

	
//////////////////////////////////////////////
///////////   Protractor   //////////////
///////////////////////////////////////////	
		
			function errorLogger(error){
    log(' *** Start of Error ***' );
    log(error);
    log(' *** Start of Error ***' );
    this.emit('end');

}

function log(msg){
    if(typeof(msg) === 'object'){
        for (var item in msg){
            if(msg.hasOwnProperty(item)){
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    }
    else{
        $.util.log($.util.colors.red(msg));
    }
}