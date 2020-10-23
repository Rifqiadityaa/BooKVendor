<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminGenre.aspx.cs" Inherits="TMPsd.Views.AdminGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AdminGenreContainer">
        <h1>Genres</h1>
        <hr />

        <asp:GridView ID="GenreGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"  DataKeyNames="GenreID">
            <RowStyle HorizontalAlign="Left"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
