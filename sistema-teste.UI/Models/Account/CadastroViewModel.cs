using System.ComponentModel.DataAnnotations;

namespace sistema_teste.UI.Models.Account
{
    public class CadastroViewModel
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NomeCompleto { get; set; }
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As Senhas não conferem")]
        public string PasswordConfirmn { get; set; }
        public long Cpf { get; set; }
        public string? Celular { get; set; }
        public string? Cep { get; set; }
        public string? Endereco { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public DateTime DataNacimento { get; set; }
        public string? Genero { get; set; }

    }
}
