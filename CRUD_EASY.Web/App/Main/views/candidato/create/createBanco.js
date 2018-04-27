(function () {

    'use strict';

    var controllerId = "app.views.banco";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location,candidatoService) {

                var vm = this;

               
               //Decidi colocar isso aqui mesmo pra não ter que fazer uma requisição só pra pegar o Enumerador
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

                //Se a etapa não estiver valendo pelo menos 1 signfica que o usuário não preencheu a primeira tela
                if (candidatoService.etapa == 0) {
                    window.location.href = '#/candidato';
                }

                //Carrega os dados do serviço 
                vm.banco = candidatoService.candidato.banco;

                //Botão voltar
                vm.voltar = function () {
                    candidatoService.etapa = 0;
                    $location.path("/candidato");
                }

                //Botão avançar
                vm.avancar = function () {
                    candidatoService.etapa = 2;
                    $location.path("/conhecimento");

                }
            }
        ]);





})();