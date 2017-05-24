<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="borrower.aspx.cs" Inherits="Librarysystem.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Borrower administration - Library System</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Borrower administration</h2>
    You can add, update or remove a borrower in the system. You can also view a borrowers loans and renew any loan.
    <br />
    <br />
    <asp:FormView ID="FormView1" runat="server" OnItemInserting="ItemInserting" DefaultMode="Insert">
        <InsertItemTemplate>
            <table class="InsertTable">
                <tr>
                    <th colspan="2">Add a record</th>
                </tr>
                <tr>
                    <td>Person ID</td>
                    <td>
                        <asp:TextBox ID="addPersonId" runat="server"></asp:TextBox></td>
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
                    <td>Tel No</td>
                    <td>
                        <asp:TextBox ID="addTelNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="addAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Category</td>
                    <td>
                        <asp:DropDownList ID="addCategory" runat="server">
                            <asp:ListItem Value="1">Extern</asp:ListItem>
                            <asp:ListItem Value="2">Personal</asp:ListItem>
                            <asp:ListItem Value="3">Studerande</asp:ListItem>
                            <asp:ListItem Value="4">Barn</asp:ListItem>
                        </asp:DropDownList></td>
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
        OnRowEditing="RowEditing"
        OnRowCancelingEdit="RowCancelingEdit" OnRowUpdating="RowUpdating"
        AllowPaging="true" OnPageIndexChanging="PageIndexChanging"
        PagerStyle-CssClass="paging" CssClass="myGridStyle" DataKeyNames="UserId"
        OnRowDeleting="RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Person ID">
                <ItemTemplate>
                    <asp:Label ID="lblPersonId" runat="server" Text='<%#Eval("PersonId") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPersonId" runat="server" Text='<%#Eval("PersonId") %>'></asp:TextBox>
                </EditItemTemplate>
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
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tel. No">
                <ItemTemplate>
                    <asp:Label ID="lblTelNo" runat="server" Text='<%#Eval("TelNo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTelNo" runat="server" Text='<%#Eval("TelNo") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:DropDownList ID="lblCategory" runat="server" disabled="disabled" SelectedValue='<%#Eval("CategoryId") %>'>
                        <asp:ListItem Value="1">Extern</asp:ListItem>
                        <asp:ListItem Value="2">Personal</asp:ListItem>
                        <asp:ListItem Value="3">Studerande</asp:ListItem>
                        <asp:ListItem Value="4">Barn</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="txtCategory" runat="server" SelectedValue='<%#Eval("CategoryId") %>'>
                        <asp:ListItem Value="1">Extern</asp:ListItem>
                        <asp:ListItem Value="2">Personal</asp:ListItem>
                        <asp:ListItem Value="3">Studerande</asp:ListItem>
                        <asp:ListItem Value="4">Barn</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
            <asp:HyperLinkField Text="Loan"
                      DataNavigateUrlFormatString="~/borrower/books.aspx?adminedit=true&personid={0}"
                      DataNavigateUrlFields="PersonId" /> 
        </Columns>
    </asp:GridView>
</asp:Content>
