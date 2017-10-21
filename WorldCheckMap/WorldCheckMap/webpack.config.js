const path = require('path');


module.exports = {
    entry: {
        main: ['react-hot-loader/patch', './app/start.jsx']
    },
    output: {
        path: path.join(__dirname, './wwwroot/bundles'),
        publicPath: '/',
        filename: '[name].js'
    },
    resolve: {
        modules: [
            '/',
            'node_modules'
        ],
        extensions: ['.jsx', '.js']
    },
    module: {
        rules: [
            {
                test: /.jsx?$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            babelrc: false,
                            presets: [
                                'es2015',
                                'react'
                            ]
                        }
                    }
                ]
            },
            {
                test: /\.(woff|woff2|eot|svg|ttf|png|jpg|jpeg)$/,
                use: [{
                    loader: 'url-loader',
                    options: {
                        limit: 3000
                    }
                }]
            },
            {
                test: /\.(css|less)$/,
                use: ['style-loader', 'css-loader', 'less-loader']
            }
        ]
    },
    plugins: []
};
