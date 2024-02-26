using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioWorkerService.Modelo
{
    public class MinhaMensagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Mensagem")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 1000 caracteres.")]
        public string Mensagem { get; set; } = "";

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de inclusão obrigatório.")]
        public DateTime DataHoraCotacao { get; set; }
    }
}
