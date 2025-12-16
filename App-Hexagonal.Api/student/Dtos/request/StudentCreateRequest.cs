using System.ComponentModel.DataAnnotations;

namespace App_Hexagonal.Api.student.Dtos.request

{
    public class StudentCreateRequest
    {
        [Required(ErrorMessage = "El nombre de archivo es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre de archivo no puede superar los 100 caracteres")]
        public string FileName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres")]
        public string LastName { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres")]
        public string Adress { get; set; } = string.Empty;
    }
}