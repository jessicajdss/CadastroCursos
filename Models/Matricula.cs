using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosProfissionalizantes.Models
{
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatricula { get; set; }

        [Required]
        public int IdAluno { get; set; }
        
        [Required]
        public int IdCursoGeral { get; set; }
        
        [Required]
        public int IdCursoEspecifico { get; set; }
    }
}