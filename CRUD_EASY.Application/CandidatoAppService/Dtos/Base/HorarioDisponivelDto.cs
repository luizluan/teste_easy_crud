using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Dtos.Base
{
    public class HorarioDisponivelDto : EntityDto<int>
    {
        public bool QuatroHorasDia { get; set; }

        public bool QuatroaSeisHorasDia { get; set; }

        public bool MaisdeOitoHorasDia { get; set; }

        public bool ApenasFimSemana { get; set; }
    }
}
