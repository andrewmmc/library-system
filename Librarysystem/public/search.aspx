<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Librarysystem.public_search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Books Search - Library System</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Books Search</h2>
    You can search the books by title or author.<br />
<asp:DropDownList ID="ddlistSearch" runat="server">
<asp:ListItem Value="title">Title</asp:ListItem>
<asp:ListItem Value="author">Author</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="txtSearch" runat="server" />&nbsp;
<asp:Button ID="btnSearch" Text="Search" runat="server" onclick="btnSearch_Click" />
<asp:Button ID="btnClear" Text="Reset" runat="server" onclick="btnClear_Click" /><br />
    <br />
    <!--Gridview 1 for viewing records.-->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        DataKeyNames="ISBN" 
        OnPageIndexChanging="PageIndexChanging" AllowPaging="true"
        ShowHeaderWhenEmpty="True" EmptyDataText="No records found. Please check your input."
        PagerStyle-CssClass="paging" CssClass="myGridStyle">
        <Columns>
            <asp:TemplateField HeaderText="ISBN">
                <ItemTemplate>
                    <asp:Label ID="lblISBN" runat="server" Text='<%#Eval("ISBN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Title">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# HighlightText(Eval("Title").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# HighlightText(Eval("Name").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:HyperLinkField HeaderText="Details" Text="Details"
                      DataNavigateUrlFormatString="~/public/bookdetails.aspx?ISBN={0}"
                      DataNavigateUrlFields="ISBN" /> 
        </Columns>
    </asp:GridView>
</asp:Content>
