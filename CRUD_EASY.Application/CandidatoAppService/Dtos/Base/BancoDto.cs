using Abp.Application.Services.Dto;
using CRUD_EASY.Candidatos.Attributes.Bancos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Base
{
    public class BancoDto : EntityDto<int>
    {
       

        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string NumerodaConta { get; set; }

        public TipodeConta TipodeConta { get; set; }
    }
}
