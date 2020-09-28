namespace AlunoCurso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faculdade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(),
                        Sexo = c.String(),
                        CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CursoModels", t => t.CursoId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.CursoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Curso = c.String(nullable: false),
                        CH = c.String(nullable: false),
                        Periodo = c.String(nullable: false),
                        QDisciplinas = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlunoModels", "CursoId", "dbo.CursoModels");
            DropIndex("dbo.AlunoModels", new[] { "CursoId" });
            DropTable("dbo.CursoModels");
            DropTable("dbo.AlunoModels");
        }
    }
}
