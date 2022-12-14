<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Teretana._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      
    <h1 style="text-align:center;">Prikaz</h1>
     <link rel="stylesheet" href="style2.css">
    <div class="div2">Izaberite teretanu:<asp:DropDownList ID="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeretana_SelectedIndexChanged"></asp:DropDownList></div>

    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" >
        <Columns>
            <asp:BoundField DataField="idOsobe" HeaderText="idOsobe" />
            <asp:BoundField DataField="ime" HeaderText="ime" />
            <asp:BoundField DataField="prezime" HeaderText="prezime" />
            <asp:BoundField DataField="datumRodjenja" HeaderText="datumRodjenja" />
            <asp:BoundField DataField="kontakt" HeaderText="kontakt" />
            <asp:BoundField DataField="idTeretane" HeaderText="idTeretane" />
            <asp:ButtonField CommandName="Obrisi" Text="Obrisi" />
        </Columns>
    </asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeretanaConnectionString4 %>" SelectCommand="SELECT * FROM [Osoba]"></asp:SqlDataSource>

</asp:Content>
