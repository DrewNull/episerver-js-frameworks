﻿module.exports = {
    devtool: 'source-map', 
    entry: {
        'main-angular': ['./static/js/main-angular.js'],
        'main-react': ['./static/js/main-react.js'],
        'main-vue': ['./static/js/main-vue.js']
    }, 
    externals: {
        jquery: 'jQuery'
    },
    mode: 'development',
    output: {
        filename: '[name].js', 
        path: __dirname + '/static/dist',
        libraryExport: 'commonjs-module'
    }, 
    resolve: {
        alias: {
            'vue': 'vue/dist/vue.esm.js'
        }
    }
};