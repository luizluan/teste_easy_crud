namespace CRUD_EASY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tipodeconta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banco", "TipodeConta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banco", "TipodeConta");
        }
    }
}
