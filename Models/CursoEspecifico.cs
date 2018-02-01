using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosProfissionalizantes.Models
{
    public class CursoEspecifico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCursoEspecifico { get; set; }

        [Required]
        public int IdCursoGeral { get; set; }

        [Required]
        [StringLength(100, MinimumLength=3)]
        public string NomeCursoEspecifico { get; set; }

        [Required]
        public DateTime DataInicio { get; set;} 

        [Required]
        public DateTime DataFim { get; set;} 

        [Required]
        public DateTime DataFim { get; set;} 

        [Required]
        public string PeriodoSemana { get; set; }
    }
}