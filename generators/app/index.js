"use strict";
const Generator = require("yeoman-generator");
const chalk = require("chalk");
const yosay = require("yosay");
const pluralize = require("pluralize");
const path = require("path");

module.exports = class extends Generator {
  prompting() {
    // Have Yeoman greet the user.
    this.log(
      yosay(
        `Welcome to the swell ${chalk.red(
          "generator-bs-restful-handler"
        )} generator!`
      )
    );

    const prompts = [
      {
        type: "input",
        name: "_ProjectName",
        message: "Project name?",
        default: "BAYSOFT"
      },
      {
        type: "input",
        name: "_ContextName",
        message: "Context name?",
        default: "Default"
      },
      {
        type: "input",
        name: "_EntityName",
        message: "Entities info (Entity.{Id:{Type}};)?",
        default: "Sample"
      }
    ];

    return this.prompt(prompts).then(props => {
      // To access props later use this.props.someAnswer;
      this.props = props;
    });
  }

  writing() {
    var entities = this.props._EntityName.split(";");

    for (var i = 0; i < entities.length; i++) {
      var entityParts = entities[i].trim().split(".");
      var entity = entityParts[0];
      var entityIDParts = (entityParts[1] ? entityParts[1] : 'Id')
        .trim()
        .split(":");
      var entityID = entityIDParts[0];
      var entityIDType = entityIDParts[1] ? entityIDParts[1] : "int";

      var data = {
        _ProjectName: this.props._ProjectName,
        _Context: this.props._ContextName,
        _Collection: pluralize(entity.trim()),
        _Entity: entity.trim(),
        _EntityID: entityID.trim(),
        _EntityIDType: entityIDType.trim()
      };

      this.startCopy(data);
    }
  }

  install() {
    this.installDependencies();
  }

  startCopy(_data) {
    this.copyEntity(_data);
    this.copyTestMock(_data);
    this.copyEntityValidator(_data);
    this.copyApplictionFiles(_data);
  }

  copyEntity(_data) {
    if (!_data) return;
    let rde = this.entityPath;
    this.copyGenericEntity(rde, _data);
  }

  copyTestMock(_data) {
    if (!_data) return;
    let rdt = this.testsPath;
    this.copyGenericTestMock(rdt, _data);
  }

  copyEntityValidator(_data) {
    if (!_data) return;
    let rdv = this.entityValidationPath;
    this.copyGenericEntityValidator(rdv, _data);
  }

  copyApplictionFiles(_data) {
    if (!_data) return;
    let rootApplication = this.applicationPath;
    this.copyCommandFiles(rootApplication, _data);
    this.copyQueryFiles(rootApplication, _data);
  }

  copyCommandFiles(_root, _data) {
    if (!_data) return;
    _data._CommandQuery = "Command";
    this.copyDeleteFiles(_root, _data);
    this.copyPatchFiles(_root, _data);
    this.copyPostFiles(_root, _data);
    this.copyPutFiles(_root, _data);
  }

  copyQueryFiles(_root, _data) {
    if (!_data) return;
    _data._CommandQuery = "Query";
    this.copyGetByFilterFiles(_root, _data);
    this.copyGetByIDFiles(_root, _data);
  }

  copyDeleteFiles(_root, _data) {
    if (!_data) return;
    var command = this.deleteCommand;
    let rdv = this.domainValidationPath;
    this.copyGenericDomainValidatorFile(rdv, _data, command, false);
    let rids = this.domainInterfaceServicePath;
    this.copyGenericIDomainServiceFile(rids, _data, command, false);
    let rds = this.domainServicePath;
    this.copyGenericDomainServiceFile(rds, _data, command, false);
    let rdt = this.testsPath;
    this.copyGenericDomainServiceTestFile(rdt, _data, command, false);
    this.copyGenericRequestFile(_root, _data, command, false);
    this.copyGenericResponseFile(_root, _data, command, false);
    this.copyGenericHandlerFile(_root, _data, command, false);
  }

  copyPatchFiles(_root, _data) {
    if (!_data) return;
    var command = this.patchCommand;
    let rdv = this.domainValidationPath;
    this.copyGenericDomainValidatorFile(rdv, _data, command, false);
    let rids = this.domainInterfaceServicePath;
    this.copyGenericIDomainServiceFile(rids, _data, command, false);
    let rds = this.domainServicePath;
    this.copyGenericDomainServiceFile(rds, _data, command, false);
    let rdt = this.testsPath;
    this.copyGenericDomainServiceTestFile(rdt, _data, command, false);
    this.copyGenericRequestFile(_root, _data, command, false);
    this.copyGenericResponseFile(_root, _data, command, false);
    this.copyGenericHandlerFile(_root, _data, command, false);
  }

  copyPostFiles(_root, _data) {
    if (!_data) return;
    var command = this.postCommand;
    let rdv = this.domainValidationPath;
    this.copyGenericDomainValidatorFile(rdv, _data, command, false);
    let rids = this.domainInterfaceServicePath;
    this.copyGenericIDomainServiceFile(rids, _data, command, false);
    let rds = this.domainServicePath;
    this.copyGenericDomainServiceFile(rds, _data, command, false);
    let rdt = this.testsPath;
    this.copyGenericDomainServiceTestFile(rdt, _data, command, false);
    this.copyGenericRequestFile(_root, _data, command, false);
    this.copyGenericResponseFile(_root, _data, command, false);
    this.copyGenericHandlerFile(_root, _data, command, false);
  }

  copyPutFiles(_root, _data) {
    if (!_data) return;
    var command = this.putCommand;
    let rdv = this.domainValidationPath;
    this.copyGenericDomainValidatorFile(rdv, _data, command, false);
    let rids = this.domainInterfaceServicePath;
    this.copyGenericIDomainServiceFile(rids, _data, command, false);
    let rds = this.domainServicePath;
    this.copyGenericDomainServiceFile(rds, _data, command, false);
    let rdt = this.testsPath;
    this.copyGenericDomainServiceTestFile(rdt, _data, command, false);
    this.copyGenericRequestFile(_root, _data, command, false);
    this.copyGenericResponseFile(_root, _data, command, false);
    this.copyGenericHandlerFile(_root, _data, command, false);
  }

  copyGetByFilterFiles(_root, _data) {
    var query = x => `Get${x}ByFilter`;
    this.copyGenericRequestFile(_root, _data, query, true);
    this.copyGenericResponseFile(_root, _data, query, true);
    this.copyGenericHandlerFile(_root, _data, query, true);
  }

  copyGetByIDFiles(_root, _data) {
    var query = x => `Get${x}ByID`;
    this.copyGenericRequestFile(_root, _data, query, false);
    this.copyGenericResponseFile(_root, _data, query, false);
    this.copyGenericHandlerFile(_root, _data, query, false);
  }

  copyGenericRequestFile(_root, _data, _cq, _pluralize) {
    this.copyGenericCommandHandlerFile(_root, _data, _cq, "", _pluralize);
  }

  copyGenericResponseFile(_root, _data, _cq, _pluralize) {
    this.copyGenericCommandHandlerFile(
      _root,
      _data,
      _cq,
      "Response",
      _pluralize
    );
  }

  copyGenericHandlerFile(_root, _data, _cq, _pluralize) {
    this.copyGenericCommandHandlerFile(
      _root,
      _data,
      _cq,
      "Handler",
      _pluralize
    );
  }

  copyGenericCommandHandlerFile(_root, _data, _cq, _fileSufix, _pluralize) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var dCollection = pluralize(dEntity);
    var dCq = _cq(_pluralize ? dCollection : dEntity);
    var cqs = pluralize(_data._CommandQuery);
    var cq = _cq(_pluralize ? _data._Collection : _data._Entity);
    var oldFile = dCq + _data._CommandQuery + _fileSufix + ".cs";
    var newFile = cq + _data._CommandQuery + _fileSufix + ".cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, dCollection, cqs, dCq, oldFile),
      path.join(
        _root(_data._ProjectName),
        _data._Context,
        _data._Collection,
        cqs,
        cq,
        newFile
      )
    );
  }

  copyGenericIDomainServiceFile(_root, _data, _cq, _pluralize) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var dCollection = pluralize(dEntity);
    var dCq = _cq(_pluralize ? dCollection : dEntity);
    var cq = _cq(_pluralize ? _data._Collection : _data._Entity);
    var oldFile = "I" + dCq + "Service.cs";
    var newFile = "I" + cq + "Service.cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, dCollection, oldFile),
      path.join(
        _root(_data._ProjectName),
        _data._Context,
        _data._Collection,
        newFile
      )
    );
  }

  copyGenericDomainServiceFile(_root, _data, _cq, _pluralize) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var dCollection = pluralize(dEntity);
    var dCq = _cq(_pluralize ? dCollection : dEntity);
    var cq = _cq(_pluralize ? _data._Collection : _data._Entity);
    var oldFile = dCq + "Service.cs";
    var newFile = cq + "Service.cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, dCollection, oldFile),
      path.join(
        _root(_data._ProjectName),
        _data._Context,
        _data._Collection,
        newFile
      )
    );
  }

  copyGenericDomainServiceTestFile(_root, _data, _cq, _pluralize) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var dCollection = pluralize(dEntity);
    var dCq = _cq(_pluralize ? dCollection : dEntity);
    var cq = _cq(_pluralize ? _data._Collection : _data._Entity);
    var oldFile = dCq + "ServiceTest.cs";
    var newFile = cq + "ServiceTest.cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, dCollection, oldFile),
      path.join(
        _root(_data._ProjectName),
        _data._Context,
        _data._Collection,
        newFile
      )
    );
  }

  copyGenericDomainValidatorFile(_root, _data, _cq, _pluralize) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var dCollection = pluralize(dEntity);
    var dCq = _cq(_pluralize ? dCollection : dEntity);
    var cq = _cq(_pluralize ? _data._Collection : _data._Entity);
    var oldFile = dCq + "SpecificationsValidator.cs";
    var newFile = cq + "SpecificationsValidator.cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, dCollection, oldFile),
      path.join(
        _root(_data._ProjectName),
        _data._Context,
        _data._Collection,
        newFile
      )
    );
  }

  copyGenericEntityValidator(_root, _data) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var oldFile = dEntity + "Validator.cs";
    var newFile = _data._Entity + "Validator.cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, oldFile),
      path.join(_root(_data._ProjectName), _data._Context, newFile)
    );
  }

  copyGenericEntity(_root, _data) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var oldFile = dEntity + ".cs";
    var newFile = _data._Entity + ".cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, oldFile),
      path.join(_root(_data._ProjectName), _data._Context, newFile)
    );
  }

  copyGenericTestMock(_root, _data) {
    if (!_data) return;
    var dContext = "Default";
    var dEntity = "Sample";
    var oldCollection = pluralize(dEntity);
    var newCollection = pluralize(_data._Entity);
    var oldFile = "AddMocked" + oldCollection + "Extensions.cs";
    var newFile = "AddMocked" + newCollection + "Extensions.cs";
    this.copyGenericFile(
      _data,
      path.join(_root("BAYSOFT"), dContext, oldCollection, oldFile),
      path.join(_root(_data._ProjectName), _data._Context, newCollection, newFile)
    );
  }

  copyGenericFile(_data, _fpFilenameOrigem, _fpFilenameDestino) {
    if (!_data) return;
    this.fs.copyTpl(
      this.templatePath(_fpFilenameOrigem),
      this.destinationPath(_fpFilenameDestino),
      _data
    );
  }

  entityPath(project) {
    return `src/${project}.Core.Domain.Entities`;
  }

  testsPath(project) {
    return `src/${project}.Core.Domain.Services.Tests`;
  }

  entityValidationPath(project) {
    return `src/${project}.Core.Domain.Validations/EntityValidations`;
  }

  applicationPath(project) {
    return `src/${project}.Core.Application`;
  }

  domainValidationPath(project) {
    return `src/${project}.Core.Domain.Validations/DomainValidations`;
  }

  domainInterfaceServicePath(project) {
    return `src/${project}.Core.Domain/Interfaces/Services`;
  }

  domainServicePath(project) {
    return `src/${project}.Core.Domain.Services`;
  }

  deleteCommand(command) {
    return `Delete${command}`;
  }

  patchCommand(command) {
    return `Patch${command}`;
  }

  postCommand(command) {
    return `Post${command}`;
  }

  putCommand(command) {
    return `Put${command}`;
  }
};
