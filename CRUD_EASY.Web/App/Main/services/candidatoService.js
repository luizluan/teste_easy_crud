(function () {

    //Essa Factory meio que funciona como um controller
    angular.module('app').factory('candidatoService', ['abp.services.app.candidato','$q',
        function (candidatoService, $q) {

            //Eu deixei um modelo de candidato com os dados vazio, isso é útil na criação e na hora de resetar o serviço 
            var defaultCandidato = {
                id: '00000000-0000-0000-0000-000000000000',
                nome: '',
                telefone: '',
                email: '',
                linkedin: '',
                cidade: '',
                estado: '',
                portfolio: '',
                cpf: '',
                valorHora: '',

                banco: {
                    id: 0,
                    nome: '',
                    agencia: '',
                    tipodeConta: 0,
                    numerodaConta: ''
                },

                disponibilidade: {
                    Id: 0,
                    quatroHorasDia: false,
                    quatroaSeisHorasDia: false,
                    maisdeOitoHorasDia: false,
                    apenasFimSemana: false
                },

                melhorHorario: {
                    Id: 0,
                    manha: false,
                    tarde: false,
                    noite: false,
                    madrugada: false,
                    horarioComercial: false
                },

                conhecimento: { Id: 0, Outra: '' },

                atributos: []

            };

            var _session = {

                //Candidato com os valores que fica armazenado no serviço 
                candidato: JSON.parse(JSON.stringify(defaultCandidato)) ,
                //Reset o candidato dentro da Factory
                getDefaultCandidato: function () {
                    return JSON.parse(JSON.stringify(defaultCandidato)); 
                },

                //Lista de atributos
                atributos: [],

                //Pra saber em que etapa da criação ou edição a tela está
                etapa: -1,


                //Método de criação usando promessa 
                createOrUpdate: function (candidato) {

                    //Começo da promessa
                    var promess = $q.defer();

                    candidatoService.createOrUpdate(candidato).then(function (response) {

                        if (response.data != undefined) {
                            promess.resolve();
                        }

                    });

                    return $q.all([promess.promise]).then(function () {
                        return true;
                    });
                },

                //Carrega os atributos caso esteja criando um candidato novo
                loadAtributos: function () {

                    var atributos = [];
                    var promess = $q.defer();
                    candidatoService.loadAtributos().then(function (response) {
                        atributos = response.data.atributos;
                        promess.resolve();
                    });

                    return $q.all([promess.promise]).then(function () {
                        return atributos;
                    });
                },

                //Carrega os candidatos e filtra por termo (Nome,Telefone,Email)
                getAll : function (term) {

                    var candidatos = [];
                    var promess = $q.defer();
                    candidatoService.getAll({ term: term }).then(function (response) {
                        candidatos = response.data;
                        promess.resolve();
                    });

                    return $q.all([promess.promise]).then(function () {
                        return candidatos;
                    });
                },

                //Exclui um Candidato
                excluirCandidato: function (id) {
                    var promess = $q.defer();
                    candidatoService.delete({ id:id }).then(function (response) {
                        promess.resolve();
                    });

                    return $q.all([promess.promise]).then(function () {
                        return true;
                    });
                }

            };

            return _session;
        }
    ]);



}
)();