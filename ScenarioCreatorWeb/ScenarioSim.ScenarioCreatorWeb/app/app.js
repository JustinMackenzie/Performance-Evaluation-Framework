(function () {
    "use strict";

    angular.module("ScenarioCreator", ["ngAnimate", "ngCookies", "ngTouch",
  "ngSanitize", "ui.router", "ngMaterial"])

 .config(function ($stateProvider, $urlRouterProvider, $mdThemingProvider,
                 $mdIconProvider) {
     $stateProvider
       .state("home", {
           url: "",
           templateUrl: "app/views/main.html",
           controller: "MainController",
           controllerAs: "vm",
           abstract: true
       })
       .state("home.schema", {
           url: "/schema",
           templateUrl: "app/views/schema/index.html",
           controller: "SchemaController",
           data: {
               title: "Schema"
           }
       })
       .state("home.actor", {
           url: "/actor",
           templateUrl: "app/views/actor/index.html",
           controller: "ActorController",
           data: {
               title: "Actors"
           }
       })
       .state("home.scenario", {
           url: "/scenario",
           templateUrl: "app/views/scenario/index.html",
           controller: "ScenarioController",
           controllerAs: "vm",
           data: {
               title: "Scenarios"
           }
       })
       .state("home.program", {
           url: "/program",
           templateUrl: "app/views/program/index.html",
           controller: "ProgramController",
           controllerAs: "vm",
           data: {
               title: "Programs"
           }
       })
       .state("home.asset", {
           url: "/asset",
           controller: "AssetController",
           controllerAs: "vm",
           templateUrl: "app/views/asset/index.html",
           data: {
               title: "Assets"
           }
       });

     $urlRouterProvider.otherwise("/schema");

     $mdThemingProvider
       .theme("default")
         .primaryPalette("grey", {
             'default': "600"
         })
         .accentPalette("teal", {
             'default': "500"
         })
         .warnPalette("defaultPrimary");

     $mdThemingProvider.theme("dark", "default")
       .primaryPalette("defaultPrimary")
       .dark();

     $mdThemingProvider.theme("grey", "default")
       .primaryPalette("grey");

     $mdThemingProvider.theme("custom", "default")
       .primaryPalette("defaultPrimary", {
           'hue-1': "50"
       });

     $mdThemingProvider.definePalette("defaultPrimary", {
         '50': "#FFFFFF",
         '100': "rgb(255, 198, 197)",
         '200': "#E75753",
         '300': "#E75753",
         '400': "#E75753",
         '500': "#E75753",
         '600': "#E75753",
         '700': "#E75753",
         '800': "#E75753",
         '900': "#E75753",
         'A100': "#E75753",
         'A200': "#E75753",
         'A400': "#E75753",
         'A700': "#E75753"
     });

     $mdIconProvider.icon("user", "assets/images/user.svg", 64);
 });
})();
