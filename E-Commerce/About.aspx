<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="E_Commerce.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 class="mb-3 display-3" id="title" runat="server"></h2>
        <div id="container" class="mt-4 row">
            <div class="col-12 col-md-4 col-lg-5">
                <img id="productImg" class="img-fluid" runat="server" src="#"/>
            </div>
            <div class="col-12 col-md-8 col-lg-7">
                <p class="display-6 fw-bold" id="productDesc" runat="server"></p>
                <p class="text-primary fs-3" id="productPrice" runat="server"></p>
                <p class="fs-4 text-black-50" id="productQt" runat="server"></p>
                <div class="d-flex g-3">
                     <asp:Button ID="addToCart" class="btn btn-primary rounded-pill py-2 px-4" runat="server" Text="Aggiungi al Carrello" OnClick="addToCart_Click" />
                     <asp:Button ID="BackToHome" runat="server" CssClass="btn btn-outline-primary rounded-pill py-2 px-4" Text="Torna a tutti i prodotti" OnClick="BackToHome_Click"/>
                     <asp:Button ID="goToCart" runat="server" CssClass="btn btn-outline-dark rounded-pill py-2 px-4" Text="Vai Al carrello" OnClick="goToCart_Click"/>
               
                </div>
                <br />
                <div class="mt-3">
                    <asp:Label ID="conferma" runat="server" CssClass="text-black-50 display-6 fs-4"></asp:Label>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
