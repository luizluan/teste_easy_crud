using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using CRUD_EASY.CandidatoAppService.Dtos.Base;
using CRUD_EASY.CandidatoAppService.Dtos.Busca;
using CRUD_EASY.CandidatoAppService.Dtos.Delete;
using CRUD_EASY.Candidatos.Entity;
using CRUD_EASY.Candidatos.Manager;

namespace CRUD_EASY.CandidatoAppService.Service
{
    public class CandidatoAppService : CRUD_EASYAppServiceBase,  ICandidatoAppService
    {


        /// <summary>
        /// Manager com os métodos do repositório
        /// </summary>
        private readonly ICandidatoManager _candidatoManager;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="candidatoManager"></param>
        public CandidatoAppService(ICandidatoManager candidatoManager)
        {
            _candidatoManager = candidatoManager;
        }
        
        /// <summary>
        /// Cria ou atualiza um candidato
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Id do Candidato Criado</returns>
        public async Task<Guid> CreateOrUpdate(CandidatoDto input)
        {
            var candidato = input.MapTo<Candidato>();

            var id  = await _candidatoManager.CreateOrUpdate(candidato);

            return id;
        }

        /// <summary>
        /// Carrega os atributos do conhecimento caso a pessoa esteja criando um novo candidato
        /// </summary>
        /// <returns>Lista com os atributos do conhecimento</returns>
        public LoadOutput LoadAtributos()
        {
            return new LoadOutput();
        }

        /// <summary>
        /// Apaga um candidato
        /// </summary>
        /// <param name="input">Id do candidato</param>
        public async  Task Delete(DeleteInput input)
        {
            await _candidatoManager.Delete(input.Id);
        }

        /// <summary>
        /// Busca Candidatos por Termo Nome Email ou Telefone
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Lista de Candidatos</returns>
        public List<CandidatoOutput> GetAll(BuscaCandidatoInput input)
        {
            //Busca Candidatos Utilizando a Expressão que está no Dto 
            var candidatos = _candidatoManager.Get(CandidatoOutput.GetExpression(input));

            //Mapeia as entidades para o dto usando o método estático no dto 
            var candidatosDto = candidatos.Select(CandidatoOutput.MapTo).ToList();

            //Retorna a Lista 
            return candidatosDto;
        }


    }
}
