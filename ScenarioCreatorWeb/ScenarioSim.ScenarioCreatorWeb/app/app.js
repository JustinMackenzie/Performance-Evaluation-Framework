(function() {
    var scenarioCreator = angular.module("ScenarioCreator", ["ngMaterial", "ngRoute"]);

    scenarioCreator.config(["$routeProvider", function ($routeProvider) {
        $routeProvider
            .when("/schemas",
            {
                controller: "SchemaController",
                templateUrl: "/app/views/schema/index.html"
            })
            .otherwise({ redirectTo: "/schemas" });
    }]);
})();