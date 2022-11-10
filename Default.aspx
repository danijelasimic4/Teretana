<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Teretana._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Prikaz</h1>
    Izaberite teretanu:<asp:DropDownList ID="ddlTeretana" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2">
    </asp:DropDownList>
    <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="False" DataKeyNames="idOsobe" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField HeaderText="idOsobe" DataField="idOsobe" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField HeaderText="ime" DataField="ime"/>
            <asp:BoundField HeaderText="prezime" DataField="prezime"/>
            <asp:BoundField HeaderText="datumRodjenja" DataField="datumRodjenja" />
            <asp:BoundField HeaderText="kontakt" DataField="kontakt" />
            <asp:BoundField HeaderText="idTeretane" DataField="idTeretane" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeretanaConnectionString3 %>" SelectCommand="SELECT * FROM [Osoba] WHERE ([idTeretane] = @idTeretane)" ProviderName="System.Data.SqlClient">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTeretana" Name="idTeretane" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
