<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="author.aspx.cs" Inherits="Librarysystem.AuthorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Author administration - Library System</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Author administration</h2>
    You can add, update or remove an author here. When an
author is removed, please note that the authors books shall also be deleted.<br />
    <br />
    <asp:FormView ID="FormView1" runat="server" OnItemInserting="ItemInserting" DefaultMode="Insert">
        <InsertItemTemplate>
            <table class="InsertTable">
                <tr>
                    <th colspan="2">Add a record</th>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="addFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="addLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Birth Year</td>
                    <td>
                        <asp:TextBox ID="addBirthYear" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="border-bottom: none;">
                        <asp:LinkButton ID="InsertButton" Text="Insert" CommandName="Insert" runat="server" /></td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Aid" OnRowEditing="RowEditing"
        OnRowCancelingEdit="RowCancelingEdit" OnRowUpdating="RowUpdating"
        OnRowDeleting="RowDeleting"
        OnPageIndexChanging="PageIndexChanging" AllowPaging="true"
        PagerStyle-CssClass="paging" CssClass="myGridStyle">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="lblAid" runat="server" Text='<%#Eval("Aid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Birth Year">
                <ItemTemplate>
                    <asp:Label ID="lblBirthYear" runat="server" Text='<%#Eval("BirthYear") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtBirthYear" runat="server" Text='<%#Eval("BirthYear") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
