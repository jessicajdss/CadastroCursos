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
        [StringLength(100, MinimumLength=3)]
        public string NomeCursoGeral { get; set; }

        public CursoEspecifico CursoEspecifico {get; set;}


    }
}