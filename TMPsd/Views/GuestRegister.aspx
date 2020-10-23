<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestPage.Master" AutoEventWireup="true" CodeBehind="GuestRegister.aspx.cs" Inherits="TMPsd.Views.GuestRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="RegContainer">
        <h1>Register</h1>
        <hr />

        <asp:RequiredFieldValidator ID="RegUsernameFieldValidator" runat="server" ControlToValidate="RegUsername" ErrorMessage="*Please enter a Username" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegUSernameExpressionValidator" runat="server" ErrorMessage="*Minimum 3 characters required" ControlToValidate="RegUsername" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{3,}$"></asp:RegularExpressionValidator>
        <asp:Label ID="UsernameDuplicate" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:TextBox ID="RegUsername" runat="server" placeholder="Enter Username"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="RegPasswordFieldValidator" runat="server" ControlToValidate="RegPassword" ErrorMessage="*Please enter a password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegPasswordExpressionValidator" runat="server" ErrorMessage="*Minimum 8 characters required" ControlToValidate="RegPassword" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{8,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="RegPassword" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="ConfirmPasswordFieldValidator" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="*Please enter password confirmation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="RegPasswordCompareValidate" runat="server" ErrorMessage="*The password does not match" ControlToValidate="RegPassword"  ControlToCompare="ConfirmPassword" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
        <asp:TextBox ID="ConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RegNameFieldValidator" runat="server" ControlToValidate="RegName" ErrorMessage="*Please enter your name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="RegName" runat="server" placeholder="Enter Name"></asp:TextBox>
       
        <asp:RequiredFieldValidator ID="GenderRequiredFieldValidator" runat="server" ErrorMessage="*Please select gender" ForeColor="Red" Display="Dynamic" ControlToValidate="GenderButtonList"></asp:RequiredFieldValidator>
        <br />
        <asp:RadioButtonList ID="GenderButtonList" runat="server" class="Gender" RepeatDirection="Horizontal">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />

        <asp:RequiredFieldValidator ID="RegPhoneFieldValidator" runat="server" ErrorMessage="*Please enter your phone number (Numeric)" ForeColor="Red" Display="Dynamic" ControlToValidate="RegPhone"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegPhoneExpressionValidator" runat="server" ErrorMessage="*10 characters min, 13 characters max" ControlToValidate="RegPhone" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{10,13}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="RegPhone" runat="server" placeholder="Enter Phone Number" TextMode="Number"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RegAddressFieldValidator" runat="server" ErrorMessage="*Please enter your address" ControlToValidate="RegAddress" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="RegAddressCustomValidator" runat="server" ErrorMessage="*Address must contain the word 'street'" ForeColor="Red" ControlToValidate="RegAddress" OnServerValidate="RegAddressCustomValidator_ServerValidate" Display="Dynamic" ValidationGroup="RegisterValidation"></asp:CustomValidator>
        <asp:TextBox ID="RegAddress" runat="server" placeholder="Enter Address"></asp:TextBox>

         <asp:CheckBox ID="AdminCheck" class="CheckBox" runat="server" Text="  Register as admin" />
         <br />

        <asp:CustomValidator ID="TermCheckCustomValidator" runat="server" ErrorMessage="*Please agree to terms and conditions" ForeColor="Red" Display="Dynamic" OnServerValidate="TermCheckCustomValidator_ServerValidate" ValidationGroup="RegisterValidation"></asp:CustomValidator>
        <br />
        <asp:CheckBox ID="TermCheck" class="CheckBox"  runat="server" Text="  I agree to terms and conditions"/>
        <br />

        <asp:Label ID="RegisterSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="RegisterFailed" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Button ID="RegisterBtn" class="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
    </div>
</asp:Content>
