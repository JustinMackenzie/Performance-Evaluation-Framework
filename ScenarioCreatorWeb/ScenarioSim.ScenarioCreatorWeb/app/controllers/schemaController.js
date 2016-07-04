(function () {
    angular.module("ScenarioCreator")
        .controller("SchemaController", ["schemaDataFactory", "$mdDialog", "$scope", "$mdToast", SchemaController]);

    function SchemaController(schemaDataFactory, $mdDialog, $scope, $mdToast) {

        $scope.Schemas = [];
        $scope.Schema = {};
        $scope.showCreateSchemaDialog = showCreateSchemaDialog;
        $scope.showEditSchemaDialog = showEditSchemaDialog;
        $scope.showDeleteSchemaDialog = showDeleteSchemaDialog;

        getSchemas();

        function getSchemas() {
            schemaDataFactory.getSchemas()
                .then(function (response) {
                    $scope.Schemas = response.data;
                }, function (error) {
                    $scope.status = "Unable to load customer data: " + error.message;
                });
        }

        function showCreateSchemaDialog($event) {
            $mdDialog.show({
                controller: CreateSchemaController,
                templateUrl: "app/views/schema/create.html",
                parent: angular.element(document.body),
                targetEvent: $event,
                clickOutsideToClose: false
            })
                .then(function (schema) {
                    createSchema(schema);
                }, function () {
                    $scope.status = "You cancelled the dialog.";
                });
        }

        function showEditSchemaDialog($event, id) {
            var schema = {};

            schemaDataFactory.getSchema(id)
                .then(function(response) {
                    $mdDialog.show({
                        controller: EditSchemaController,
                        templateUrl: "app/views/schema/edit.html",
                        parent: angular.element(document.body),
                        targetEvent: $event,
                        clickOutsideToClose: false,
                        locals: {
                            schema: response.data
                        }
                    })
                        .then(function (schema) {
                            updateSchema(schema);
                        }, function () {
                            $scope.status = "You cancelled the dialog.";
                        });
                }, function() {

                });
        }

        function showDeleteSchemaDialog($event, id) {
            var confirm = $mdDialog.confirm()
              .title("Are you sure you wish to delete the schema?")
              .textContent("This action cannot be undone and all related scenarios will be deleted as well.")
              .ariaLabel("Confirm")
              .targetEvent($event)
              .ok("Yes")
              .cancel("No");
            $mdDialog.show(confirm).then(function () {
                deleteSchema(id);
            }, function () {
                $scope.status = "You cancelled the deletion.";
            });
        }

        function createSchema(schema) {
            schemaDataFactory.insertSchema(schema)
                .then(function (response) {
                    showSimpleToast("Schema successfully created.");
                    getSchemas();
                }, function (error) {
                    $scope.status = "Unable to create schema: " + error.message;
                });
        }

        function updateSchema(schema) {
            schemaDataFactory.updateSchema(schema)
                .then(function (response) {
                    showSimpleToast("Schema successfully updated.");
                    getSchemas();
                }, function (error) {
                    $scope.status = "Unable to update schema: " + error.message;
                });
        }

        function deleteSchema(id) {
            schemaDataFactory.deleteSchema(id)
                .then(function (response) {
                    showSimpleToast("Schema successfully deleted.");
                    getSchemas();
                }, function (error) {
                    $scope.status = "Unable to delete schema: " + error.message;
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

    function CreateSchemaController($scope, $mdDialog) {

        $scope.schema = {};

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.create = function () {
            $mdDialog.hide($scope.schema);
        };
    }

    function EditSchemaController($scope, $mdDialog, schema) {
        $scope.schema = schema;

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.update = function () {
            $mdDialog.hide($scope.schema);
        };
    }

})();