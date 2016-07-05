(function () {
    angular.module("ScenarioCreator")
        .controller("AssetController", ["assetDataFactory", "$mdDialog", "$scope", "$mdToast", AssetController]);

    function AssetController(assetDataFactory, $mdDialog, $scope, $mdToast) {

        $scope.Assets = [];
        $scope.Asset = {};
        $scope.showCreateAssetDialog = showCreateAssetDialog;
        $scope.showEditAssetDialog = showEditAssetDialog;
        $scope.showDeleteAssetDialog = showDeleteAssetDialog;

        getAssets();

        function getAssets() {
            assetDataFactory.getAssets()
                .then(function (response) {
                    $scope.Assets = response.data;
                }, function (error) {
                    $scope.status = "Unable to load customer data: " + error.message;
                });
        }

        function showCreateAssetDialog($event) {
            $mdDialog.show({
                controller: CreateAssetController,
                templateUrl: "app/views/asset/create.html",
                parent: angular.element(document.body),
                targetEvent: $event,
                clickOutsideToClose: false
            })
                .then(function (asset) {
                    createAsset(asset);
                }, function () {
                    $scope.status = "You cancelled the dialog.";
                });
        }

        function showEditAssetDialog($event, id) {
            var asset = {};

            assetDataFactory.getAsset(id)
                .then(function (response) {
                    $mdDialog.show({
                        controller: EditAssetController,
                        templateUrl: "app/views/asset/edit.html",
                        parent: angular.element(document.body),
                        targetEvent: $event,
                        clickOutsideToClose: false,
                        locals: {
                            asset: response.data
                        }
                    })
                        .then(function (asset) {
                            updateAsset(asset);
                        }, function () {
                            $scope.status = "You cancelled the dialog.";
                        });
                }, function () {

                });
        }

        function showDeleteAssetDialog($event, id) {
            var confirm = $mdDialog.confirm()
              .title("Are you sure you wish to delete the asset?")
              .textContent("This action cannot be undone and all scenarios that contain it will be affected.")
              .ariaLabel("Confirm")
              .targetEvent($event)
              .ok("Yes")
              .cancel("No");
            $mdDialog.show(confirm).then(function () {
                deleteAsset(id);
            }, function () {
                $scope.status = "You cancelled the deletion.";
            });
        }

        function createAsset(asset) {
            assetDataFactory.insertAsset(asset)
                .then(function (response) {
                    showSimpleToast("Asset successfully created.");
                    getAssets();
                }, function (error) {
                    $scope.status = "Unable to create asset: " + error.message;
                });
        }

        function updateAsset(asset) {
            assetDataFactory.updateAsset(asset)
                .then(function (response) {
                    showSimpleToast("Asset successfully updated.");
                    getAssets();
                }, function (error) {
                    $scope.status = "Unable to update asset: " + error.message;
                });
        }

        function deleteAsset(id) {
            assetDataFactory.deleteAsset(id)
                .then(function (response) {
                    showSimpleToast("Asset successfully deleted.");
                    getAssets();
                }, function (error) {
                    $scope.status = "Unable to delete asset: " + error.message;
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

    function CreateAssetController($scope, $mdDialog) {

        $scope.asset = {};

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.create = function () {
            $mdDialog.hide($scope.asset);
        };
    }

    function EditAssetController($scope, $mdDialog, asset) {
        $scope.asset = asset;

        $scope.hide = function () {
            $mdDialog.hide();
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };
        $scope.update = function () {
            $mdDialog.hide($scope.asset);
        };
    }

})();