var path = require('path');

module.exports = {
    entry: ['babel-polyfill','./src/index.js'],
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname,'dist')
    },
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: 'babel-loader'
            },
            {
                test: /\.css$/,
                include: /node_modules/,
                loaders: ['style-loader', 'css-loader'],
            }
        ],
    },
    resolve: {
        // Allow require('./blah') to require blah.jsx
        //extensions: ['*', '.js', '.jsx'],
    },
    devtool: 'eval-source-map'
};