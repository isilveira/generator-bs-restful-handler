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
      },
      {
        type: "input",
        name: "_RequestType",
        message: "Request Types (Type:Name;)?",
        default:
          "Command:Delete;Command:Patch;Command:Post;Command:Put;Query:GetById;Query:GetByFilter"
      }
    ];

    return this.prompt(prompts).then(props => {
      this.props = props;
    });
  }

  writing() {
    var utils = {
      paths: {
        entity: project => `src/${project}.Core.Domain.Entities`,
        entityMap: project => `src/${project}.Infrastructures.Data/EntityMappings`,
        tests: project => `src/${project}.Core.Domain.Services.Tests`,
        entityValidation: project => `src/${project}.Core.Domain.Validations/EntityValidations`,
        domainValidation: project => `src/${project}.Core.Domain.Validations/DomainValidations`,
        application: project => `src/${project}.Core.Application`,
        domainInterfaceService: project => `src/${project}.Core.Domain/Interfaces/Services`,        
        domainService: project => `src/${project}.Core.Domain.Services`,
        context: project => `src/${project}.Infrastructures.Data/Contexts`,
        contextInterface: project => `src/${project}.Core.Domain/Interfaces/Infrastructures/Data/Contexts`,
      },
      files: {
        entity: entity => `${entity}.cs`,
        entityMap: entity => `${entity}Map.cs`,
        testMock: collection => `AddMocked${collection}Extensions.cs`,
        entityValidator: entity => `${entity}Validator.cs`,
        request: (name, type) => `${name}${type}.cs`,
        response: (name, type) => `${name}${type}Response.cs`,
        handler: (name, type) => `${name}${type}Handler.cs`,
        domainServiceTest: name => `${name}ServiceTest.cs`,
        domainService: name => `${name}Service.cs`,
        domainServiceInterface: name => `I${name}Service.cs`,
        domainValidator: name => `${name}SpecificationsValidator.cs`,
        context: name => `${name}DbContext.cs`,
        contextInterface: name => `I${name}DbContext.cs`,
        contextQueryInterface: name => `I${name}DbContextQuery.cs`,
        contextMock: name => `Mock${name}Helper.cs`,
      },
      filePaths: {
        entity: (data, values) => path.join(
          data.paths.entity(values._ProjectName),
          values._Context,
          data.files.entity(values._Entity)
        ),
        entityMap: (data, values) => path.join(
          data.paths.entityMap(values._ProjectName),
          values._Context,
          data.files.entityMap(values._Entity)
        ),
        testMock: (data, values) => path.join(
          data.paths.tests(values._ProjectName),
          values._Context,
          values._Collection,
          data.files.testMock(values._Collection)
        ),
        entityValidator: (data, values) => path.join(
          data.paths.entityValidation(values._ProjectName),
          values._Context,
          data.files.entityValidator(values._Entity)
        ),
        context: (data, values) => path.join(
          data.paths.context(values._ProjectName),
          data.files.context(values._Context)
        ),
        contextInterface: (data, values) => path.join(
          data.paths.contextInterface(values._ProjectName),
          data.files.contextInterface(values._Context)
        ),
        contextQueryInterface: (data, values) => path.join(
          data.paths.contextInterface(values._ProjectName),
          data.files.contextQueryInterface(values._Context)
        ),
        contextMock: (data, values) => path.join(
          data.paths.tests(values._ProjectName),
          values._Context,
          data.files.contextMock(values._Context)
        ),
        request: (data, values, requestType) => path.join(
          data.paths.application(values._ProjectName),
          values._Context,
          values._Collection,
          pluralize(requestType.type),
          requestType.name(values._Entity),
          data.files.request(requestType.name(values._Entity), requestType.type)
        ),
        response: (data, values, requestType) => path.join(
          data.paths.application(values._ProjectName),
          values._Context,
          values._Collection,
          pluralize(requestType.type),
          requestType.name(values._Entity),
          data.files.response(requestType.name(values._Entity), requestType.type)
        ),
        handler: (data, values, requestType) => path.join(
          data.paths.application(values._ProjectName),
          values._Context,
          values._Collection,
          pluralize(requestType.type),
          requestType.name(values._Entity),
          data.files.handler(requestType.name(values._Entity), requestType.type)
        ),
        domainServiceTest: (data, values, requestType) => path.join(
          data.paths.tests(values._ProjectName),
          values._Context,
          values._Collection,
          data.files.domainServiceTest(requestType.name(values._Entity))
        ),
        domainService: (data, values, requestType) => path.join(
          data.paths.domainService(values._ProjectName),
          values._Context,
          values._Collection,
          data.files.domainService(requestType.name(values._Entity))
        ),
        domainServiceInterface: (data, values, requestType) => path.join(
          data.paths.domainInterfaceService(values._ProjectName),
          values._Context,
          values._Collection,
          data.files.domainServiceInterface(requestType.name(values._Entity))
        ),
        domainValidator: (data, values, requestType) => path.join(
          data.paths.domainValidation(values._ProjectName),
          values._Context,
          values._Collection,
          data.files.domainValidator(requestType.name(values._Entity))
        ),
        requestTypes: {
          Delete: {
            request: (data, values) => data.filePaths.request(data, values, data.requestTypes.Delete),
            response: (data, values) => data.filePaths.response(data, values, data.requestTypes.Delete),
            handler: (data, values) => data.filePaths.handler(data, values, data.requestTypes.Delete),
          },
          Patch: {
            request: (data, values) => data.filePaths.request(data, values, data.requestTypes.Patch),
            response: (data, values) => data.filePaths.response(data, values, data.requestTypes.Patch),
            handler: (data, values) => data.filePaths.handler(data, values, data.requestTypes.Patch),
          },
          Post: {
            request: (data, values) => data.filePaths.request(data, values, data.requestTypes.Post),
            response: (data, values) => data.filePaths.response(data, values, data.requestTypes.Post),
            handler: (data, values) => data.filePaths.handler(data, values, data.requestTypes.Post),
          },
          Put: {
            request: (data, values) => data.filePaths.request(data, values, data.requestTypes.Put),
            response: (data, values) => data.filePaths.response(data, values, data.requestTypes.Put),
            handler: (data, values) => data.filePaths.handler(data, values, data.requestTypes.Put),
          },
          GetById: {
            request: (data, values) => data.filePaths.request(data, values, data.requestTypes.GetById),
            response: (data, values) => data.filePaths.response(data, values, data.requestTypes.GetById),
            handler: (data, values) => data.filePaths.handler(data, values, data.requestTypes.GetById),
          },
          GetByFilter: {
            request: (data, values) => data.filePaths.request(data, values, data.requestTypes.GetByFilter),
            response: (data, values) => data.filePaths.response(data, values, data.requestTypes.GetByFilter),
            handler: (data, values) => data.filePaths.handler(data, values, data.requestTypes.GetByFilter),
          }
        }
      },
      requestTypes: {
        Delete: { type:"Command", name:(entity) => `Delete${entity}`, },
        Patch: { type:"Command", name:(entity) => `Patch${entity}`, },
        Post: { type:"Command", name:(entity) => `Post${entity}`, },
        Put: { type:"Command", name:(entity) => `Put${entity}`, },
        GetById: { type:"Query", name:(entity) => `Get${entity}ById`, },
        GetByFilter: { type:"Query", name:(entity) => `Get${pluralize(entity)}ByFilter`, },
      },
    };

    var project = {
      name: this.props._ProjectName,
      utilities: utils,
      contexts: [],
      getFiles: function (program) {
        program.log(this.name);
        for (let index = 0; index < this.contexts.length; index++) {
          const context = this.contexts[index];
          context.getFiles(program);
        }
      },
    };

    project.contexts.push({
      name: this.props._ContextName,
      entities: [],
      project: project,
      data: {
        old: {
          _ProjectName: "BAYSOFT",
          _Context: "Default",
        },
        new: {
          _ProjectName: this.props._ProjectName,
          _Context: this.props._ContextName,
        },
      },
      getFiles: function(program) {
        program.log(this.name);
        
        program.copyGenericFile(
          this.data,
          project.utilities.filePaths.context(project.utilities, this.data.old),
          project.utilities.filePaths.context(project.utilities, this.data.new)
        );
        
        program.copyGenericFile(
          this.data,
          project.utilities.filePaths.contextInterface(project.utilities, this.data.old),
          project.utilities.filePaths.contextInterface(project.utilities, this.data.new)
        );

        program.copyGenericFile(
          this.data,
          project.utilities.filePaths.contextQueryInterface(project.utilities, this.data.old),
          project.utilities.filePaths.contextQueryInterface(project.utilities, this.data.new)
        );

        program.copyGenericFile(
          this.data,
          project.utilities.filePaths.contextMock(project.utilities, this.data.old),
          project.utilities.filePaths.contextMock(project.utilities, this.data.new)
        );

        for (let index = 0; index < this.entities.length; index++) {
          const entity = this.entities[index];
          entity.getFiles(program);
        }
      }
    });

    var _entities = this.props._EntityName.split(";");

    for (var i = 0; i < _entities.length; i++) {
      if(_entities[i] != "") {
        var entityParts = _entities[i].trim().split(".");
        var _entity = entityParts[0];
        var entityIDParts = (entityParts[1] ? entityParts[1] : "Id")
          .trim()
          .split(":");
        var _entityID = entityIDParts[0];
        var _entityIDType = entityIDParts[1] ? entityIDParts[1] : "int";
        
        var entity = {
          name: _entity,
          id: _entityID,
          idType: _entityIDType,
          requests:[],
          context: project.contexts[0],
          data: {
            old: {
              _ProjectName: "BAYSOFT",
              _Context: "Default",
              _Collection: "Samples",
              _Entity: "Sample",
              _EntityID: "Id",
              _EntityIDType: "int",
            },
            new: {
              _ProjectName: this.props._ProjectName,
              _Context: this.props._ContextName,
              _Collection: pluralize(_entity.trim()),
              _Entity: _entity.trim(),
              _EntityID: _entityID.trim(),
              _EntityIDType: _entityIDType.trim(),
            },
          },
          getFiles: function(program) {
            program.log(this.name);
            var project = this.context.project;
            
            program.copyGenericFile(
              this.data,
              project.utilities.filePaths.entity(project.utilities, this.data.old),
              project.utilities.filePaths.entity(project.utilities, this.data.new)
            );
            
            program.copyGenericFile(
              this.data,
              project.utilities.filePaths.entityMap(project.utilities, this.data.old),
              project.utilities.filePaths.entityMap(project.utilities, this.data.new)
            );
            
            program.copyGenericFile(
              this.data,
              project.utilities.filePaths.testMock(project.utilities, this.data.old),
              project.utilities.filePaths.testMock(project.utilities, this.data.new)
            );
            
            program.copyGenericFile(
              this.data,
              project.utilities.filePaths.entityValidator(project.utilities, this.data.old),
              project.utilities.filePaths.entityValidator(project.utilities, this.data.new)
            );
            
            for (let index = 0; index < this.requests.length; index++) {
              const request = this.requests[index];
              request.getFiles(program);
            }
          }
        };

        var requestTypes = this.props._RequestType.split(";");
        for (let x = 0; x < requestTypes.length; x++) {
          if(requestTypes[x] != "") {
            const type = requestTypes[x].split(":")[0];
            const name = requestTypes[x].split(":")[1];
            var request = {
              name: name,
              type: type,
              entity: entity,
              data: {
                old: {
                  _ProjectName: "BAYSOFT",
                  _Context: "Default",
                  _Collection: "Samples",
                  _Entity: "Sample",
                  _EntityID: "Id",
                  _EntityIDType: "int",
                },
                new: {
                  _ProjectName: this.props._ProjectName,
                  _Context: this.props._ContextName,
                  _Collection: pluralize(_entity.trim()),
                  _Entity: _entity.trim(),
                  _EntityID: _entityID.trim(),
                  _EntityIDType: _entityIDType.trim(),
                },
              },
              getFiles: function (program) {
                program.log(this.name);
                var context = this.entity.context;
                var project = context.project;
                if (this.type === "Command")
                {
                  program.copyGenericFile(
                    this.data,
                    project.utilities.filePaths.domainValidator(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                    project.utilities.filePaths.domainValidator(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                  );

                  program.copyGenericFile(
                    this.data,
                    project.utilities.filePaths.domainServiceInterface(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                    project.utilities.filePaths.domainServiceInterface(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                  );

                  program.copyGenericFile(
                    this.data,
                    project.utilities.filePaths.domainService(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                    project.utilities.filePaths.domainService(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                  );

                  program.copyGenericFile(
                    this.data,
                    project.utilities.filePaths.domainServiceTest(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                    project.utilities.filePaths.domainServiceTest(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                  );
                }

                program.copyGenericFile(
                  this.data,
                  project.utilities.filePaths.request(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                  project.utilities.filePaths.request(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                );

                program.copyGenericFile(
                  this.data,
                  project.utilities.filePaths.response(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                  project.utilities.filePaths.response(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                );
                
                program.copyGenericFile(
                  this.data,
                  project.utilities.filePaths.handler(project.utilities, this.data.old, project.utilities.requestTypes[this.name]),
                  project.utilities.filePaths.handler(project.utilities, this.data.new, project.utilities.requestTypes[this.name])
                );
              },
            };
            entity.requests.push(request);
          }
        }

        project.contexts[0].entities.push(entity);
      }
    }

    this.startCopy(project);
  }

  install() {
    this.installDependencies();
  }

  startCopy(project) {
    if(!project) return;
    
    project.getFiles(this);
  }
  
  copyGenericFile(_data, _oldPath, _newPath) {
    if (!_data) return;
    this.fs.copyTpl(
      this.templatePath(_oldPath),
      this.destinationPath(_newPath),
      _data.new
    );
  }
};
