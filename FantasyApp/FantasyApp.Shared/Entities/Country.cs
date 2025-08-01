using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; } = null!;
        [Display(Name = "Código")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Code { get; set; } = string.Empty;
        [Display(Name = "Activo")]
        public bool IsActive { get; set; } = true;

        // public List<string> Languages { get; set; } = new List<string>();
    }
}