using System;

namespace Ilumno.Model.Formulario
{
    public class FormularioResponseDto
    {
        public Guid Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public int PaisId { get; set; }
    }
}
