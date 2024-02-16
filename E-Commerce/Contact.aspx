<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="E_Commerce.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 class="display-2" id="title">Il tuo carrello</h2>
        
        <div id="container" runat="server">
            
        </div>
        <div class="d-flex justify-content-between align-items-center mt-3">
            <asp:Button ID="deleteCart" runat="server" Text="Svuota carrello" class="btn btn-danger" OnClick="DeleteCart_Click"/>
            <p class="display-6 text-dark" id="totCart" runat="server"></p>
        </div>
        
    </main>
</asp:Content>
