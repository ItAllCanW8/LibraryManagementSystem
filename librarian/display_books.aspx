<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="display_books.aspx.cs" Inherits="LibraryManagementSystem.librarian.display_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Books</strong>
            </div>
            <div class="card-body">

                <asp:Repeater ID="r1" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th scope="col">image</th>
                                    <th scope="col">title</th>
                                    <th scope="col">pdf</th>
                                    <th scope="col">video</th>
                                    <th scope="col">author</th>
                                    <th scope="col">isbn</th>
                                    <th scope="col">available quantity</th>
                                    <th scope="col">Edit</th>
                                    <th scope="col">Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><img src="<%#Eval("book_image") %>" height="100" width="100" /></td>
                            <td><%#Eval("book_title") %></td>
                            <td><%#Eval("book_pdf") %> <br /> <%#checkPdf(Eval("book_pdf"), Eval("id")) %></td>
                            <td><%#Eval("book_video") %> <br /> <%#checkVideo(Eval("book_video"), Eval("id")) %></td>
                            <td><%#Eval("book_author_name") %></td>
                            <td><%#Eval("book_isbn") %></td>
                            <td><%#Eval("available_qty") %></td>
                            <td><a href="edit_books.aspx?id=<%#Eval("id") %>">Edit book</a></td>
                            <td><a href="delete_files.aspx?id2=<%#Eval("id") %>">Delete book</a></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>

                </asp:Repeater>

  
            </div>
        </div>
    </div>
</asp:Content>
