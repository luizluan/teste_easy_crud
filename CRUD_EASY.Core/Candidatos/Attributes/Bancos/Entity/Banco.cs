using Abp.Domain.Entities;
using CRUD_EASY.Candidatos.Attributes.Bancos.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUD_EASY.Candidatos.Entity;

namespace CRUD_EASY.Candidatos.Attributes.Entity.Bancos
{
    [Table("Banco")]
    public class Banco : Entity<int>
    {

        //Override public int Id {get;set;}

        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string NumerodaConta { get; set; }

        public TipodeConta  TipodeConta { get; set; }

    }
}
