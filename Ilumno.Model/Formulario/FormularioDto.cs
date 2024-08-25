using System;

namespace Ilumno.Model.Formulario
{
    public class FormularioDto
    {
        public Guid Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
    }
}
