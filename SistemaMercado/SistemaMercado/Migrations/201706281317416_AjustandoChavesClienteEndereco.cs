namespace SistemaMercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustandoChavesClienteEndereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EnderecoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoID, cascadeDelete: true)
                .Index(t => t.EnderecoID);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoID = c.Int(nullable: false, identity: true),
                        Rua = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Cep = c.String(),
                    })
                .PrimaryKey(t => t.EnderecoID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Venda_VendaID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaID)
                .Index(t => t.CategoriaID)
                .Index(t => t.Venda_VendaID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        _Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t._Cliente_ClienteID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t._Cliente_ClienteID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaID = c.Int(nullable: false, identity: true),
                        FormaPag = c.String(nullable: false),
                        _Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.VendaID)
                .ForeignKey("dbo.Clientes", t => t._Cliente_ClienteID)
                .Index(t => t._Cliente_ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Venda_VendaID", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "_Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "_Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Clientes", "EnderecoID", "dbo.Enderecoes");
            DropIndex("dbo.Vendas", new[] { "_Cliente_ClienteID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "_Cliente_ClienteID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Produtoes", new[] { "Venda_VendaID" });
            DropIndex("dbo.Produtoes", new[] { "CategoriaID" });
            DropIndex("dbo.Clientes", new[] { "EnderecoID" });
            DropTable("dbo.Vendas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
