<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MemberPage.Master" AutoEventWireup="true" CodeBehind="MemberCart.aspx.cs" Inherits="TMPsd.Views.MemberCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CartContainer">
        <h1>Your Cart</h1>
        <hr />

        <asp:GridView ID="CartGridView" runat="server" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" Width="100%" OnRowDeleting="CartGridView_RowDeleting"
            GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"  OnRowDataBound="CartGridView_RowDataBound" ShowFooter="true" OnSelectedIndexChanged="CartGridView_SelectedIndexChanged" DataKeyNames="BookID">
            <RowStyle HorizontalAlign="Left"></RowStyle>
            <columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton Text="Select" ID="SelectBtn" runat="server" CommandName="Select" CausesValidation="false"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowDeleteButton="true" />
                <asp:BoundField HeaderText="Book ID" DataField="BookID" />
                <asp:BoundField HeaderText="Book Name" DataField="BookName" />
                <asp:BoundField HeaderText="Book Quantity" DataField="Quantity" />
                <asp:BoundField HeaderText="Book Price" DataField="BookPrice" />
                <asp:TemplateField HeaderText="Subtotal">
                    <ItemTemplate>
                        <asp:Label ID="SubtotalLabel" runat="server" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <b>Grand Total:</b>
                        <asp:Label ID="GrandTotalLabel" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>

        <asp:RequiredFieldValidator ID="BookIDFieldValidator" runat="server" ErrorMessage="*Please enter BookID (use the select button)" ControlToValidate="txtBookID" ForeColor="Red" Display="Dynamic" readOnly = "True"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtBookID" runat="server" placeholder="Enter book id" ReadOnly="True"></asp:TextBox>

        <asp:RequiredFieldValidator ID="txtQtyFieldValidator" runat="server" ErrorMessage="*Please enter book quantity" ControlToValidate="txtQuantity" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="QuantityRangeValidator" runat="server" ErrorMessage="*Quantity must be greater than zero." ControlToValidate="txtQuantity" MinimumValue="1" MaximumValue="1000" Type="Integer" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
        <asp:Label ID="txtQuantityFailed" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server" placeholder="Enter book quantity" TextMode="Number"></asp:TextBox>
        
        <asp:Button runat="server" Text="Update Table" OnClick="UpdateBtn_Click" />
        <br />

        <asp:Label ID="UpdateSuccess" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="UpdateFailed" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Label ID="SuccessDelete" runat="server" Text="" ForeColor="LightGreen"></asp:Label>
        <asp:Label ID="FailedDelete" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" class="UpdateBtn" OnClick="CheckoutBtn_Click" CausesValidation="False"/>
        
    </div>
</asp:Content>
