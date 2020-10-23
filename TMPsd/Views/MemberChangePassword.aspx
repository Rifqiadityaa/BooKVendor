<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MemberPage.Master" AutoEventWireup="true" CodeBehind="MemberChangePassword.aspx.cs" Inherits="TMPsd.Views.MemberChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ChangePasswordContainer">
        <h1>Change Password</h1>
        <hr />

        <asp:RequiredFieldValidator ID="txtOldFieldValidator" runat="server" ErrorMessage="*Please enter old password" ForeColor="Red" Display="Dynamic" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtOldPassword" runat="server" placeholder="Insert old password" TextMode="Password"></asp:TextBox>

        <asp:RequiredFieldValidator ID="txtNewFieldValidator" runat="server" ErrorMessage="*Please enter new password" ForeColor="Red" Display="Dynamic" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="txtPasswordExpressionValidator" runat="server" ErrorMessage="*Minimum 5 characters required" ControlToValidate="txtNewPassword" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{5,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtNewPassword" runat="server" placeholder="Insert new password" TextMode="Password"></asp:TextBox>

        <asp:RequiredFieldValidator ID="txtConfirmFieldValidator" runat="server" ErrorMessage="*Please confirm new password" ForeColor="Red" Display="Dynamic" ControlToValidate="txtConfirmNewPassword"></asp:RequiredFieldValidator>
         <asp:CompareValidator ID="txtPasswordCompareValidate" runat="server" ErrorMessage="*The password does not match" ControlToValidate="txtNewPassword"  ControlToCompare="txtConfirmNewPassword" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
        <asp:TextBox ID="txtConfirmNewPassword" runat="server" placeholder="Confirm new password" TextMode="Password"></asp:TextBox>

        <asp:Label ID="SuccessLabel" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="FailedLabel" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Button ID="ChangePassBtn" runat="server" Text="Update Password" class="ChangePassBtn" OnClick="ChangePassBtn_Click"/>
    </div>
</asp:Content>
