<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Teretana._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Prikaz</h1>
    Izaberite teretanu:<asp:DropDownList ID="ddlTeretana" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeretana_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="idTeretane" DataValueField="idTeretane"></asp:DropDownList>
    <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="False" DataKeyNames="idOsobe" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField HeaderText="idOsobe" DataField="idOsobe" InsertVisible="False" ReadOnly="True" SortExpression="idOsobe" />
            <asp:BoundField HeaderText="ime" DataField="ime" SortExpression="ime" />
            <asp:BoundField HeaderText="prezime" DataField="prezime" SortExpression="prezime" />
            <asp:BoundField HeaderText="datumRodjenja" DataField="datumRodjenja" SortExpression="datumRodjenja" />
            <asp:BoundField HeaderText="kontakt" DataField="kontakt" SortExpression="kontakt" />
            <asp:BoundField HeaderText="idTeretane" DataField="idTeretane" SortExpression="idTeretane" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeretanaConnectionString3 %>" SelectCommand="SELECT * FROM [Osoba]"></asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeretanaConnectionString %>" SelectCommand="SELECT * FROM [Osoba]"></asp:SqlDataSource>

</asp:Content>
