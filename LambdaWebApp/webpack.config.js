const path = require("path");
module.exports = {
  entry: {
    main: "./src/index.jsx",
  },
  output: {
    filename: "[name].js",
    globalObject: "this",
    path: path.resolve(__dirname, "wwwroot/dist"),
    publicPath: "dist/",
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader",
        },
      },
    ],
  },
};
