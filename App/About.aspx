<%@ Page Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="About.aspx.cs" 
    Inherits="App.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <% string hola = "Hola Mundo"; %>
    <h4>Copnay <%: CompanyName %></h4>
    <h4><%: hola%></h4>
</asp:Content>
