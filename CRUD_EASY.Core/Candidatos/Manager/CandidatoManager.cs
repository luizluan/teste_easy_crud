using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using CRUD_EASY.Candidatos.Entity;

namespace CRUD_EASY.Candidatos.Manager
{
    public class CandidatoManager : DomainService, ICandidatoManager
    {

        /// <summary>
        /// Repositório
        /// </summary>
        private readonly IRepository<Candidato, Guid> _candidatoRepository;

        public CandidatoManager(IRepository<Candidato, Guid> candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }


        /// <summary>
        /// Metodo que adiciona um candidato
        /// </summary>
        /// <param name="candidato">Candidato</param>
        /// <returns>Id do Candidato</returns>
        public async Task<Guid> CreateOrUpdate(Candidato candidato)
        {

            var id = await _candidatoRepository.InsertOrUpdateAndGetIdAsync(candidato);

            return id;
        }

        /// <summary>
        /// Método que apaga um candidato
        /// </summary>
        /// <param name="Id">Id do candidato a ser apagado</param>
        public async Task Delete(Guid Id)
        {
            await _candidatoRepository.DeleteAsync(Id);
        }


        /// <summary>
        /// Método que retorna uma lista de candidatos usando uma expressão 
        /// </summary>
        /// <param name="expression">Termos de pesquisa</param>
        /// <returns></returns>
        public List<Candidato> Get(Expression<Func<Candidato, bool>> expression)
        {
            return _candidatoRepository.GetAllIncluding(x => x.Banco, x => x.MelhorHorario, x => x.HorarioDisponivel, x => x.Conhecimento).Where(expression).ToList();
        }
    }
}
