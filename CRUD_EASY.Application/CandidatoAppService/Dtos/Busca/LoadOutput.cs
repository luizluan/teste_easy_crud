using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Busca
{
    public class LoadOutput
    {
        /// <summary>
        /// Pega a lista de  Atributos
        /// </summary>
        public List<AtributoDto> Atributos { get; set; } = AtributoDto.GetAtributos();
    }
}
