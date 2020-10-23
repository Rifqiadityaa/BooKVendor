<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MemberPage.Master" AutoEventWireup="true" CodeBehind="MemberTransactionHistory.aspx.cs" Inherits="TMPsd.Views.MemberTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MemberTransactionHistoryContainer">
        <h1>Transaction History</h1>
        <hr />

         <asp:GridView ID="TransactionHistoryGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" Width="100%" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left" OnRowDataBound="TransactionHistoryGridView_RowDataBound">
                <RowStyle HorizontalAlign="Left"></RowStyle>
                <columns>
                    <asp:BoundField HeaderText="Book Name" DataField="BookName" />
                    <asp:BoundField HeaderText="Book Price" DataField="BookPrice" />
                    <asp:BoundField HeaderText="Book Quantity" DataField="Quantity" />
                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <asp:Label ID="SubtotalLabel" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Transaction Date" DataField="Date" />
                </columns>
            </asp:GridView>
     </div>
</asp:Content>
