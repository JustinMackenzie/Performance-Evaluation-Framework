(function () {

    var schemaController = function ($scope) {
        $scope.Schemas = [
        {
            Id: "1",
            Name: "Schema 1"
        },
        {
            Id: "2",
            Name: "Schema 2"
        }];
    };

    angular.module("ScenarioCreator").controller("SchemaController", schemaController);
})();