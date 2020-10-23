<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminBook.aspx.cs" Inherits="TMPsd.Views.AdminBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AdminBookContainer">
        <h1>Books</h1>
        <hr />

        <asp:GridView ID="AdminBookGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"  DataKeyNames="BookID">
            <RowStyle HorizontalAlign="Left"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
