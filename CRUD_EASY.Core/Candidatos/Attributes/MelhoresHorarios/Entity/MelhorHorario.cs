using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.Candidatos.Attributes.MelhoresHorarios.Entity
{
    [Table("MelhorHorario")]
    public class MelhorHorario : Entity<int>
    {
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public bool Madrugada { get; set; }
        public bool HorarioComercial { get; set; }
        
    }
}
