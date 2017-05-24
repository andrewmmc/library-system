<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="bookdetails.aspx.cs" Inherits="Librarysystem.public_bookdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Books Details - Library System</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Books Details</h2>
    You can check the details of books above.<br />
    <br />
    <!--Gridview 1 for viewing records.-->
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
        DataKeyNames="ISBN"
        OnPageIndexChanging="PageIndexChanging" AllowPaging="true"
        ShowHeaderWhenEmpty="True" EmptyDataText="No records found. Please check your input."
        PagerStyle-CssClass="paging" CssClass="myGridStyle">
        <FieldHeaderStyle ForeColor="#9d1a20" Font-Bold="True" />
        <Fields>
            <asp:TemplateField HeaderText="ISBN">
                <ItemTemplate>
                    <asp:Label ID="lblISBN" runat="server" Text='<%#Eval("ISBN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Title">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Signum">
                <ItemTemplate>
                    <asp:Label ID="lblSignum" runat="server" Text='<%# Eval("Signum") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publication Info">
                <ItemTemplate>
                    <asp:Label ID="lblPublicationInfo" runat="server" Text='<%# Eval("publicationinfo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publication Year">
                <ItemTemplate>
                    <asp:Label ID="lblPublicationYear" runat="server" Text='<%# Eval("PublicationYear") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pages">
                <ItemTemplate>
                    <asp:Label ID="lblPages" runat="server" Text='<%# Eval("pages") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
</asp:Content>
