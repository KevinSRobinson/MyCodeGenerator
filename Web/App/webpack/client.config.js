 config = {
    context: __dirname,
    watch: true,
    entry: "./clientEntry.js",
    output: {
          path: '/dist/',
        filename: 'clientBundle.js',
    }   
};


module.exports = config;


		
	