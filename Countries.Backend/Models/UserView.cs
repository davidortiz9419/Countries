namespace Countries.Backend.Models
{
    using Domain;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class UserView : User
    {
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(20, ErrorMessage = "La longitud del campo {0} debe estar entre {1} y {2} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        [Display(Name = "Confirmar Contraseña")]
        public string PasswordConfirm { get; set; }
    }
}