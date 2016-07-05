(function () {
    angular.module("ScenarioCreator")
        .controller("ScenarioController", ["scenarioDataFactory", "$mdDialog", "$scope", "$mdToast", ScenarioController]);

    function ScenarioController(scenarioDataFactory, $mdDialog, $scope, $mdToast) {

        $scope.Scenarios = [];
        $scope.Scenario = {};
        $scope.showCreateScenarioDialog = showCreateScenarioDialog;
        $scope.showEditScenarioDialog = showEditScenarioDialog;
        $scope.showDeleteScenarioDialog = showDeleteScenarioDialog;

        getScenarios();

        function getScenarios() {
            scenarioDataFactory.getScenarios()
                .then(function (response) {
                    $scope.Scenarios = response.data;
                }, function (error) {
                    $scope.status = "Unable to load customer data: " + error.message;
                });
        }

        function showCreateScenarioDialog($event) {
            $mdDialog.show({
                controller: CreateScenarioController,
                templateUrl: "app/views/scenario/create.html",
                parent: angular.element(document.body),
                targetEvent: $event,
                clickOutsideToClose: false
            })
                .then(function (scenario) {
                    createScenario(scenario);
                }, function () {
                    $scope.status = "You cancelled the dialog.";
                });
        }

        function showEditScenarioDialog($event, id) {
            var scenario = {};

            scenarioDataFactory.getScenario(id)
                .then(function (response) {
                    $mdDialog.show({
                        controller: EditScenarioController,
                        templateUrl: "app/views/scenario/edit.html",
                        parent: angular.element(document.body),
                        targetEvent: $event,
                        clickOutsideToClose: false,
                        locals: {
                            scenario: response.data
                        }
                    })
                        .then(function (scenario) {
                            updateScenario(scenario);
                        }, function () {
                            $scope.status = "You cancelled the dialog.";
                        });
                }, function () {

                });
        }

        function showDeleteScenarioDialog($event, id) {
            var confirm = $mdDialog.confirm()
              .title("Are you sure you wish to delete the scenario?")
              .textContent("This action cannot be undone.")
              .ariaLabel("Confirm")
              .targetEvent($event)
              .ok("Yes")
              .cancel("No");
            $mdDialog.show(confirm).then(function () {
                deleteScenario(id);
            }, function () {
                $scope.status = "You cancelled the deletion.";
            });
        }

        function createScenario(scenario) {
            scenarioDataFactory.insertScenario(scenario)
                .then(function (response) {
                    showSimpleToast("Scenario successfully created.");
                    getScenarios();
                }, function (error) {
                    $scope.status = "Unable to create scenario: " + error.message;
                });
        }

        function updateScenario(scenario) {
            scenarioDataFactory.updateScenario(scenario)
                .then(function (response) {
                    showSimpleToast("Scenario successfully updated.");
                    getScenarios();
                }, function (error) {
                    $scope.status = "Unable to update scenario: " + error.message;
                });
        }

        function deleteScenario(id) {
            scenarioDataFactory.deleteScenario(id)
                .then(function (response) {
                    showSimpleToast("Scenario successfully deleted.");
                    getScenarios();
                }, function (error) {
                    $scope.status = "Unable to delete scenario: " + error.message;
                });
        }

        function showSimpleToast(title) {
            $mdToast.show(
              $mdToast.simple()
                .content(title)
                .hideDelay(2000)
                .position("bottom right")
            );
        }
    }

    function CreateScenarioController($scope, $mdDialog) {

        $scope.scenario = {};

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.create = function () {
            $mdDialog.hide($scope.scenario);
        };
    }

    function EditScenarioController($scope, $mdDialog, scenario) {
        $scope.scenario = scenario;

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.update = function () {
            $mdDialog.hide($scope.scenario);
        };
    }

})();