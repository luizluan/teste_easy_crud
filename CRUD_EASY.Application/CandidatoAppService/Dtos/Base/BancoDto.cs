using Abp.Application.Services.Dto;
using CRUD_EASY.Candidatos.Attributes.Bancos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Base
{
    /// <summary>
    /// BancoDto
    /// A framework utiliza esse tipo de classe para receber e retornar dados da api, segundo o criador da framework não é recomendável utilizar diretamente a entidade para isso 
    /// </summary>
    public class BancoDto : EntityDto<int>
    {
       

        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string NumerodaConta { get; set; }

        public TipodeConta TipodeConta { get; set; }
    }
}
