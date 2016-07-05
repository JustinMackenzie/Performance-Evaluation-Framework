(function () {
    angular.module("ScenarioCreator")
        .controller("ProgramController", ["programDataFactory", "$mdDialog", "$scope", "$mdToast", ProgramController]);

    function ProgramController(programDataFactory, $mdDialog, $scope, $mdToast) {

        $scope.Programs = [];
        $scope.Program = {};
        $scope.showCreateProgramDialog = showCreateProgramDialog;
        $scope.showEditProgramDialog = showEditProgramDialog;
        $scope.showDeleteProgramDialog = showDeleteProgramDialog;

        getPrograms();

        function getPrograms() {
            programDataFactory.getPrograms()
                .then(function (response) {
                    $scope.Programs = response.data;
                }, function (error) {
                    $scope.status = "Unable to load customer data: " + error.message;
                });
        }

        function showCreateProgramDialog($event) {
            $mdDialog.show({
                controller: CreateProgramController,
                templateUrl: "app/views/program/create.html",
                parent: angular.element(document.body),
                targetEvent: $event,
                clickOutsideToClose: false
            })
                .then(function (program) {
                    createProgram(program);
                }, function () {
                    $scope.status = "You cancelled the dialog.";
                });
        }

        function showEditProgramDialog($event, id) {
            var program = {};

            programDataFactory.getProgram(id)
                .then(function (response) {
                    $mdDialog.show({
                        controller: EditProgramController,
                        templateUrl: "app/views/program/edit.html",
                        parent: angular.element(document.body),
                        targetEvent: $event,
                        clickOutsideToClose: false,
                        locals: {
                            program: response.data
                        }
                    })
                        .then(function (program) {
                            updateProgram(program);
                        }, function () {
                            $scope.status = "You cancelled the dialog.";
                        });
                }, function () {

                });
        }

        function showDeleteProgramDialog($event, id) {
            var confirm = $mdDialog.confirm()
              .title("Are you sure you wish to delete the program?")
              .textContent("This action cannot be undone.")
              .ariaLabel("Confirm")
              .targetEvent($event)
              .ok("Yes")
              .cancel("No");
            $mdDialog.show(confirm).then(function () {
                deleteProgram(id);
            }, function () {
                $scope.status = "You cancelled the deletion.";
            });
        }

        function createProgram(program) {
            programDataFactory.insertProgram(program)
                .then(function (response) {
                    showSimpleToast("Program successfully created.");
                    getPrograms();
                }, function (error) {
                    $scope.status = "Unable to create program: " + error.message;
                });
        }

        function updateProgram(program) {
            programDataFactory.updateProgram(program)
                .then(function (response) {
                    showSimpleToast("Program successfully updated.");
                    getPrograms();
                }, function (error) {
                    $scope.status = "Unable to update program: " + error.message;
                });
        }

        function deleteProgram(id) {
            programDataFactory.deleteProgram(id)
                .then(function (response) {
                    showSimpleToast("Program successfully deleted.");
                    getPrograms();
                }, function (error) {
                    $scope.status = "Unable to delete program: " + error.message;
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

    function CreateProgramController($scope, $mdDialog) {

        $scope.program = {};

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.create = function () {
            $mdDialog.hide($scope.program);
        };
    }

    function EditProgramController($scope, $mdDialog, program) {
        $scope.program = program;

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.update = function () {
            $mdDialog.hide($scope.program);
        };
    }

})();