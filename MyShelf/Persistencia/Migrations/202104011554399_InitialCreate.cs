namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estante",
                c => new
                    {
                        EstanteID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CategoriaID = c.Long(),
                    })
                .PrimaryKey(t => t.EstanteID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        LivroID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Autor = c.String(),
                        AnoLancamento = c.String(),
                        Descricao = c.String(),
                        EstanteID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LivroID)
                .ForeignKey("dbo.Estante", t => t.EstanteID, cascadeDelete: true)
                .Index(t => t.EstanteID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Long(nullable: false, identity: true),
                        User = c.String(),
                        Senha = c.String(),
                        Nome = c.String(),
                        Date_Nasc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "EstanteID", "dbo.Estante");
            DropForeignKey("dbo.Estante", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Livro", new[] { "EstanteID" });
            DropIndex("dbo.Estante", new[] { "CategoriaID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Livro");
            DropTable("dbo.Categoria");
            DropTable("dbo.Estante");
        }
    }
}
