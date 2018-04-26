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
    /// <summary>
    /// Classe Banco
    /// </summary>
    [Table("Banco")]
    public class Banco : Entity<int>
    {
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string NumerodaConta { get; set; }
        public TipodeConta  TipodeConta { get; set; }
    }
}
