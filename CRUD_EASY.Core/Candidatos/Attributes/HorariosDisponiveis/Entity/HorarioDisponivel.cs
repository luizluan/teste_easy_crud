using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.Candidatos.Attributes.HorariosDisponiveis.Entity
{
    [Table("HorarioDisponivel")]
    public class HorarioDisponivel : Entity<int>
    {
        public bool QuatroHorasDia { get; set; }

        public bool QuatroaSeisHorasDia { get; set; }

        public bool MaisdeOitoHorasDia { get; set; }

        public bool ApenasFimSemana { get; set; }
    }
}
