<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MemberPage.Master" AutoEventWireup="true" CodeBehind="MemberBook.aspx.cs" Inherits="TMPsd.Views.MemberBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MemberBookContainer">
        <h1>Books</h1>
        <hr />

        <asp:GridView ID="ProdGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"  DataKeyNames="BookID">
            <RowStyle HorizontalAlign="Left"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
