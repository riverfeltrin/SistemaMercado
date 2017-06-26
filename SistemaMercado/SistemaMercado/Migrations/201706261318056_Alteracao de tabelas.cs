namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracaodetabelas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.AspNetUsers", new[] { "ClienteID" });
            RenameColumn(table: "dbo.AspNetUsers", name: "ClienteID", newName: "_Cliente_ClienteID");
            AlterColumn("dbo.AspNetUsers", "_Cliente_ClienteID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "_Cliente_ClienteID");
            AddForeignKey("dbo.AspNetUsers", "_Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "_Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.AspNetUsers", new[] { "_Cliente_ClienteID" });
            AlterColumn("dbo.AspNetUsers", "_Cliente_ClienteID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "_Cliente_ClienteID", newName: "ClienteID");
            CreateIndex("dbo.AspNetUsers", "ClienteID");
            AddForeignKey("dbo.AspNetUsers", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
        }
    }
}
