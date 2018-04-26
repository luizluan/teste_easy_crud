(function () {

    'use strict';

    var controllerId = "app.views.banco";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location,candidatoService) {

                var vm = this;

               

                vm.tiposdeConta = [
                    {
                        valor: 0,
                        nome: "Conta Corrente"
                    },

                    {
                        valor: 1,
                        nome: "Conta Poupança"
                    }
                ];

                if (candidatoService.etapa == 0) {
                    window.location.href = '#/candidato';
                }

                vm.banco = candidatoService.candidato.banco;

                vm.voltar = function () {
                    candidatoService.etapa = 0;
                    $location.path("/candidato");
                }

                vm.avancar = function () {
                    candidatoService.etapa = 2;
                    $location.path("/conhecimento");

                }
            }
        ]);





})();