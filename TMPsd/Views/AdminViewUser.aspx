<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminViewUser.aspx.cs" Inherits="TMPsd.Views.AdminViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AdminViewUserContainer">
        <h1>Users</h1>
        <hr />

        <asp:GridView ID="AdminViewUserGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"  DataKeyNames="UserID" OnRowCommand ="AdminViewUserGridView_OnRowCommand">
            <RowStyle HorizontalAlign="Left"></RowStyle>
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="DeleteUser" CommandArgument='<%# Eval("UserID") %>'>Delete</asp:LinkButton>
                        <asp:LinkButton ID="BanLinkButton" runat="server" CommandName="BanUser"  CommandArgument='<%# Eval("UserID") %>'>Ban</asp:LinkButton>
                        <asp:LinkButton ID="UnbanLinkButton" runat="server" CommandName="UnbanUser"  CommandArgument='<%# Eval("UserID") %>'>Unban</asp:LinkButton>
                        <asp:LinkButton ID="PromoteLinkButton" runat="server" CommandName="PromoteUser"  CommandArgument='<%# Eval("UserID") %>'>Promote</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="SuccessDelete" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="FailedDelete" runat="server" Text="" ForeColor="Red"></asp:Label>


        <asp:Label ID="SuccessBan" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="FailedBan" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Label ID="SuccessUnban" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="FailedUnban" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Label ID="FailedAlreadyBan" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Label ID="FailedAlreadyUnban" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Label ID="SuccessPromote" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="FailedPromote" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
