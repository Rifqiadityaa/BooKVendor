<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="UpdateGenre.aspx.cs" Inherits="TMPsd.Views.UpdateGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="UpdateGenreContainer">
        <h1>Update Genre Information</h1>
        <hr />

        <asp:GridView ID="UpdateGenreGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left" OnSelectedIndexChanged="UpdateGenreGridView_SelectedIndexChanged" OnRowDeleting="UpdateGenreGridView_RowDeleting" DataKeyNames="GenreID">
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

        <asp:TextBox ID="txtGenreID" runat="server" placeholder="GenreID" ReadOnly="True"></asp:TextBox>

        <asp:RequiredFieldValidator ID="GenreNameFieldValidator" runat="server" ErrorMessage="*Please enter genre name" ControlToValidate="txtGenreName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="txtGenreNameExpressionValidator" runat="server" ErrorMessage="*Minimum 3 characters required" ControlToValidate="txtGenreName" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{3,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtGenreName" runat="server" placeholder="Enter genre name"></asp:TextBox>

        <asp:RequiredFieldValidator ID="GenreDescFieldValidator" runat="server" ErrorMessage="*Please enter genre description" ControlToValidate="txtGenreDesc" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="txtGenreDescExpressionValidator" runat="server" ErrorMessage="*Minimum 10 characters required" ControlToValidate="txtGenreDesc" ForeColor="Red" Display="Dynamic" ValidationExpression="^[\s\S]{10,}$"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtGenreDesc" runat="server" placeholder="Enter genre description"></asp:TextBox>

        <asp:Label ID="UpdateSuccess" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="UpdateFailed" runat="server" Text="" ForeColor="Red"></asp:Label>


        <asp:Button ID="UpdateBtn" runat="server" Text="Update" class="UpdateBtn" OnClick="UpdateBtn_Click"/>
        </div>
    </div>
</asp:Content>
