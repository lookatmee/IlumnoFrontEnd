namespace Ilumno.Model.Formulario
{
    public class ResponseFormularioDto
    {
        //public string Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public Pais Pais { get; set; }
    }

    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
