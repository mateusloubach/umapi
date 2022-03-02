using System.ComponentModel.DataAnnotations;
namespace umapi
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string firstName { get; set; } = string.Empty;

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Sobrenome deve ser preenchido")]
        public string lastName { get; set; } = string.Empty;

        [Display(Name = "Nome da Mãe")]
        [Required(ErrorMessage = "Nome da Mãe deve ser preenchido")]
        public string motherName { get; set; } = string.Empty;

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail deve ser preenchido")]
        public string email { get; set; } = string.Empty;

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço deve ser preenchido")]
        public string end { get; set; } = string.Empty;

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF deve ser preenchido")]
        [StringLength(11, MinimumLength = 11)] 
        public string cpf { get; set; } = string.Empty;
    }
}
