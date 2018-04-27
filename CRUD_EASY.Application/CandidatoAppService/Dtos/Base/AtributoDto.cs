using Abp.Extensions;
using CRUD_EASY.CandidatoAppService.Dtos.Base;
using CRUD_EASY.Candidatos.Attributes.Conhecimentos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos
{
    /// <summary>
    /// Criei essa Classe pra facilitar o Carregamento dos atributos da classe Conhecimento
    /// </summary>
    public class AtributoDto
    {
  
            public string Nome { get; set; }
            public int Nota { get; set; }
       
        /// <summary>
        /// Esse fuunção usa reflexão para exibir os atributos por ordem de nota 
        /// </summary>
        /// <param name="c">Objeto Conhecimento com todos as atributos do candidato</param>
        /// <returns>Uma string com os conhecimentos ordenados por nota e concatenados por vírgula</returns>
        public static string GetAtributosString(Conhecimento c)
        {

            var resultado = "";
            //Pega as propriedades da classe 
            var properties = c.GetType().GetProperties().Where(e => e.PropertyType.Name !="String" && e.Name != "Id").ToList();
            var atributos = new List<AtributoDto>();

            foreach (PropertyInfo propertyInfo in properties)
            {
                //Pega o valor e o nome se a nota for maior que 0
                var nota = Convert.ToInt32(propertyInfo.GetValue(c, null).ToString());
                if(nota>0)
                atributos.Add(new AtributoDto()
                {
                    Nome = propertyInfo.Name,
                    Nota = nota
                });
            }

            //Ordena por nota e concatena com vírgula
            foreach (var h in atributos.OrderByDescending(e => e.Nota))
            {
                resultado = resultado + h.Nome + ", ";
            }
            //Remove Última vírgula e último espaço caso ele não tenha outra habilidade
            if(c.Outra.IsNullOrEmpty())
            resultado = resultado.Remove(resultado.Length-2);
            else resultado = resultado + c.Outra;
            return resultado;
        }

        /// <summary>
        /// Esse método serve apenas pra ajudar a preencher a tela ele vai auxiliar na hora de carregar todos os atributos da classe conhecimento
        /// </summary>
        /// <param name="c">Conhecimento</param>
        /// <returns>Lista dos atributos</returns>
        public static List<AtributoDto> GetConhecimentos(Conhecimento c = null)
        {
            //É semelhante ao processo acima só que ele retorna os atributos ao invés da string concatenada 
            if(c == null) c = new Conhecimento();
            var properties = c.GetType().GetProperties().Where(e => e.PropertyType.Name != "String" && e.Name != "Id").ToList();
            var atributos = new List<AtributoDto>();

            foreach (PropertyInfo propertyInfo in properties)
            {
                atributos.Add(new AtributoDto()
                {
                    Nome = propertyInfo.Name,
                    Nota = Convert.ToInt32((propertyInfo.GetValue(c, null)?.ToString()) ?? "0")
                });
            }

            return atributos;
        }
    }
}
