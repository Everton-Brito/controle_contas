using System.ComponentModel.DataAnnotations;

namespace SistemaContas.Mvc.Models
{
    public class ContasCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da conta.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data da conta.")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor da conta.")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o tipo da conta.")]
        public string Tipo { get; set; }
    }
}
