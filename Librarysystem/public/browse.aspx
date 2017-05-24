<%@ Page Title="" Language="C#" MasterPageFile="../LibMaster.Master" AutoEventWireup="true" CodeBehind="browse.aspx.cs" Inherits="Librarysystem.public_browse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Browse by <% if (browse == "book")
                     { %>book title<% }
                     else if (browse == "author")
                     {%>author name<% } %> - Library System</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Browse by <% if (browse == "book")
                     { %>book title<% }
                     else if (browse == "author")
                     {%>author name<% } %></h2>
    You can browse the books by book title or author name.<br />
    <br />
    <% if (browse == "book")
       { %>
    <div class="browseby">
        <span>Book Title</span>
        <a href="./browse.aspx?browse=author">Author Name</a>
    </div>
    <br />
    <div class="paging">
        <% if (index == "A")
           { %><span>A</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=A">A</a><% } %>
        <% if (index == "B")
           { %><span>B</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=B">B</a><% } %>
        <% if (index == "C")
           { %><span>C</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=C">C</a><% } %>
        <% if (index == "D")
           { %><span>D</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=D">D</a><% } %>
        <% if (index == "E")
           { %><span>E</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=E">E</a><% } %>
        <% if (index == "F")
           { %><span>F</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=F">F</a><% } %>
        <% if (index == "G")
           { %><span>G</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=G">G</a><% } %>
        <% if (index == "H")
           { %><span>H</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=H">H</a><% } %>
        <% if (index == "I")
           { %><span>I</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=I">I</a><% } %>
        <% if (index == "J")
           { %><span>J</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=J">J</a><% } %>
        <% if (index == "K")
           { %><span>K</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=K">K</a><% } %>
        <% if (index == "L")
           { %><span>L</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=L">L</a><% } %>
        <% if (index == "M")
           { %><span>M</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=M">M</a><% } %>
        <% if (index == "O")
           { %><span>O</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=O">O</a><% } %>
        <% if (index == "P")
           { %><span>P</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=P">P</a><% } %>
        <% if (index == "Q")
           { %><span>Q</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=Q">Q</a><% } %>
        <% if (index == "R")
           { %><span>R</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=R">R</a><% } %>
        <% if (index == "S")
           { %><span>S</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=S">S</a><% } %>
        <% if (index == "T")
           { %><span>T</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=T">T</a><% } %>
        <% if (index == "U")
           { %><span>U</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=U">U</a><% } %>
        <% if (index == "V")
           { %><span>V</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=V">V</a><% } %>
        <% if (index == "W")
           { %><span>W</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=W">W</a><% } %>
        <% if (index == "X")
           { %><span>X</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=X">X</a><% } %>
        <% if (index == "Y")
           { %><span>Y</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=Y">Y</a><% } %>
        <% if (index == "Z")
           { %><span>Z</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=Z">Z</a><% } %>
        <% if (index == "[0-9]%")
           { %><span>Numbers</span><% }
           else
           {%><a href="./browse.aspx?browse=book&index=[0-9]%">Numbers</a><% } %>
    </div>
    <% } %>
    <% if (browse == "author")
       { %>
    <div class="browseby">
        <a href="./browse.aspx?browse=book">Book Title</a>
        <span>Author Name</span>
    </div>
    <br />
    <div class="paging">
        <% if (index == "A")
           { %><span>A</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=A">A</a><% } %>
        <% if (index == "B")
           { %><span>B</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=B">B</a><% } %>
        <% if (index == "C")
           { %><span>C</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=C">C</a><% } %>
        <% if (index == "D")
           { %><span>D</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=D">D</a><% } %>
        <% if (index == "E")
           { %><span>E</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=E">E</a><% } %>
        <% if (index == "F")
           { %><span>F</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=F">F</a><% } %>
        <% if (index == "G")
           { %><span>G</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=G">G</a><% } %>
        <% if (index == "H")
           { %><span>H</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=H">H</a><% } %>
        <% if (index == "I")
           { %><span>I</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=I">I</a><% } %>
        <% if (index == "J")
           { %><span>J</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=J">J</a><% } %>
        <% if (index == "K")
           { %><span>K</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=K">K</a><% } %>
        <% if (index == "L")
           { %><span>L</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=L">L</a><% } %>
        <% if (index == "M")
           { %><span>M</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=M">M</a><% } %>
        <% if (index == "O")
           { %><span>O</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=O">O</a><% } %>
        <% if (index == "P")
           { %><span>P</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=P">P</a><% } %>
        <% if (index == "Q")
           { %><span>Q</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=Q">Q</a><% } %>
        <% if (index == "R")
           { %><span>R</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=R">R</a><% } %>
        <% if (index == "S")
           { %><span>S</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=S">S</a><% } %>
        <% if (index == "T")
           { %><span>T</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=T">T</a><% } %>
        <% if (index == "U")
           { %><span>U</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=U">U</a><% } %>
        <% if (index == "V")
           { %><span>V</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=V">V</a><% } %>
        <% if (index == "W")
           { %><span>W</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=W">W</a><% } %>
        <% if (index == "X")
           { %><span>X</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=X">X</a><% } %>
        <% if (index == "Y")
           { %><span>Y</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=Y">Y</a><% } %>
        <% if (index == "Z")
           { %><span>Z</span><% }
           else
           {%><a href="./browse.aspx?browse=author&index=Z">Z</a><% } %>
    </div>
    <% } %>
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
                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Details" Text="Details"
                DataNavigateUrlFormatString="~/public/bookdetails.aspx?ISBN={0}"
                DataNavigateUrlFields="ISBN" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Aid"
        OnPageIndexChanging="PageIndexChanging2" AllowPaging="true"
        ShowHeaderWhenEmpty="True" EmptyDataText="No records found. Please check your input."
        PagerStyle-CssClass="paging" CssClass="myGridStyle">
        <Columns>
            <asp:TemplateField HeaderText="Aid">
                <ItemTemplate>
                    <asp:Label ID="lblAid" runat="server" Text='<%#Eval("Aid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Details" Text="Details"
                DataNavigateUrlFormatString="~/public/search.aspx?browse=author&q={0}"
                DataNavigateUrlFields="Name" />
        </Columns>
    </asp:GridView>
</asp:Content>
