"use strict";
const path = require("path");
const assert = require("yeoman-assert");
const helpers = require("yeoman-test");

describe("generator-bs-restful-handler:app", () => {
  beforeAll(() => {
    return helpers.run(path.join(__dirname, "../generators/app")).withPrompts({
      _ProjectName: "BAYSOFT",
      _ContextName: "Default",
      _Entity: "Sample"
    });
  });

  it("True is true", () => {
    assert.equal(true, true, "lol, the true is not true kkk");
  });
});
