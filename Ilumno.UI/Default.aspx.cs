using Ilumno.Model.Formulario;
using Ilumno.Model.Pais;
using Ilumno.Model.TipoDocumento;
using Ilumno.Service;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Ilumno.UI
{
    public partial class _Default : Page
    {
        private const int PageSize = 10; // Número de registros por página

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPaises();
                GetTipoDocumentos();
                GetFormularios();
            }
        }

        private void GetPaises()
        {
            PaisService service = new PaisService();
            List<PaisResponseDto> paises = service.ObtenerPaises();
            ddlPais.DataSource = paises;
            ddlPais.DataTextField = "Nombre";
            ddlPais.DataValueField = "Id";
            ddlPais.DataBind();
        }

        private void GetTipoDocumentos()
        {
            TipoDocumentoService service = new TipoDocumentoService();
            List<TipoDocumentoResponseDto> tipoDocumentos = service.ObtenerTipoDocumentos();
            ddlTipoDocumento.DataSource = tipoDocumentos;
            ddlTipoDocumento.DataTextField = "Nombre";
            ddlTipoDocumento.DataValueField = "Id";
            ddlTipoDocumento.DataBind();
        }

        private void GetFormularios()
        {
            FormularioService service = new FormularioService();
            List<FormularioDto> formularios = service.ObtenerFormularios();

            gvFormularios.PageSize = PageSize;
            gvFormularios.DataSource = formularios;
            gvFormularios.DataBind();
        }

        protected void gvFormularios_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvFormularios.PageIndex = e.NewPageIndex;
            GetFormularios(); // Vuelve a enlazar los datos
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            RequestFormulario request = new RequestFormulario
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                TipoDocumentoId = int.Parse(ddlTipoDocumento.SelectedValue),
                NumeroDocumento = txtNumeroDocumento.Text,
                CorreoElectronico = txtEmail.Text,
                Telefono = txtTelefono.Text,
                PaisId = int.Parse(ddlPais.SelectedValue)
            };

            FormularioService service = new FormularioService();
            var (success, errorMessage) = service.EnviarFormulario(request);

            if (success)
            {
                lblMensaje.Text = "Formulario enviado exitosamente.";
                lblMensaje.CssClass = "text-success";
                GetFormularios();
            }
            else
            {
                lblMensaje.Text = $"Error al enviar el formulario: {errorMessage}";
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}
