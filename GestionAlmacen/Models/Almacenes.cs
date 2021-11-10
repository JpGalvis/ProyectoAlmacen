using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAlmacen.Models
{
    public class Almacenes
    {
        [Key]
        public string producto { get; set; }
        [Display(Name = "nombre del producto")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 a 60 caracteres")]
        [Required(ErrorMessage = "producto requerido")]
        public string almacen { get; set; }
        [Display(Name = "tipo de almacen")]
        public string informacion { get; set; }
        [Url]
        [Display(Name = "link")]
        public string link { get; set; }

    }
}
