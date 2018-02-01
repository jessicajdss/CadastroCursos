using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosProfissionalizantes.Models
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAluno { get; set; }

        [Required]
        [StringLength(100, MinimumLength=2)]
        public string NomeAluno { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Matricula> Matricula {get; set;}
    }
}