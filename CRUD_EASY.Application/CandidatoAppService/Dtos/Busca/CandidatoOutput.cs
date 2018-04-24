using Abp.AutoMapper;
using Abp.Extensions;
using CRUD_EASY.CandidatoAppService.Dtos.Base;
using CRUD_EASY.Candidatos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Busca
{
    [AutoMapFrom(typeof(Candidato))]
    public class CandidatoOutput : CandidatoDto
    {

        /// <summary>
        /// Atributos do Candidato em uma string ordenadas por nota separadas por vírgula
        /// </summary>
        public string Conhecimentos { get; set; }

        /// <summary>
        /// Pega a lista de  Atributos
        /// </summary>
        public List<AtributoDto> Atributos { get; set; } = AtributoDto.GetAtributos();


        /// <summary>
        /// Expressão que busca candidatos por nome telefone ou email
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Expression<Func<Candidato,bool>> GetExpression(BuscaCandidatoInput input)
        {
            Expression<Func<Candidato, bool>> exp = e => (input.Term == "" || input.Term == null || e.Nome.Contains(input.Term) || e.Telefone.Contains(input.Term) || e.Email.Contains(input.Term));
            return exp;
        }

        /// <summary>
        /// Método que mapeia um candidato para o dto 
        /// </summary>
        /// <param name="c">candidato</param>
        /// <returns></returns>
        public static CandidatoOutput MapTo(Candidato c)
        {
            var candidato = c.MapTo<CandidatoOutput>();
            candidato.Conhecimentos = AtributoDto.GetProperties(c.Conhecimento);
            candidato.Atributos = AtributoDto.GetAtributos(c.Conhecimento);
            return candidato;
        }



    }
}
