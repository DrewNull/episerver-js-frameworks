module.exports = {
    devtool: 'source-map', 
    entry: {
        'main-angular': ['./static/js/main-angular.js'],
        'main-react': ['./static/js/main-react.js'],
        'main-vue': ['./static/js/main-vue.js']
    }, 
    mode: 'development',
    output: {
        filename: '[name].js', 
        path: __dirname + '/static/dist'
    }
};