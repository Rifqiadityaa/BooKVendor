<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="TMPsd.Views.AdminProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AdminProfileContainer">
        <h1>Profile</h1>
        <hr />

        <asp:GridView ID="AdminProfileGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left">
            <RowStyle HorizontalAlign="Left"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
