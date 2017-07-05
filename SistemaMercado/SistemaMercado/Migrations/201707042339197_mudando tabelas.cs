namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudandotabelas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "CPF", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "CPF", c => c.String(nullable: false));
        }
    }
}
