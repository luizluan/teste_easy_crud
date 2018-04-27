using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Base
{
    public  class CandidatoDto : EntityDto<Guid>
    {
      
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        public string Telefone { get; set; }

        public string Linkedin { get; set; }

        public string Cidade { get; set; }
   
        public string Estado { get; set; }

        public string PortFolio { get; set; }

        public string CrudLink { get; set; }
        
        public string Cpf { get; set; }

        public bool IsDeleted { get; set; }


        public BancoDto Banco { get; set; }

        public MelhorHorarioDto MelhorHorario { get; set; }

        public DisponibilidadeDto Disponibilidade { get; set; }

        public ConhecimentoDto Conhecimento { get; set; }

        public int ValorHora { get; set; }
    }
}
