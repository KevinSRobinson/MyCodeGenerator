var gulp = require('gulp');

//used to load any 'gulp-' plugins 
var $ = require('gulp-load-plugins')({lazy : true});

//load the gulp config file
var config = require('./gulp.config')();

//used to allow the use of arguments with gulp commands
var args = require('yargs').argv;

//delete utility
var del = require('del');

//Wire Bower dependencies to your source code. https://github.com/taptapship/wiredep
var wiredep = require('wiredep').stream;

//BrowserSync
var browserSync = require('browser-sync');


////////////////////////////////
// Analyze code
gulp.task('vet', function(){
    
    log ('Analyzing Code');

    return gulp

            //load all the source js files
            .src(config.alljs)

            //print out files being Analyzed
            //use gulp-if & yargs to allow switching this
            .pipe($.if(args.verbose, $.print())) 

            //code linter
            .pipe($.jscs()) // check codestyling - config = .jscsrc
            .pipe($.jshint()) // check for code issues - config = .jshintrc

            //use a reporter for nicer output
            .pipe($.jshint.reporter('jshint-stylish'), {verbose: true})

            //fail if any there are any codind issues
            .pipe($.jshint.reporter('fail'));

});


////////////////////////////////
// wiredep
gulp.task('wiredep',  function(){

    log('wiredep starting');
   
    return gulp
            //use the client index.html file 
            .src(config.clientIndexFile)

            //add the wiredep config using the options from config
            //uses the bower.json file to file the app dependencies
            .pipe(wiredep(config.getWiredepDefaultOptions()))

            //inject the client js files
            .pipe($.inject(gulp.src(config.appJsFiles)))

            //inject the css
            .pipe($.inject(gulp.src(config.compiledLess))
)
            // the desination is the same location as the index.html file 
            .pipe(gulp.dest(config.clientFolder));
});





////////////////////////////////
// Browser Sync
////////////////////////////////
function  startBrowserSync(isDev){
    if(args.nosync || browserSync.active){
        return;
    }

    log('starting browser-sync');

    if(isDev)
    {
        gulp.watch([config.less], ['styles'])
            .on('change', function(event) { changeEvent(event); });
    }
    else{
         gulp.watch([config.less, config.js, config.html], ['optimize', browserSync.reload])
            .on('change', function(event) { changeEvent(event); });
    }

    var options = {
            proxy: 'localhost:' + 7203,
            port: 3000,
            files:isDev ? [
                    config.client + '**/*.*',
                    '!' + config.less,
                    config.temp + '**/*.css'
                ] : [],
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
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Styles
gulp.task('styles', ['clean-styles'], function(){

    log('Compiling Less ->> Css');

    return gulp
                //loads the less file
                .src(config.less)
                
                .pipe($.plumber())               
                
                //add less compiler
                .pipe($.less())

                //PostCSS plugin to parse CSS and add vendor prefixes to CSS rules
                // using values from Can I Use. It is recommended by Google 
                //and used in Twitter, and Taobao. https://github.com/postcss/autoprefixer
                .pipe($.autoprefixer({browsers: ['last 2 version', '> 5%']}))

                //write compiled files to temp folder
                .pipe(gulp.dest(config.temp));

});


gulp.task('less-watcher', function(){
    log('Watching ' + config.less);
    gulp.watch([config.less], ['styles']);
});


gulp.task('clean-styles', function () {

  return gulp
    .src(config.compiledLess, {read: false})

    //clean using gulp-clean https://www.npmjs.com/package/gulp-clean
    .pipe($.clean());
});









////////////////////////////////
// Build
gulp.task('serve-build', ['optimize'], function(){
   serve(false);
});

gulp.task('serve-dev', ['wiredep'], function(){
   serve(true);
});



function serve(isDev){
   
    return $.nodemon(config.nodeServerOptions)

        .on('restart', function(ev) {
            log('noode server restarted');            
            log(ev);

                
             setTimeout(function(){
                browserSync.notify('reloading now ...');
                browserSync.reload({stream: false});
            }, config.browserReloadDelay);
        })
        .on('start', function() {
            log('noode server started');
            startBrowserSync(isDev);
        })
        .on('crash', function() {
            log('noode server crashed');
        })
        .on('exit', function() {
           log('noode server exit');
        });
}
//////////////////////////////////////////////////




gulp.task('fonts', function(){
    log('Copying our fonts');

    return gulp
            .src(config.fonts)
            .pipe(gulp.dest(config.temp + 'fonts'));

});










/////////////////////////////////////////
// Common Functions
///////////////////////////////////////
function changeEvent(event){
    var srcPattern = new RegExp('./.*(?=/' + config.source + ')/');

    log('file ' + event.path.replace(srcPattern, '') + ' ' + event.type);
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

		
			

		
		
			