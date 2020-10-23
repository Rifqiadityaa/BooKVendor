<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MemberPage.Master" AutoEventWireup="true" CodeBehind="MemberProfile.aspx.cs" Inherits="TMPsd.Views.MemberProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MemberProfileContainer">
        <h1>Profile</h1>
        <hr />

        <asp:GridView ID="MemberProfileGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left">
            <RowStyle HorizontalAlign="Left"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
