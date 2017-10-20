﻿const path = require('path');


module.exports = {
    entry: [
        path.join(__dirname, 'app/start.jsx')
    ],
    output: {
        path: path.join(__dirname, 'wwwroot/bundles'),
        publicPath: '/',
        filename: 'bundle.js'
    },
    resolve: {
        modules: ['node_modules']
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
                test: /\.(css|less)$/,
                use: ['style-loader', 'css-loader', 'less-loader']
            }
        ]
    }
};
