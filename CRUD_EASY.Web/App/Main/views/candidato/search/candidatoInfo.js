(function () {

    'use strict';

    var controllerId = "app.views.candidatoInfo";


    angular.module('app').controller(controllerId,
        ['$location', 'candidatoService',
            function ($location, candidatoService) {

                var vm = this;
                vm.candidato = candidatoService.candidato;


                vm.voltar = function () {
                    $location.path("/searchCandidato");
                }

                vm.editar = function () {
                    $location.path("/candidato");
                }

                vm.excluir = function () {
                    abp.message.confirm("Tem certeza que dejesa excluir o candidato?",
                        "", function (isConfirm) {
                            candidatoService.excluirCandidato(vm.candidato.id).then(function () {
                                abp.notify.info("Candidato excluido com sussesso!");
                                $location.path("/searchCandidato");
                            });
                        });
                }
            }
        ]);





})();