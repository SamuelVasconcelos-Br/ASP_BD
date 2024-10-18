using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AppQuinto.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int IdCli { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string NomeCli { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        public int Numero { get; set; }

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "O campo Situacao é obrigatório")]
        public string Situacao { get; set; }

    }
}
