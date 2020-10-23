<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="TMPsd.Views.UpdateBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="UpdateBookContainer">
        <h1>Update Book Information</h1>
        <hr />

        <asp:GridView ID="UpdateBookGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left" OnSelectedIndexChanged="UpdateBookGridView_SelectedIndexChanged" OnRowDeleting="UpdateBookGridView_RowDeleting" DataKeyNames="BookID">
            <RowStyle HorizontalAlign="Left"></RowStyle>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Select" ID="SelectBtn" runat="server" CommandName="Select" CausesValidation="false"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="SuccessDelete" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="FailedDelete" runat="server" Text="" ForeColor="Red"></asp:Label>

        <div class="table">

        <asp:TextBox ID="txtBookID" runat="server" placeholder="BookID" ReadOnly="True"></asp:TextBox>

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

        <asp:Label ID="UpdateSuccess" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="UpdateFailed" runat="server" Text="" ForeColor="Red"></asp:Label>


        <asp:Button ID="UpdateBtn" runat="server" Text="Update" class="UpdateBtn" OnClick="UpdateBtn_Click"/>
        </div>
    </div>
</asp:Content>
