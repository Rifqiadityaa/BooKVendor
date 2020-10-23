<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="InsertBook.aspx.cs" Inherits="TMPsd.Views.InsertBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="InsertBookContainer">
        <h1>Insert Book</h1>
        <hr />

        <asp:RequiredFieldValidator ID="NameFieldValidator" runat="server" ErrorMessage="*Please enter book name" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtName" runat="server" placeholder="Enter book name"></asp:TextBox>

        <asp:DropDownList ID="dropDownGenre" runat="server">
            <asp:ListItem>Select Genre</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:RequiredFieldValidator ID="DescFieldValidator" runat="server" ErrorMessage="*Please enter book description" ControlToValidate="txtDesc" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="txtDescExpressionValidator" runat="server" ErrorMessage="*Minimum 10 characters required" ControlToValidate="txtDesc" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{10,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtDesc" runat="server" placeholder="Enter book description"></asp:TextBox>

        <asp:RequiredFieldValidator ID="StockFieldValidator" runat="server" ErrorMessage="*Please enter book stock" ControlToValidate="txtStock" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtStock" runat="server" placeholder="Enter book stock" TextMode="Number"></asp:TextBox>

        <asp:RequiredFieldValidator ID="PriceFieldValidator" runat="server" ErrorMessage="*Please enter book price" ControlToValidate="txtPrice" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtPrice" runat="server" placeholder="Enter book price" TextMode="Number"></asp:TextBox>

        <asp:Label ID="InsertSuccess" runat="server" Text="" ForeColor="Green" Display="Dynamic"></asp:Label>

        <asp:Button ID="InsertBtn" runat="server" Text="Insert" class="InsertBtn" OnClick="InsertBtn_Click"/>
    </div>
</asp:Content>
