(function () {

    'use strict';

    var controllerId = "app.views.conhecimento";


    angular.module('app').controller(controllerId,
        ['$location','candidatoService',
            function ($location, candidatoService) {


                var vm = this;

                //Essa listinha serve pra preencher o label dos radiobuttons
                vm.default = [1, 2, 3, 4, 5];

                //Carrega os dados do serviço
                vm.conhecimento = candidatoService.candidato.conhecimento;

                //Se os atributos vierem vazios significa que um novo usuário está sendo criado
                if (candidatoService.atributos.length <= 0)
                    //Carrega os atributos do serviço
                    candidatoService.loadAtributos().then(function (response) {

                        candidatoService.atributos = response;
                        vm.atributos = response;
                        vm.isLoad = true;
                    });
                else {
                    //Caso o usuário esteja sendo editado é preciso preencher os radioButtons
                    //Tive que armazenar o id e a outra habilidade do candidato
                    var id = candidatoService.candidato.conhecimento.id;
                    var outra = candidatoService.candidato.conhecimento.outra;
                    //Caso o usuário esteja sem atributos
                    vm.atributos = candidatoService.candidato.atributos == undefined ? candidatoService.atributos : candidatoService.candidato.atributos;
                    //Set o valor no Serviço pra quando trocar de tela eu não perde-los
                    candidatoService.candidato.conhecimento = { Id: id, outra: outra };
                    //Carrego os dados do serviço 
                    vm.conhecimento = candidatoService.candidato.conhecimento;
                    //Os valores vem da Api em int e o radiobutton só funciona com string então tenho que converter tudo, por isso inicializei o objeto
                    angular.forEach(vm.atributos, function (at) {
                        at.nota = at.nota.toString();
                        vm.conhecimento[at.nome] = at.nota;
                    });
                   
                    vm.isLoad = true;
                }

                if (candidatoService.etapa == 0) {
                    window.location.href = '#/candidato';
                }

                //Botão Voltar
                vm.voltar = function () {
                    candidatoService.etapa = 1;
                    $location.path("/banco");
                }

                //Botão Salvar
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