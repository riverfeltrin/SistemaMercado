namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alterar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Senha", c => c.String(nullable: false));
            AddColumn("dbo.Clientes", "ConfirmSenha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "ConfirmSenha");
            DropColumn("dbo.Clientes", "Senha");
        }
    }
}
