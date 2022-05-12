
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunosApiArnaldo.Models
{
    [Table("Alunos")]
    public partial class Aluno
    {       
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }   
        [Required]
        public int Idade { get; set; }

    }
}
