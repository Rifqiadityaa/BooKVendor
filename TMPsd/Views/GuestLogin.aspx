<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestPage.Master" AutoEventWireup="true" CodeBehind="GuestLogin.aspx.cs" Inherits="TMPsd.Views.GuestLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="LogContainer">
        <h1>Login</h1>
        <hr />
        
        <asp:RequiredFieldValidator ID="LogUsernameFieldValidator" runat="server" ErrorMessage="*Please enter your Username" ControlToValidate="LogUsername" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="LogUsername" runat="server" placeholder="Enter Username"></asp:TextBox>

        <asp:RequiredFieldValidator ID="LogPasswordFieldValidator" runat="server" ErrorMessage="*Please enter your password" ControlToValidate="LogPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="LogPassword" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>

        <asp:CheckBox ID="RememberCheck" runat="server" Text=" Remember Me" class="RememberCheck"/>
        <br />

        <asp:Label ID="WrongCombination" runat="server" Text="" ForeColor="Red"></asp:Label>
         <asp:Label ID="Banned" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Button ID="LoginBtn" runat="server" Text="Login" class="LoginBtn" OnClick="LoginBtn_Click"/>
    </div>
</asp:Content>
