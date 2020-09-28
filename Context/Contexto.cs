using System;
using AlunoCurso.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AlunoCurso.Context
{
    public class Contexto :DbContext
    {
        public DbSet<AlunoModel> alunos { get; set; }
        public DbSet<CursoModel> cursos { get; set; }

        
    }
}