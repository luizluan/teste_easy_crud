using CRUD_EASY.Candidatos.Attributes.Conhecimentos.Entity;
using CRUD_EASY.Candidatos.Attributes.Entity.Bancos;
using CRUD_EASY.Candidatos.Attributes.HorariosDisponiveis.Entity;
using CRUD_EASY.Candidatos.Attributes.MelhoresHorarios.Entity;
using CRUD_EASY.Candidatos.Entity;
using CRUD_EASY.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.Migrations.SeedData
{
    public class CandidatosTestBase
    {
        private readonly CRUD_EASYDbContext _context;

        public CandidatosTestBase(CRUD_EASYDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCandidatos();
        }

        private void CreateCandidatos()
        {

            //Fiz um seed com 5 candidatos só pra testes

            var candidatos = new List<Candidato>();
            candidatos.Add(new Candidato()
            {
                Nome = "Fernando Mario Rodrigues",
                Email = "fernando@fernandes.com",
                Telefone = "96464987",
                Skype = "ferdinando",
                Linkedin = "http://www.linkedin.com.br/a42ec743-8f76-416e-ae50-8a0970e6a4a2",
                Cidade = "Guarulhos",
                Estado = "São Paulo",
                Banco = new Banco()
                {
                    Agencia = "7797",
                    Nome = "Banco do Brasil",
                    NumerodaConta = "98798",
                    TipodeConta = Candidatos.Attributes.Bancos.Types.TipodeConta.ContaCorrente
                },
                MelhorHorario = new MelhorHorario() { HorarioComercial = true },
                HorarioDisponivel = new HorarioDisponivel() { MaisdeOitoHorasDia = true},
                Conhecimento = new Conhecimento() { AspNetMvc = 5}
            });

            candidatos.Add(new Candidato()
            {
                Nome = "Mariana Adriana Claudia",
                Email = "marian888@zipmail.com",
                Telefone = "3599879979",
                Skype = "maroa231",
                Linkedin = "http://www.linkedin.com.br/a42ec743-8f76-416e-ae50-8a0970e6a4a2",
                Cidade = "Botelhos",
                Estado = "Minas Gerais",
                Banco = new Banco()
                {
                    Agencia = "55",
                    Nome = "Itau",
                    NumerodaConta = "4464",
                    TipodeConta = Candidatos.Attributes.Bancos.Types.TipodeConta.ContaPoupança
                },
                MelhorHorario = new MelhorHorario() { Madrugada = true },
                HorarioDisponivel = new HorarioDisponivel() { MaisdeOitoHorasDia = true },
                Conhecimento = new Conhecimento() {  Android = 5 }
            });


            candidatos.Add(new Candidato()
            {
                Nome = "Geraldo Castilho Americo",
                Email = "geraldobalanca727@gmail.com",
                Telefone = "353265249",
                Skype = "gex42bau",
                Linkedin = "http://www.linkedin.com.br/a42ec743-8f76-416e-ae50-8a0970e6a4a2",
                Cidade = "São Paulo",
                Estado = "São Paulo",
                Banco = new Banco()
                {
                    Agencia = "1234",
                    Nome = "Bradesco",
                    NumerodaConta = "545454",
                    TipodeConta = Candidatos.Attributes.Bancos.Types.TipodeConta.ContaCorrente
                },
                MelhorHorario = new MelhorHorario() { Noite = true },
                HorarioDisponivel = new HorarioDisponivel() { MaisdeOitoHorasDia = true },
                Conhecimento = new Conhecimento() { AspNetMvc = 5, Ionic = 2 }
            });


            candidatos.Add(new Candidato()
            {
                Nome = "Susana Custódia Gertrude",
                Email = "susica@yahoo.com.br",
                Telefone = "3599878787",
                Skype = "susica464",
                Linkedin = "http://www.linkedin.com.br/a42ec743-8f76-416e-ae50-8a0970e6a4a2",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                Banco = new Banco()
                {
                    Agencia = "4234",
                    Nome = "Banco do Brasil",
                    NumerodaConta = "97979",
                    TipodeConta = Candidatos.Attributes.Bancos.Types.TipodeConta.ContaCorrente
                },
                MelhorHorario = new MelhorHorario() { HorarioComercial = true },
                HorarioDisponivel = new HorarioDisponivel() { MaisdeOitoHorasDia = true },
                Conhecimento = new Conhecimento() { AspNetMvc = 5 , AngularJs = 4, Html = 5}
            });


            candidatos.Add(new Candidato()
            {
                Nome = "Sebastião Castro Correia Lopes",
                Email = "lope1988@outlook.com.com",
                Telefone = "35988775544",
                Skype = "lope333",
                Linkedin = "http://www.linkedin.com.br/a42ec743-8f76-416e-ae50-8a0970e6a4a2",
                Cidade = "Curitiba",
                Estado = "Paraná",
                Banco = new Banco()
                {
                    Agencia = "7797",
                    Nome = "Caixa Ecônomica Federal",
                    NumerodaConta = "17664",
                    TipodeConta = Candidatos.Attributes.Bancos.Types.TipodeConta.ContaPoupança
                },
                MelhorHorario = new MelhorHorario() { HorarioComercial = true, Madrugada=true },
                HorarioDisponivel = new HorarioDisponivel() { QuatroaSeisHorasDia = true },
                Conhecimento = new Conhecimento() { AspNetMvc = 5 , AngularJs =5, Android=5, CSS=5}
            });


            //Se fosse um seed convencional o ideal era que eu comparasse todos os campos mas como é um seed só pra testes comparei apenas esse 
            if(!_context.Candidatos.Any(e => e.Linkedin == "http://www.linkedin.com.br/a42ec743-8f76-416e-ae50-8a0970e6a4a2"))
            { 
                  foreach(var candidato in candidatos)
                {
                    _context.Candidatos.Add(candidato);
                }

                _context.SaveChanges();
            }
        }
    }
}
