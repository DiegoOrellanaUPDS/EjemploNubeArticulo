using System;
using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class ContabilidadUsuario
    {
        [Key]
        public int CON_Id { get; set; }

    
        public string CON_Nombre { get; set; } = "";

        public string CON_Email { get; set; } = "";


        public string CON_Rol { get; set; } = "Usuario";


        public DateTime CON_FechaRegistro { get; set; }

        
        public string CON_Departamento { get; set; } = "Contabilidad";

        public string CON_Telefono { get; set; } = "";


        public bool CON_Activo { get; set; } = true;

        public decimal CON_Salario { get; set; }
    }
}