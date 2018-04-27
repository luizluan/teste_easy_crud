namespace CRUD_EASY.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Agencia = c.String(),
                        NumerodaConta = c.String(),
                        TipodeConta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Skype = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        Linkedin = c.String(),
                        Cidade = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        PortFolio = c.String(),
                        CrudLink = c.String(),
                        Cpf = c.String(maxLength: 12),
                        IsDeleted = c.Boolean(nullable: false),
                        ValorHora = c.Int(nullable: false),
                        Banco_Id = c.Int(),
                        Conhecimento_Id = c.Int(),
                        Disponibilidade_Id = c.Int(),
                        MelhorHorario_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Candidato_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banco", t => t.Banco_Id)
                .ForeignKey("dbo.Conhecimento", t => t.Conhecimento_Id)
                .ForeignKey("dbo.Disponibilidade", t => t.Disponibilidade_Id)
                .ForeignKey("dbo.MelhorHorario", t => t.MelhorHorario_Id)
                .Index(t => t.Banco_Id)
                .Index(t => t.Conhecimento_Id)
                .Index(t => t.Disponibilidade_Id)
                .Index(t => t.MelhorHorario_Id);
            
            CreateTable(
                "dbo.Conhecimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ionic = c.Int(nullable: false),
                        Android = c.Int(nullable: false),
                        Ios = c.Int(nullable: false),
                        Html = c.Int(nullable: false),
                        CSS = c.Int(nullable: false),
                        Bootstrap = c.Int(nullable: false),
                        Jquery = c.Int(nullable: false),
                        AngularJs = c.Int(nullable: false),
                        Java = c.Int(nullable: false),
                        AspNetMvc = c.Int(nullable: false),
                        C = c.Int(nullable: false),
                        Cplus = c.Int(nullable: false),
                        Cake = c.Int(nullable: false),
                        Django = c.Int(nullable: false),
                        Majento = c.Int(nullable: false),
                        Php = c.Int(nullable: false),
                        Vue = c.Int(nullable: false),
                        Wordpress = c.Int(nullable: false),
                        Phyton = c.Int(nullable: false),
                        Ruby = c.Int(nullable: false),
                        SqlServer = c.Int(nullable: false),
                        MySql = c.Int(nullable: false),
                        Salesforce = c.Int(nullable: false),
                        Photoshop = c.Int(nullable: false),
                        Illustrator = c.Int(nullable: false),
                        Seo = c.Int(nullable: false),
                        Outra = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disponibilidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuatroHorasDia = c.Boolean(nullable: false),
                        QuatroaSeisHorasDia = c.Boolean(nullable: false),
                        MaisdeOitoHorasDia = c.Boolean(nullable: false),
                        ApenasFimSemana = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MelhorHorario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manha = c.Boolean(nullable: false),
                        Tarde = c.Boolean(nullable: false),
                        Noite = c.Boolean(nullable: false),
                        Madrugada = c.Boolean(nullable: false),
                        HorarioComercial = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidato", "MelhorHorario_Id", "dbo.MelhorHorario");
            DropForeignKey("dbo.Candidato", "Disponibilidade_Id", "dbo.Disponibilidade");
            DropForeignKey("dbo.Candidato", "Conhecimento_Id", "dbo.Conhecimento");
            DropForeignKey("dbo.Candidato", "Banco_Id", "dbo.Banco");
            DropIndex("dbo.Candidato", new[] { "MelhorHorario_Id" });
            DropIndex("dbo.Candidato", new[] { "Disponibilidade_Id" });
            DropIndex("dbo.Candidato", new[] { "Conhecimento_Id" });
            DropIndex("dbo.Candidato", new[] { "Banco_Id" });
            DropTable("dbo.MelhorHorario");
            DropTable("dbo.Disponibilidade");
            DropTable("dbo.Conhecimento");
            DropTable("dbo.Candidato",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Candidato_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Banco");
        }
    }
}
