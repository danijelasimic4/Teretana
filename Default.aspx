﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Teretana._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Prikaz</h1>
    Izaberite teretanu:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList>
    <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="idOsobe" />
            <asp:BoundField HeaderText="Ime" />
            <asp:BoundField HeaderText="Prezime" />
            <asp:BoundField HeaderText="DatumRodjenja" />
            <asp:BoundField HeaderText="Kontakt" />
            <asp:BoundField HeaderText="idTeretane" />
            <asp:ButtonField CommandName="Obrisi" Text="Obrisi" />
        </Columns>
    </asp:GridView>

</asp:Content>
