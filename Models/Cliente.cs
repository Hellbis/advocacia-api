using System.ComponentModel.DataAnnotations;

namespace Advocacia_Api.Models
{
    public class Cliente
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        public string? Email { get; set; }
    }
}
