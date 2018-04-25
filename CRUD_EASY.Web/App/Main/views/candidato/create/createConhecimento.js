(function () {

    'use strict';

    var controllerId = "app.views.conhecimento";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location, candidatoService) {


                var vm = this;

              

                vm.default = [1, 2, 3, 4, 5];

                vm.conhecimento = candidatoService.candidato.conhecimento;

                if (candidatoService.atributos.length <= 0)
                    candidatoService.loadAtributos().then(function (response) {

                        candidatoService.atributos = response;
                        vm.atributos = response;
                        vm.isLoad = true;
                    });
                else {
                    vm.atributos = candidatoService.atributos;
                    vm.isLoad = true;
                }


                vm.voltar = function () {
                    candidatoService.etapa = 1;
                    $location.path("/banco");
                }

                vm.salvar = function () {

                    abp.message.confirm("Tem certeza que dejesa salvar o candidato?",
                       "", function (isConfirm) {
                           candidatoService.createOrUpdate(candidatoService.candidato).then(function () {
                               abp.notify.success("Candidato Salvo com Sussesso!!!");
                               $location.path("/searchCandidato");
                            });
                        });

                }
            }
        ]);





})();