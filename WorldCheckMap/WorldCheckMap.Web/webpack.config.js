const path = require('path');


module.exports = {
    entry: {
        main: ['./app/start.jsx']
    },
    output: {
        path: path.join(__dirname, './wwwroot/bundles'),
        publicPath: '/bundles/',
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
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            babelrc: false,
                            presets: [
                                'es2015',
                                'react'
                            ],
                            plugins: [
                                'transform-object-rest-spread',
                                ['transform-class-properties', { spec: true }]
                            ]
                        }
                    }
                ]
            },
            {
                test: /\.(woff|woff2|eot|svg|ttf|png|jpg|jpeg|json)$/,
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
