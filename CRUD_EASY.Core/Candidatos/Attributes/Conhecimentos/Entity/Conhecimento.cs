using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.Candidatos.Attributes.Conhecimentos.Entity
{
    /// <summary>
    /// Classe com os conhecimentos como atributos cada atributo tem uma nota
    /// </summary>
    [Table("Conhecimento")]
    public class Conhecimento : Entity<int>
    {
        [Range(0, 5)]
        public int Ionic { get; set; }

        #region Atributos
        [Range(0, 5)]
        public int Android { get; set; }

        [Range(0, 5)]
        public int Ios { get; set; }

        [Range(0, 5)]
        public int Html { get; set; }

        [Range(0, 5)]
        public int CSS { get; set; }

        [Range(0, 5)]
        public int Bootstrap { get; set; }

        [Range(0, 5)]
        public int Jquery { get; set; }

        [Range(0, 5)]
        public int AngularJs { get; set; }

        [Range(0, 5)]
        public int Java { get; set; }

        [Range(0, 5)]
        public int AspNetMvc { get; set; }

        [Range(0, 5)]
        public int C { get; set; }

        [Range(0, 5)]
        public int Cplus { get; set; }


        [Range(0, 5)]
        public int Cake { get; set; }

        [Range(0, 5)]
        public int Django { get; set; }

        [Range(0, 5)]
        public int Majento { get; set; }

        [Range(0, 5)]
        public int Php { get; set; }

        [Range(0, 5)]
        public int Vue { get; set; }

        [Range(0, 5)]
        public int Wordpress { get; set; }

        [Range(0, 5)]
        public int Phyton { get; set; }

        [Range(0, 5)]
        public int Ruby { get; set; }

        [Range(0, 5)]
        public int SqlServer { get; set; }

        [Range(0, 5)]
        public int MySql { get; set; }

        [Range(0, 5)]
        public int Salesforce { get; set; }

        [Range(0, 5)]
        public int Photoshop { get; set; }

        [Range(0, 5)]
        public int Illustrator { get; set; }

        [Range(0, 5)]
        public int Seo { get; set; }

        #endregion Atributos

        public string Outra { get; set; }


    }
}
