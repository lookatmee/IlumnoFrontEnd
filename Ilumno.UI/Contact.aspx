<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Ilumno.UI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Adolfo Ismael Jinete Arriola.</h3>
        <address>
            Ingeniero de software<br />
            16 años de Experiencia Visual Studio .net<br />
            5 años de Experiencia .net core (6, 8)<br />
            <abbr title="Phone">Celular:</abbr>
            310 3593479
        </address>

        <address>
            <strong>Email:</strong>   <a href="mailto:adolfojinete@hotmail.com">adolfojinete@hotmail.com</a><br />
            <strong>LinkedIn:</strong> <a href="www.linkedin.com/in/adolfo-jinete">LinkedIn</a>
        </address>
    </main>
</asp:Content>
