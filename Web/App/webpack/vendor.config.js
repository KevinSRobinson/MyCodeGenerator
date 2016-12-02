'use strict';
var buildPath = require('path').resolve(__dirname, 'build');
var webpack = require('webpack');

console.log(buildPath);

var config = {
    context: __dirname,
    watch: true,
    entry: './vendorEntry.js',
    output: {
        path: '/dist/',
        filename: 'vendorBundle.js'
    },
    module: {
        loaders: [

            {
                test: /\.(jpe?g|png|gif|svg|woff|woff2|eot|ttf)(\?v=[0-9].[0-9].[0-9])?$/,
                loader: 'file?name=/fonts/[sha512:hash:base64:7].[ext]',
                exclude: /node_modules\/(?!font-awesome)/
            },
            {
                test: /bootstrap\/js\//,
                loader: 'imports?jQuery=jquery'
            },
            {
                test: /\.css$/,
                loader: 'file?/[sha512:hash:base64:7].[ext]',
            },

            {
                test: /\.json$/,
                loader: 'json'
            },

            {test: /.(png|woff(2)?|eot|ttf|svg)(\?[a-z0-9=\.]+)?$/, loader: 'url-loader?limit=100000'},
            {test: /\.less$/, loader: 'style-loader!css-loader!less-loader'},
            {test: /\.css$/, loader: 'style-loader!css-loader'},
            {test: /\.woff(2)?(\?v=\d+\.\d+\.\d+)?$/, loader: 'url?limit=10000&mimetype=application/font-woff'},
            {test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, loader: 'url?limit=10000&mimetype=application/octet-stream'},
            {test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, loader: 'file'},
            {test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, loader: 'url?limit=10000&mimetype=image/svg+xml'},
            {test: /[\/]angular\.js$/, exclude: ['/bower_components/'], loader: 'exports?angular'},
            {test: /\.(png|woff|woff2|eot|ttf|svg)$/, loader: 'url-loader?limit=100000'}
        ]
    },
    plugins: [
        new webpack.ProvidePlugin({
            '$': 'jquery',
            'jQuery': 'jquery',
            'window.jQuery': 'jquery',
            'moment': 'moment',
            '$moment': 'moment'
        })
    ]
};


module.exports = config;