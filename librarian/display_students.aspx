<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="display_students.aspx.cs" Inherits="LibraryManagementSystem.librarian.display_student_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <link href="https://cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>

    <div class="container-fluid" style="background-color: white; padding: 20px">
        <asp:Repeater ID="r1" runat="server">



            <HeaderTemplate>
                <table class="table table-bordered" id="example">
                    <thead>
                        <tr>
                            <th scope="col">image</th>
                            <th scope="col">FirstName</th>
                            <th scope="col">LastName</th>
                            <th scope="col">Enrollment Num</th>
                            <th scope="col">Username</th>
                            <th scope="col">Email</th>
                            <th scope="col">Contact</th>
                            <th scope="col">Is approved</th>
                            <th scope="col">Activate</th>
                            <th scope="col">Deactivate</th>

                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <img src="../<%#Eval("student_img") %>" height="100" width="100" /></td>
                    <td><%#Eval("firstname") %></td>
                    <td><%#Eval("lastname") %></td>
                    <td><%#Eval("enrollment_num") %></td>
                    <td><%#Eval("username") %></td>
                    <td><%#Eval("email") %></td>
                    <td><%#Eval("contact") %></td>
                    <td><%#Eval("approved") %></td>
                    <td><a href="activate_student.aspx?id=<%#Eval("id") %>">Activate</a></td>
                    <td><a href="deactivate_student.aspx?id=<%#Eval("id") %>">Deactivate</a></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "pagingType": "full_numbers"
            });
        });


    </script>

</asp:Content>
