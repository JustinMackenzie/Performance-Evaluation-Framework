(function () {
    angular.module("ScenarioCreator")
        .controller("ActorController", ["actorDataFactory", "$mdDialog", "$scope", "$mdToast", ActorController]);

    function ActorController(actorDataFactory, $mdDialog, $scope, $mdToast) {

        $scope.Actors = [];
        $scope.Actor = {};
        $scope.showCreateActorDialog = showCreateActorDialog;
        $scope.showEditActorDialog = showEditActorDialog;
        $scope.showDeleteActorDialog = showDeleteActorDialog;

        getActors();

        function getActors() {
            actorDataFactory.getActors()
                .then(function (response) {
                    $scope.Actors = response.data;
                }, function (error) {
                    $scope.status = "Unable to load customer data: " + error.message;
                });
        }

        function showCreateActorDialog($event) {
            $mdDialog.show({
                controller: CreateActorController,
                templateUrl: "app/views/actor/create.html",
                parent: angular.element(document.body),
                targetEvent: $event,
                clickOutsideToClose: false
            })
                .then(function (actor) {
                    createActor(actor);
                }, function () {
                    $scope.status = "You cancelled the dialog.";
                });
        }

        function showEditActorDialog($event, id) {
            var actor = {};

            actorDataFactory.getActor(id)
                .then(function (response) {
                    $mdDialog.show({
                        controller: EditActorController,
                        templateUrl: "app/views/actor/edit.html",
                        parent: angular.element(document.body),
                        targetEvent: $event,
                        clickOutsideToClose: false,
                        locals: {
                            actor: response.data
                        }
                    })
                        .then(function (actor) {
                            updateActor(actor);
                        }, function () {
                            $scope.status = "You cancelled the dialog.";
                        });
                }, function () {

                });
        }

        function showDeleteActorDialog($event, id) {
            var confirm = $mdDialog.confirm()
              .title("Are you sure you wish to delete the actor?")
              .textContent("This action cannot be undone and all related scenarios will be deleted as well.")
              .ariaLabel("Confirm")
              .targetEvent($event)
              .ok("Yes")
              .cancel("No");
            $mdDialog.show(confirm).then(function () {
                deleteActor(id);
            }, function () {
                $scope.status = "You cancelled the deletion.";
            });
        }

        function createActor(actor) {
            actorDataFactory.insertActor(actor)
                .then(function (response) {
                    showSimpleToast("Actor successfully created.");
                    getActors();
                }, function (error) {
                    $scope.status = "Unable to create actor: " + error.message;
                });
        }

        function updateActor(actor) {
            actorDataFactory.updateActor(actor)
                .then(function (response) {
                    showSimpleToast("Actor successfully updated.");
                    getActors();
                }, function (error) {
                    $scope.status = "Unable to update actor: " + error.message;
                });
        }

        function deleteActor(id) {
            actorDataFactory.deleteActor(id)
                .then(function (response) {
                    showSimpleToast("Actor successfully deleted.");
                    getActors();
                }, function (error) {
                    $scope.status = "Unable to delete actor: " + error.message;
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

    function CreateActorController($scope, $mdDialog) {

        $scope.actor = {};

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.create = function () {
            $mdDialog.hide($scope.actor);
        };
    }

    function EditActorController($scope, $mdDialog, actor) {
        $scope.actor = actor;

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.update = function () {
            $mdDialog.hide($scope.actor);
        };
    }

})();