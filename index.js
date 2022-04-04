const express = require("express");
const app = express();
const path = require("path");
const fs = require("fs");

// app.use("/", express.static())
app.use(express.static("assets"));

app.get("/Ch22_nonPBR.fbx", (req, res) => {
  // const file = fs.readFileSync(path.join(__dirname, "/assets/Ch22_nonPBR.fbx"));
  // console.log(file);
  // res.sendFile(path.join(__dirname, "/assets/Ch22_nonPBR.fbx"));
  res.redirect("Ch22_nonPBR.fbx");
});

app.get("/Ch31_nonPBR.fbx", (req, res) => {
  res.redirect("Ch22_nonPBR.fbx");
});

app.listen(process.env.PORT || 3000, () => {
  console.log("listening on port");
});
