using System.Collections.Generic;

namespace Ilumno.Model.Formulario
{
    public class ApiErrorResponse
    {
        public List<ErrorDetail> Errors { get; set; }
    }

    public class ErrorDetail
    {
        public string Field { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
    }
}
