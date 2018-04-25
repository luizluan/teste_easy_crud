(function () {

    'use strict';

    var controllerId = "app.views.searchCandidato";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location,candidatoService) {

                var vm = this;

                vm.criarNovoCandidato = function () {
                    $location.path("/candidato");
                }

                candidatoService.getAll('').then(function (candidatos) {

                    vm.candidatos = candidatos;
                    vm.isLoad = true;

                });
            }
        ]);





})();