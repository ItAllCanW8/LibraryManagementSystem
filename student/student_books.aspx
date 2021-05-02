<%@ Page Title="" Language="C#" MasterPageFile="~/student/student.Master" AutoEventWireup="true" CodeBehind="student_books.aspx.cs" Inherits="LibraryManagementSystem.student.student_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>My Books</h1>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid" style="min-height:500px; background-color:white">
        <asp:DataList ID="d1" runat="server">

            <HeaderTemplate>
                        <table class="table table-bordered">
                            <tr>
                                <th>student_enroll_num</th>
                                <th>book_isbn</th>
                                <th>book_issue_date</th>
                                <th>book_approx_return_date</th>
                                <th>student_username</th>
                                <th>is_book_returned</th>
                                <th>book_return_date</th>
                                <th>delay_for_days</th>
                                <th>penalty for delay($)</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                           <tr>
                               <td><%#Eval("student_enroll_num") %></td>
                               <td><%#Eval("book_isbn") %></td>
                               <td><%#Eval("book_issue_date") %></td>
                               <td><%#Eval("book_approx_return_date") %></td>
                               <td><%#Eval("student_username") %></td>
                               <td><%#Eval("is_book_returned") %></td>
                               <td><%#Eval("book_return_date") %></td>
                               <td><%#Eval("delay_for_days") %></td>
                               <th><%#Eval("penalty") %></th>
                           </tr>
                    </ItemTemplate>

                    <FooterTemplate>

                    </table>
                    </FooterTemplate>

        </asp:DataList>
    </div>
</asp:Content>
