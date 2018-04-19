using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Base
{
    public class MelhorHorarioDto : EntityDto<int>
    {
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public bool Madrugada { get; set; }
        public bool HorarioComercial { get; set; }
    }
}
