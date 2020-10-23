<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="InsertGenre.aspx.cs" Inherits="TMPsd.Views.InsertGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="InsertGenreContainer">
        <h1>Insert Genre</h1>
        <hr />

        <asp:RequiredFieldValidator ID="GenreNameFieldValidator" runat="server" ErrorMessage="*Please enter genre name" ControlToValidate="txtGenreName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="txtNameExpressionValidator" runat="server" ErrorMessage="*Minimum 3 characters required" ControlToValidate="txtGenreName" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{3,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtGenreName" runat="server" placeholder="Enter genre name"></asp:TextBox>

        <asp:RequiredFieldValidator ID="GenreDescFieldValidator" runat="server" ErrorMessage="*Please enter genre description" ControlToValidate="txtGenreDesc" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="txtDescExpressionValidator" runat="server" ErrorMessage="*Minimum 10 characters required" ControlToValidate="txtGenreDesc" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{10,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtGenreDesc" runat="server" placeholder="Enter genre description"></asp:TextBox>

        <asp:Label ID="InsertSuccess" runat="server" Text="" ForeColor="Green" Display="Dynamic"></asp:Label>

        <asp:Button ID="InsertBtn" runat="server" Text="Insert" class="InsertBtn" OnClick="InsertBtn_Click"/>
    </div>
</asp:Content>
