(function () {

    'use strict';

    var controllerId = "app.views.searchCandidato";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location,candidatoService) {

                var vm = this;


                //Reseta o serviço 
                candidatoService.etapa = -1;

                vm.criarNovoCandidato = function () {
                    candidatoService.etapa = -1;
                    $location.path("/candidato");
                }

                //Termo de pesquisa
                vm.term = '';
                //Lista de candidatos filtrados
                vm.candidatosFiltered = [];

                //Faz a busca
                vm.searchIt = function () {

                    if (!vm.isSearch && vm.candidatosFiltered.length == 0) {
                        vm.isSearch = true;
                        candidatoService.getAll(vm.term).then(function (candidatos) {

                            vm.candidatos = candidatos;

                            if (vm.term == '')
                                vm.isLoad = true;


                        });
                    }
                    return false;
                }

                vm.searchIt();

                //Forcar a busca, em bases muito longas o filtro pode não funcionar
                vm.forcarbusca = function () {
                    vm.isSearch = false;
                    vm.candidatosFiltered = [];
                    vm.searchIt();
                }

                String.prototype.contains = function (it) { return this.indexOf(it) != -1; };


                //Filtro
                vm.search = function (item) {

                    if (vm.term == '')
                        vm.searchIt();

                    if (vm.term.length < 3)
                        return true;

                    if (item.nome.contains(vm.term)) return true;
                    if (item.telefone.contains(vm.term)) return true;
                    if (item.email.contains(vm.term)) return true;

                    vm.searchIt();
                    return false;
                }

                //ng-change do input de termo
                vm.change = function () {
                    vm.isSearch = false;
                    if (vm.candidatos.length == 0)
                        vm.searchIt();
                }

                //Evento que dispara ao clicar em algum candidato da lista
                vm.select = function (candidato) {

                    candidatoService.candidato = candidato;
                    $location.path("/candidatoInfo");
                }

            }
        ]);

       





})();