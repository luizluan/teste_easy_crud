using Abp.Domain.Entities;
using CRUD_EASY.Candidatos.Attributes.Bancos;
using CRUD_EASY.Candidatos.Attributes.Conhecimentos.Entity;
using CRUD_EASY.Candidatos.Attributes.Entity.Bancos;
using CRUD_EASY.Candidatos.Attributes.HorariosDisponiveis.Entity;
using CRUD_EASY.Candidatos.Attributes.MelhoresHorarios.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.Candidatos.Entity
{
    /// <summary>
    /// Classe Candidato
    /// </summary>
    [Table("Candidato")]
    public class Candidato : Entity<Guid>, ISoftDelete
    {

        //Override public Guid Id {get;set;}

        [Required]
        public string Nome { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        public string Skype { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Linkedin { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }


        public string PortFolio { get; set; }

        public string CrudLink { get; set; }

        [MaxLength(12)]
        public string Cpf { get; set; }

        public bool IsDeleted { get; set; }

        
        public Banco Banco { get; set; }

        public MelhorHorario MelhorHorario {get;set;}

        public HorarioDisponivel HorarioDisponivel { get; set; }

        public Conhecimento Conhecimento { get; set; }

        public int ValorHora {get;set;}

    }
}
