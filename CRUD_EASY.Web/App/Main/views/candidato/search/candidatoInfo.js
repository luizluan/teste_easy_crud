(function () {

    'use strict';

    var controllerId = "app.views.candidatoInfo";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location,candidatoService) {

                var vm = this;
                vm.candidato = candidatoService.candidato;

            }
        ]);





})();