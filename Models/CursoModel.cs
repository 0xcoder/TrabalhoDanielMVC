using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlunoCurso.Models
{
    public class CursoModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do curso")]
        [Display(Name = "Nome do Curso:")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Informe a carga horária")]
        [Display(Name = "Carga Horária:")]
        public string CH { get; set; }

        [Required(ErrorMessage = "Informe o Periodo")]
        [Display(Name = "Periodo:")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "Informe Quantidade de Disciplinas")]
        [Display(Name = "Quantidade de Disciplinas:")]
        public string QDisciplinas { get; set; }

        [Required(ErrorMessage = "Informe se o Curso está Ativo ou não")]
        [Display(Name = "Status:")]
        public string Status { get; set; }


        public virtual ICollection<AlunoModel> Alunos { get; set; }
    }
}