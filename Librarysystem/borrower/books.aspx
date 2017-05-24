<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="Librarysystem.BorrowerBooksPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Borrowed Books - Library System</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Borrowed Books by 
    <%if ((Roles.IsUserInRole("Admin")) && (editable == "true")) {
          Response.Write(personid);
          %>
    <%} else { %>me
    <%} %></h2>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Barcode" AllowPaging="true"
        OnRowCommand="FireRowCommand" 
        EmptyDataText="No records found."
        PagerStyle-CssClass="paging" CssClass="myGridStyle">
        <Columns>
            <asp:TemplateField HeaderText="Barcode">
                <ItemTemplate>
                    <asp:Label ID="lblBarcode" runat="server" Text='<%#Eval("Barcode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Library">
                <ItemTemplate>
                    <asp:Label ID="lblLibrary" runat="server" Text='<%#Eval("Library") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Borrow Date">
                <ItemTemplate>
                    <asp:Label ID="lblBorrowDate" runat="server" Text='<%#Eval("BorrowDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Due Date">
                <ItemTemplate>
                    <asp:Label ID="lblToBeReturnedDate" runat="server" Text='<%#Eval("ToBeReturnedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Return Date">
                <ItemTemplate>
                    <asp:Label ID="lblReturnDate" runat="server" Text='<%#Eval("ReturnDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Renew Loan">
                <ItemTemplate>
                    <asp:LinkButton ID="btnRenew" runat="server" CommandArgument='<%# Eval("Barcode") %>'
                        CommandName="Renew" Text="Renew Loan" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
