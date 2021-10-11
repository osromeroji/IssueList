module.exports = {
    filenameHashing: false,
    productionSourceMap: false,
    outputDir: '../vuejs/',
    configureWebpack: {
        devtool: 'source-map',
        output: {
            filename: '[name].js'
        }
    },
    pages: {
        app: {
            entry: 'src/main.js',
            template: 'public/index.html',
            filename: 'index.html',
            title: 'index',
            chunks: ['chunk-vendors', 'chunk-common', 'index']
        }
    }
}