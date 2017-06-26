namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ClienteID");
            AddForeignKey("dbo.AspNetUsers", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
            DropColumn("dbo.Clientes", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Senha", c => c.String(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.AspNetUsers", new[] { "ClienteID" });
            DropColumn("dbo.AspNetUsers", "ClienteID");
        }
    }
}
