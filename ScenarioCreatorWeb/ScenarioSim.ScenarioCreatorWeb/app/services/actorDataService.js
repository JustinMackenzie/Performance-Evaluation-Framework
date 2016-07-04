angular.module("ScenarioCreator")
    .factory("actorDataFactory", ["$http", function ($http) {

        var actorDataFactory = {};
        var urlBase = "http://localhost:22045/api/Actor";

        actorDataFactory.getActors = function () {
            return $http.get(urlBase);
        };

        actorDataFactory.getActor = function (id) {
            return $http.get(urlBase + "/" + id);
        };

        actorDataFactory.insertActor = function (actor) {
            return $http.post(urlBase, actor);
        };

        actorDataFactory.updateActor = function (actor) {
            return $http.put(urlBase + "/" + actor.Id, actor);
        };

        actorDataFactory.deleteActor = function (id) {
            return $http.delete(urlBase + "/" + id);
        };

        return actorDataFactory;
    }]);