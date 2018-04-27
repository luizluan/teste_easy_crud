(function () {

    'use strict';

    var controllerId = "app.views.candidatoInfo";


    angular.module('app').controller(controllerId,
        ['$location', 'candidatoService',
            function ($location, candidatoService) {

                var vm = this;

                //Carrega os dados do serviço 
                vm.candidato = candidatoService.candidato;

                //Botão Voltar
                vm.voltar = function () {
                    $location.path("/searchCandidato");
                }

                //Botão Editar
                vm.editar = function () {
                    candidatoService.etapa = 0;
                    $location.path("/candidato");
                }

                //Botão Excluir
                vm.excluir = function () {
                    abp.message.confirm("Tem certeza que dejesa excluir o candidato?",
                        "", function (isConfirm) {
                            candidatoService.excluirCandidato(vm.candidato.id).then(function () {
                                abp.notify.info("Candidato excluido com sussesso!");

                                //Reseta o serviço 
                                candidatoService.etapa = -1;
                                $location.path("/searchCandidato");
                            });
                        });
                }
            }
        ]);





})();