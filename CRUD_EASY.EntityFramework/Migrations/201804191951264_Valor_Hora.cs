namespace CRUD_EASY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valor_Hora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidato", "ValorHora", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidato", "ValorHora");
        }
    }
}
