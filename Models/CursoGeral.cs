using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosProfissionalizantes.Models
{
    public class CursoGeral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCursoGeral { get; set; }

        [Required]
        public int IdCursoEspecifico { get; set; }

        [Required]
        public string NomeCursoGeral { get; set; }
    }
}