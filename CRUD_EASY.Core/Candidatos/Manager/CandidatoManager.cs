﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using CRUD_EASY.Candidatos.Attributes.Conhecimentos.Entity;
using CRUD_EASY.Candidatos.Attributes.Entity.Bancos;
using CRUD_EASY.Candidatos.Attributes.Disponibilidade.Entity;
using CRUD_EASY.Candidatos.Attributes.MelhoresHorarios.Entity;
using CRUD_EASY.Candidatos.Entity;

namespace CRUD_EASY.Candidatos.Manager
{
    public class CandidatoManager : DomainService, ICandidatoManager
    {

        /// <summary>
        /// Repositório
        /// </summary>
        private readonly IRepository<Candidato, Guid> _candidatoRepository;

        /// <summary>
        /// Children Repositories
        /// </summary>
        private readonly IRepository<Banco, int> _bancoRepository;
        private readonly IRepository<MelhorHorario, int> _melhorHorarioRepository;
        private readonly IRepository<Disponibilidade, int> _disponibilidadeRepository;
        private readonly IRepository<Conhecimento, int> _conhecimentoRepository;


        public CandidatoManager(IRepository<Candidato, Guid> candidatoRepository,
                                IRepository<Banco, int> bancoRepository,
                                IRepository<MelhorHorario, int> melhorHorarioRepository,
                                IRepository<Disponibilidade, int> disponibilidadeRepository,
                                IRepository<Conhecimento, int> conhecimentoRepository)
                                
            
        {
            _candidatoRepository = candidatoRepository;

            _bancoRepository = bancoRepository;
            _melhorHorarioRepository = melhorHorarioRepository;
            _disponibilidadeRepository = disponibilidadeRepository;
            _conhecimentoRepository = conhecimentoRepository;


        }


        /// <summary>
        /// Metodo que adiciona um candidato
        /// </summary>
        /// <param name="candidato">Candidato</param>
        /// <returns>Id do Candidato</returns>
        public async Task<Guid> CreateOrUpdate(Candidato candidato)
        {
            //Se estiver vazio significa que o candidato é novo 
            if (candidato.Id == Guid.Empty)
            {
                var id = await _candidatoRepository.InsertAndGetIdAsync(candidato);
                return id;
            }
            else
            {
                //Atualiza informações do Candidato, era pra atualizar as entidades filhas mas isso não aconteceu
                //Tive que inverter todos os repositórios e atualizar um a um 
                //Achei mais prático do que criar um manager pra cada entidade 
                await _candidatoRepository.UpdateAsync(candidato);

                await _bancoRepository.UpdateAsync(candidato.Banco);
                await _melhorHorarioRepository.UpdateAsync(candidato.MelhorHorario);
                await _disponibilidadeRepository.UpdateAsync(candidato.Disponibilidade);
                await _conhecimentoRepository.UpdateAsync(candidato.Conhecimento);

                return candidato.Id;
            }
            
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
            return _candidatoRepository.GetAllIncluding(x => x.Banco, x => x.MelhorHorario, x => x.Disponibilidade, x => x.Conhecimento).Where(expression).Take(20).ToList();
        }
    }
}
