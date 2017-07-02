namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudandobanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendas", "_Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Produtoes", new[] { "Venda_VendaID" });
            DropIndex("dbo.Vendas", new[] { "_Cliente_ClienteID" });
            RenameColumn(table: "dbo.Vendas", name: "_Cliente_ClienteID", newName: "ClienteID");
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        ItemVendaID = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Produto_ProdutoID = c.Int(),
                        Venda_VendaID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaID)
                .ForeignKey("dbo.Produtoes", t => t.Produto_ProdutoID)
                .Index(t => t.Produto_ProdutoID)
                .Index(t => t.Venda_VendaID);
            
            AlterColumn("dbo.Vendas", "ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vendas", "ClienteID");
            AddForeignKey("dbo.Vendas", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
            DropColumn("dbo.Produtoes", "Venda_VendaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Venda_VendaID", c => c.Int());
            DropForeignKey("dbo.Vendas", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.ItemVendas", "Produto_ProdutoID", "dbo.Produtoes");
            DropIndex("dbo.ItemVendas", new[] { "Venda_VendaID" });
            DropIndex("dbo.ItemVendas", new[] { "Produto_ProdutoID" });
            DropIndex("dbo.Vendas", new[] { "ClienteID" });
            AlterColumn("dbo.Vendas", "ClienteID", c => c.Int());
            DropTable("dbo.ItemVendas");
            RenameColumn(table: "dbo.Vendas", name: "ClienteID", newName: "_Cliente_ClienteID");
            CreateIndex("dbo.Vendas", "_Cliente_ClienteID");
            CreateIndex("dbo.Produtoes", "Venda_VendaID");
            AddForeignKey("dbo.Vendas", "_Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
    }
}
