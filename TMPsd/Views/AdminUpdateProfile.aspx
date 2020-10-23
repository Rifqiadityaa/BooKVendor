<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateProfile.aspx.cs" Inherits="TMPsd.Views.AdminUpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AdminUpdateProfileContainer">
        <h1>Update Profile</h1>
        <hr />

        <asp:GridView ID="AdminUpdateProfileGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left" OnSelectedIndexChanged="MemberUpdateProfileGridView_SelectedIndexChanged" DataKeyNames="UserID">
            <RowStyle HorizontalAlign="Left"></RowStyle>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Select" ID="SelectBtn" runat="server" CommandName="Select" CausesValidation="false"  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="ProfileContent">
            <asp:TextBox ID="txtUserID" runat="server" placeholder="UserID" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" ReadOnly="True"></asp:TextBox>

            <asp:RequiredFieldValidator ID="txtNameFieldValidator" runat="server" ErrorMessage="*Please enter name" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtName" runat="server" placeholder="Insert Name"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="txtGenderFieldValidator" runat="server" ErrorMessage="*Please enter gender" ControlToValidate="txtGender" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtGender" runat="server" placeholder="Insert Gender"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="txtPhoneFieldValidator" runat="server" ErrorMessage="*Please enter phone number" ControlToValidate="txtPhone" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="txtPhoneExpressionValidator" runat="server" ErrorMessage="*10 characters min, 13 characters max" ControlToValidate="txtPhone" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{10,13}$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPhone" runat="server" placeholder="Insert phone number" TextMode="Number"></asp:TextBox>
          
            <asp:RequiredFieldValidator ID="txtAddressFieldValidator" runat="server" ErrorMessage="*Please enter address" ControlToValidate="txtAddress" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="txtAddressCustomValidator" runat="server" ErrorMessage="*Address must contain the word 'street'" ForeColor="Red" ControlToValidate="txtAddress" OnServerValidate="txtAddressCustomValidator_ServerValidate" Display="Dynamic" ValidationGroup="RegisterValidation"></asp:CustomValidator>
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Insert address"></asp:TextBox>

            <asp:Label ID="UpdateSuccess" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
            <asp:Label ID="UpdateFailed" runat="server" Text="" ForeColor="Red"></asp:Label>
            
            <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update" class="UpdateProfileBtn" OnClick="UpdateBtn_Click"/>
        </div>
    </div>
</asp:Content>
