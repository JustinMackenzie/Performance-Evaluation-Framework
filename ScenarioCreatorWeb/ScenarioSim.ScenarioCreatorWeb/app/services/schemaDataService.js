angular.module("ScenarioCreator")
    .factory("schemaDataFactory", ["$http", function ($http) {

        var schemaDataFactory = {};
        var urlBase = "http://localhost:65035/api/Schema";

        schemaDataFactory.getSchemas = function () {
            return $http.get(urlBase);
        };

        schemaDataFactory.getSchema = function (id) {
            return $http.get(urlBase + "/" + id);
        };

        schemaDataFactory.insertSchema = function (schema) {
            return $http.post(urlBase, schema);
        };

        schemaDataFactory.updateSchema = function (schema) {
            return $http.put(urlBase + "/" + schema.Id, schema);
        };

        schemaDataFactory.deleteSchema = function (id) {
            return $http.delete(urlBase + "/" + id);
        };

        return schemaDataFactory;
    }]);