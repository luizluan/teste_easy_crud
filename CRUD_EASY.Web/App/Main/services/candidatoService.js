(function () {


    angular.module('app').factory('candidatoService', ['abp.services.app.candidato','$q',
        function (candidatoService, $q) {

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
                valorHora: '0',

                banco: {
                    id: 0,
                    nome: '',
                    agencia: '',
                    tipodeConta: 0,
                    numerodaConta: ''
                },

                horarioDisponivel: {
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

                conhecimento: { Id: 0, Outra: '' }

            };

            var _session = {

                //Candidato com os valores que fica armazenado no serviço 
                candidato: defaultCandidato,
                getDefaultCandidato: function () {
                    return defaultCandidato;
                },
                atributos: [],
                etapa: 0,

                //Método de criação usando promessa 
                createOrUpdate: function (candidato) {

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