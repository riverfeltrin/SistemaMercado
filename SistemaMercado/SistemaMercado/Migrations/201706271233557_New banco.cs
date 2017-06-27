namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newbanco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Senha", c => c.String(nullable: false));
            AddColumn("dbo.Clientes", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "ConfirmPassword");
            DropColumn("dbo.Clientes", "Senha");
        }
    }
}
