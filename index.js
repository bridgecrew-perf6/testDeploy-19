const express = require("express");
const app = express();
const path = require("path");
const fs = require("fs");

app.get("/*", (req, res) => {
  const file = fs.readFileSync(path.join(__dirname, "/assets/Ch22_nonPBR.fbx"));
  console.log(file);
});

app.listen(process.env.PORT || 3000, () => {
  console.log("listening on port");
});
