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
    /// <summary>
    /// Essa é a classe output do candidato, ela possui os atributos do candidato e mais dois outros exclusivos que são os conhecimentos concatenados e a lista de atributos (usada no update)
    /// </summary>
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
        public List<AtributoDto> Atributos { get; set; } = AtributoDto.GetConhecimentos();


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
            
            if (c.Conhecimento != null)
            {
                //Retorna uma string concatenada com os atributos separados por virgula e ordenados por nota
                candidato.Conhecimentos = AtributoDto.GetAtributosString(c.Conhecimento);

                //Converter os dados que tem na classe Conhecimento para a classe de AtributoDto facilitando trabalhar com radioButton usando angular
                candidato.Atributos = AtributoDto.GetConhecimentos(c.Conhecimento);
            }
            return candidato;
        }



    }
}
