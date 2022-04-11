const express = require("express");
const app = express();
const path = require("path");
const fs = require("fs");
const cors = require("cors");
const bodyParser = require("body-parser");
require("dotenv").config();

// app.use("/", express.static())
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(express.static("assets"));
app.use(function (req, res, next) {
  // Website you wish to allow to connect
  res.setHeader("Access-Control-Allow-Origin", "*");

  // Request methods you wish to allow
  res.setHeader(
    "Access-Control-Allow-Methods",
    "GET, POST, OPTIONS, PUT, PATCH, DELETE"
  );

  // Request headers you wish to allow
  res.setHeader(
    "Access-Control-Allow-Headers",
    "X-Requested-With,content-type"
  );

  // Set to true if you need the website to include cookies in the requests sent
  // to the API (e.g. in case you use sessions)
  res.setHeader("Access-Control-Allow-Credentials", true);

  // Pass to next layer of middleware
  next();
});
app.use(cors());
app.options("*", cors());

app.get("/Ch22_nonPBR.fbx", (req, res) => {
  // const file = fs.readFileSync(path.join(__dirname, "/assets/Ch22_nonPBR.fbx"));
  // console.log(file);
  // res.sendFile(path.join(__dirname, "/assets/Ch22_nonPBR.fbx"));
  res.redirect("Ch22_nonPBR.fbx");
});

app.get("/Ch31_nonPBR.fbx", (req, res) => {
  res.redirect("Ch31_nonPBR.fbx");
});

app.listen(process.env.PORT || 3000, () => {
  console.log("listening on port");
});
