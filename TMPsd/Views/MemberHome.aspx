<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MemberPage.Master" AutoEventWireup="true" CodeBehind="MemberHome.aspx.cs" Inherits="TMPsd.Views.MemberHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MemberHomeContainer">
        <div style="margin-left: auto; margin-right: auto; text-align: center; margin-top: 30px;">
            <asp:Label ID="HelloLabel" runat="server" Text="" ForeColor="Black" class="HelloLabel"></asp:Label>
        </div>
        <h1>Welcome To BooKVendor</h1>

        <asp:GridView ID="BookHomeGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="true" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"  DataKeyNames="BookID" OnRowCommand ="BookHomeGridView_OnRowCommand">
            <RowStyle HorizontalAlign="Left"></RowStyle>
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="CartLinkButton" runat="server" CommandName="AddToCart" CommandArgument='<%# Eval("BookID") %>'>Add to cart</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="AddFailed" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
