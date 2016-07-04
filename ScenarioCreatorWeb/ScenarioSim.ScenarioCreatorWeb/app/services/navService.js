(function () {
    "use strict";

    angular.module("ScenarioCreator")
            .service("navService", [
            "$q",
            navService
            ]);

    function navService($q) {
        var menuItems = [
          {
              name: "Actors",
              icon: "person",
              sref: ".actor"
          },
          {
              name: "Schemas",
              icon: "description",
              sref: ".schema"
          },
          {
              name: "Scenarios",
              icon: "description",
              sref: ".scenario"
          },
          {
              name: "Assets",
              icon: "people",
              sref: ".asset"
          },
          {
              name: "Programs",
              icon: "assignment",
              sref: ".program"
          }
        ];

        return {
            loadAllItems: function () {
                return $q.when(menuItems);
            }
        };
    }

})();

