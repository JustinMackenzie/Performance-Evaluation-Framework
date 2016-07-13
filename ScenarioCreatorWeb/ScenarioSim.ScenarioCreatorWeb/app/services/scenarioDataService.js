angular.module("ScenarioCreator")
    .factory("scenarioDataFactory", ["$http", function ($http) {

        var scenarioDataFactory = {};
        var urlBase = "http://localhost:65035/api/Scenario";

        scenarioDataFactory.getScenarios = function () {
            return $http.get(urlBase);
        };

        scenarioDataFactory.getScenario = function (id) {
            return $http.get(urlBase + "/" + id);
        };

        scenarioDataFactory.insertScenario = function (scenario) {
            return $http.post(urlBase, scenario);
        };

        scenarioDataFactory.updateScenario = function (scenario) {
            return $http.put(urlBase + "/" + scenario.Id, scenario);
        };

        scenarioDataFactory.deleteScenario = function (id) {
            return $http.delete(urlBase + "/" + id);
        };

        return scenarioDataFactory;
    }]);