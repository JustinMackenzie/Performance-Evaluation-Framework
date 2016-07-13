angular.module("ScenarioCreator")
    .factory("assetDataFactory", ["$http", function ($http) {

        var assetDataFactory = {};
        var urlBase = "http://localhost:65035/api/Asset";

        assetDataFactory.getAssets = function () {
            return $http.get(urlBase);
        };

        assetDataFactory.getAsset = function (id) {
            return $http.get(urlBase + "/" + id);
        };

        assetDataFactory.insertAsset = function (asset) {
            return $http.post(urlBase, asset);
        };

        assetDataFactory.updateAsset = function (asset) {
            return $http.put(urlBase + "/" + asset.Id, asset);
        };

        assetDataFactory.deleteAsset = function (id) {
            return $http.delete(urlBase + "/" + id);
        };

        return assetDataFactory;
    }]);