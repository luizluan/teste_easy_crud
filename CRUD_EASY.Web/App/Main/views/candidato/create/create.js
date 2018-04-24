(function () {

    'use strict';

    var controllerId = "app.views.candidato";


    angular.module('app').controller(controllerId,
    [ '$location','candidatoService',
        function ($location,candidatoService) {

            var vm = this;



            vm.avancar = function () {
                candidatoService.etapa = 1;
                $location.path("/banco");
                return true;
            }


                 vm.candidato = candidatoService.candidato;

        }
    ]);





})();