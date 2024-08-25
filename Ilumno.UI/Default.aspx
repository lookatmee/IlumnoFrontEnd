<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ilumno.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">FORMULARIO</h1>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Agregar nuevo formulario</h2>
                <div class="col-md-6">
                    <asp:Panel ID="pnlFormulario" runat="server" CssClass="p-3">
                        <div class="mb-3">
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
                        </div>
                        <div class="mb-3">
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-select" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control" Placeholder="Número de documento" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Correo electrónico" />
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Teléfono" />
                        </div>
                        <div class="mb-3">
                            <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-select" />
                        </div>
                        <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnEnviar_Click" />
                    </asp:Panel>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3" />
                </div>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2>Lista de Formularios</h2>
                <asp:GridView ID="gvFormularios" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvFormularios_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo Documento" />
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento" />
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Pais" HeaderText="País" />
                    </Columns>
                </asp:GridView>
            </section>
        </div>
    </main>
</asp:Content>
