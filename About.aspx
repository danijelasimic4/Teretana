﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Teretana.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="about">
        <h1>Unos novih clanova</h1>
        Ime:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Prezime:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        Datum rodjenja:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        Kontakt:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        ID teretane:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnDodaj" runat="server" Text="Dodaj" OnClick="btnDodaj_Click" />
    </div> <link rel="stylesheet" href="style2.css">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeretanaConnectionString2 %>" SelectCommand="SELECT * FROM [Osoba]"></asp:SqlDataSource>
</asp:Content>

