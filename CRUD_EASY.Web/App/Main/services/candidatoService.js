(function () {


    angular.module('app').factory('candidatoService', ['abp.services.app.candidato','$q',
        function (candidatoService) {

            var _session = {

                //Candidato com os valores que fica armazenado no serviço 
                candidato:
                {
                    id: '',
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
                        numerodaConta:''
                    },

                    horarioDisponivel: {
                        quatroHorasDia: false,
                        quatroaSeisHorasDia: false,
                        maisdeOitoHorasDia: false,
                        apenasFimSemana: false
                    },

                    melhorHorario: {
                        manha: false,
                        tarde: false,
                        noite: false,
                        madrugada: false,
                        horarioComercial: false
                    },

                    conhecimento: {}
                },

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

                    var promess = $q.defer();
                    candidatoService.loadAtributos().then(function (response) {
                        this.candidato.conhecimento = response.data;
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