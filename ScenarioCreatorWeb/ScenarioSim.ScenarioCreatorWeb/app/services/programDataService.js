angular.module("ScenarioCreator")
    .factory("programDataFactory", ["$http", function ($http) {

        var programDataFactory = {};
        var urlBase = "http://localhost:22045/api/Program";

        programDataFactory.getPrograms = function () {
            return $http.get(urlBase);
        };

        programDataFactory.getProgram = function (id) {
            return $http.get(urlBase + "/" + id);
        };

        programDataFactory.insertProgram = function (program) {
            return $http.post(urlBase, program);
        };

        programDataFactory.updateProgram = function (program) {
            return $http.put(urlBase + "/" + program.Id, program);
        };

        programDataFactory.deleteProgram = function (id) {
            return $http.delete(urlBase + "/" + id);
        };

        return programDataFactory;
    }]);