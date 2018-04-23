using CRUD_EASY.CandidatoAppService.Dtos.Base;
using CRUD_EASY.CandidatoAppService.Dtos.Busca;
using CRUD_EASY.CandidatoAppService.Dtos.Delete;
using CRUD_EASY.CandidatoAppService.Service;
using CRUD_EASY.Candidatos.Attributes.HorariosDisponiveis.Entity;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRUD_EASY.Tests.Candidato
{
    public class CandidatoAppServiceTest : CRUD_EASYTestBase
    {

        private readonly ICandidatoAppService _candidatoAppService;

        public CandidatoAppServiceTest()
        {
            _candidatoAppService = Resolve<ICandidatoAppService>(); 
        }

        public CandidatoDto GetDefaultCandidato()
        {
            CandidatoDto DefaultCandidato = new CandidatoDto()
            {
                Id = Guid.Empty,
                Nome = "José da Silva",
                Email = "Meu@Email.com",
                Cidade = "Nova Cidade",
                Cpf = "11111111111",
                Skype = "noskypename",
                CrudLink = "https://github.com/luizluan/teste_easy_crud",
                Telefone = "99999999",
                ValorHora = 0,
                PortFolio = "",
                MelhorHorario = new MelhorHorarioDto()
                {
                    HorarioComercial = true,
                },
                HorarioDisponivel = new HorarioDisponivelDto()
                {
                    MaisdeOitoHorasDia = true
                },
                Linkedin = "SomeLinkdinlink",
                Estado = "Minas Gerais",
                Banco = new BancoDto()
                {
                    Agencia = "3340",
                    Nome = "Caixa",
                    NumerodaConta = "98798-87",

                },
                Conhecimento = new ConhecimentoDto()
                {
                    Html = 5,
                    Illustrator = 4,
                    Java = 3,
                    Cplus = 2
                }

            };
            return DefaultCandidato;
        }

        [Fact]
        public void Devo_Retornar_Atributos_do_Conhecimento()
        {
            //ACT
            var atributos = _candidatoAppService.LoadAtributos();

            //ASSERT
            atributos.Atributos.Count.ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task Devo_Criar_Candidato()
        {
           
                //ACT
                var candidato = GetDefaultCandidato();
                var candidato2 =GetDefaultCandidato();;

                candidato2.Nome = "Paulo Silva";

                //ACT
                await _candidatoAppService.CreateOrUpdate(candidato);
                await _candidatoAppService.CreateOrUpdate(candidato2);

                //ASSERT
                var candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput());

                candidatos.Count.ShouldBe(2);
          
        }

        [Fact]
        public async Task Devo_Consultar_Candidato()
        {
            //ACT
            var candidato = GetDefaultCandidato();

            //ACT
            await _candidatoAppService.CreateOrUpdate(candidato);

            //ASSERT
            var candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput());

            candidatos.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Devo_Consultar_Candidato_Por_Nome_Telefone_Ou_Email()
        {
            //ACT
            var candidato = GetDefaultCandidato();
            var candidato2 = GetDefaultCandidato();

            candidato2.Nome = "Paulo Silva";
            candidato2.Telefone = "11111111";
            candidato2.Email = "zipmail@hotmail.com";

            await _candidatoAppService.CreateOrUpdate(candidato);
            await _candidatoAppService.CreateOrUpdate(candidato2);

            //ASSERT
            var candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput() {Term="José" });
            candidatos.Count.ShouldBe(1);

            candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput() { Term = "9999" });
            candidatos.Count.ShouldBe(1);

            candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput() { Term = "zipmail@" });
            candidatos.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Devo_Atualizar_Candidato()
        {
            //ARRANGE
            var candidato = GetDefaultCandidato();

            await _candidatoAppService.CreateOrUpdate(candidato);

            candidato = (_candidatoAppService.GetAll(new BuscaCandidatoInput() { Term = "José" })).FirstOrDefault();

            //ACT
            candidato.Nome = "Paulo Silva";
            await _candidatoAppService.CreateOrUpdate(candidato);

            //ASSERT
            var candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput() { Term = "Paulo" });
            candidatos.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Devo_Excluir_Candidato()
        {

            //ARRANGE
            var candidato = GetDefaultCandidato();

            var id = await _candidatoAppService.CreateOrUpdate(candidato);

            //ACT
            await _candidatoAppService.Delete(new DeleteInput() { Id = id });

            //ASSERT
            var candidatos = _candidatoAppService.GetAll(new BuscaCandidatoInput());

            candidatos.Count.ShouldBe(0);
        }





    }
}
