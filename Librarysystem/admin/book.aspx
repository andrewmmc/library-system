<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="Librarysystem.BookPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Book administration - Library System</title>
     <script type = "text/javascript">
         function functionx(evt) {
             if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                 //alert("Numbers only.");
                 return false;
             }
         }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Book administration</h2>
    You can add, update or remove a book author here. Any added book shall also be related to an author.<br />
    Please note that if you want to add one more author to a existing book, you can only input ISBN and Author ID.<br />
    <br />
    <asp:FormView ID="FormView1" runat="server" OnItemInserting="ItemInserting" DefaultMode="Insert">
        <InsertItemTemplate>
            <table class="InsertTable">
                <tr>
                    <th colspan="2">Add a record</th>
                </tr>
                <tr>
                    <td>ISBN</td>
                    <td>
                        <asp:TextBox ID="addISBN" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Title</td>
                    <td>
                        <asp:TextBox ID="addTitle" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Sign ID</td>
                    <td>
                        <asp:TextBox ID="addSignId" runat="server" onkeypress="return functionx(event)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Publication Year</td>
                    <td>
                        <asp:TextBox ID="addPublicationYear" runat="server" onkeypress="return functionx(event)"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Publication Info</td>
                    <td>
                        <asp:TextBox ID="addPublicationInfo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Pages</td>
                    <td>
                        <asp:TextBox ID="addPages" runat="server" onkeypress="return functionx(event)"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Author ID</td>
                    <td>
                        <asp:TextBox ID="addAid" runat="server" onkeypress="return functionx(event)"></asp:TextBox>
                    </td>
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
            <asp:TemplateField HeaderText="ISBN">
                <ItemTemplate>
                    <asp:Label ID="lblISBN" runat="server" Text='<%#Eval("ISBN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTitle" runat="server" Text='<%#Eval("Title") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sign ID">
                <ItemTemplate>
                    <asp:Label ID="lblSignId" runat="server" Text='<%#Eval("SignId") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSignId" runat="server" Text='<%#Eval("SignId") %>' onkeypress="return functionx(event)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publication Year">
                <ItemTemplate>
                    <asp:Label ID="lblPublicationYear" runat="server" Text='<%#Eval("PublicationYear") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPublicationYear" runat="server" Text='<%#Eval("PublicationYear") %>' onkeypress="return functionx(event)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publication Info">
                <ItemTemplate>
                    <asp:Label ID="lblPublicationInfo" runat="server" Text='<%#Eval("PublicationInfo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPublicationInfo" runat="server" Text='<%#Eval("PublicationInfo") %>' onkeypress="return functionx(event)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pages">
                <ItemTemplate>
                    <asp:Label ID="lblPages" runat="server" Text='<%#Eval("Pages") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPages" runat="server" Text='<%#Eval("Pages") %>' onkeypress="return functionx(event)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author ID">
                <ItemTemplate>
                    <asp:Label ID="lblAid" runat="server" Text='<%#Eval("Aid") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
