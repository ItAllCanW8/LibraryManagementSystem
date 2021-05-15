<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="logging.aspx.cs" Inherits="LibraryManagementSystem.librarian.logging" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Logging</h1>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid" style="min-height:500px; background-color:white">
        <asp:DataList ID="d1" runat="server">

            <HeaderTemplate>
                        <table class="table table-bordered">
                            <tr>
                                <th>username</th>
                                <th>event</th>
                                <th>date_time</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                           <tr>
                               <td><%#Eval("username") %></td>
                               <td><%#Eval("event") %></td>
                               <td><%#Eval("date_time") %></td>
                           </tr>
                    </ItemTemplate>

                    <FooterTemplate>

                    </table>
                    </FooterTemplate>

        </asp:DataList>
    </div>
</asp:Content>

