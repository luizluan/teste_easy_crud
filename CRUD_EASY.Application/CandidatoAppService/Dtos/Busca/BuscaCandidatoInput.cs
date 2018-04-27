using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Busca
{
    /// <summary>
    /// Separei os dtos em duas pastas, os base são baseados na entidade os inputs e outpus podem ou não ser filhos dos dtos base
    /// Esse é um dto tipo Input nele contém o termo de pesquisa
    /// </summary>
    public class BuscaCandidatoInput
    {
       public string Term { get; set; }
    }
}
