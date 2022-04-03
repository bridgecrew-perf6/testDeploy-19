const express = require("express");
const app = express();
const path = require("path");

app.get("/*", (req, res) => {
  res.send("/assets/Ch22_nonPBR.fbx");
});

app.listen(process.env.PORT || 3000, () => {
  console.log("listening on port");
});
