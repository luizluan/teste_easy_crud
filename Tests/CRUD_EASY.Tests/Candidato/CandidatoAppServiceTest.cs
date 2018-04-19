using CRUD_EASY.CandidatoAppService.Dtos.Base;
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


        public CandidatoDto DefaultCandidato = new CandidatoDto()
        {
            Id = Guid.Empty,
            Nome = "José da Silva",
            Email = "Meu@Email.com",
            Cidade = "Nova Cidade",
            Cpf ="11111111111",
            Skype ="noskypename",
            CrudLink = "https://github.com/luizluan/teste_easy_crud",
            Telefone = "99999999",
            ValorHora = 0,
            PortFolio = "",
            MelhorHorario = new MelhorHorarioDto()
            {
                HorarioComercial = true,
            },
            HorarioDisponivel  = new HorarioDisponivelDto()
            {
                MaisdeOitoHorasDia = true
            },
            Linkedin = "",
            Estado = "Minas Gerais",
            Banco = new BancoDto()
            {
                Agencia ="3340",
                Nome = "Caixa",
                NumerodaConta ="98798-87",
       
            },
            Conhecimento = new ConhecimentoDto()
            {
                Html = 5,
                Illustrator = 4,
                Java = 3,
                Cplus = 6
            }
        };

        [Fact]
        public async Task Devo_Retornar_Atributos_do_Conhecimento()
        {
            //ACT
            var atributos = _candidatoAppService.LoadAtributos();

            //ASSERT
            atributos.Atributos.Count.ShouldBeGreaterThan(1);
        }





    }
}
