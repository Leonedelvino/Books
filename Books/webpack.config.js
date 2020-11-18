const path = require('path');
const autoprefixer = require('autoprefixer');
const bundleOutputDir = './wwwroot/dist';
    
module.exports = [{
    mode: 'development',
    entry: ['./app.scss', './app.js'],
    output: {
        path: path.join(__dirname, bundleOutputDir),
        filename: 'bundle.js',
    },
    module: {
        rules: [
            {   
                test: /\.scss$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: 'bundle.css',
                        },
                    },
                    { loader: 'extract-loader' },
                    { loader: 'css-loader' },
                    {
                        loader: 'postcss-loader',
                        options: {
                            postcssOptions: {
                                plugins: () => [autoprefixer()]
                            }
                        }
                    },
                    {
                        loader: 'sass-loader',
                        options: {
                            // Prefer Dart Sass
                            implementation: require('sass'),

                            // See https://github.com/webpack-contrib/sass-loader/issues/804
                            webpackImporter: false,
                            sassOptions: {
                                includePaths: ['./node_modules']
                            },
                        },
                    },
                ]
            },
            {
                test: /\.js$/,
                loader: 'babel-loader'
            }
        ]
    },
}];
