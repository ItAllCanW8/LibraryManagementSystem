<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="edit_books.aspx.cs" Inherits="LibraryManagementSystem.librarian.edit_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Edit Book</strong>
            </div>
            <div class="card-body">
                <!-- Credit Card -->
                <div id="pay-invoice">
                    <div class="card-body">

                        <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Title</label>
                                <asp:TextBox ID="title" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Image</label><br />
                                <asp:Label ID="image" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="f1" runat="server" class="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Pdf</label> <br />
                                <asp:Label ID="pdf" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="f2" runat="server" class="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Video</label><br />
                                <asp:Label ID="video" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="f3" runat="server" class="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Author</label>
                                <asp:TextBox ID="author" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Isbn</label>
                                <asp:TextBox ID="isbn" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Quantity</label>
                                <asp:TextBox ID="quantity" runat="server" class="form-control"></asp:TextBox>
                            </div>


                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Edit Book" OnClick="b1_Click"/>
                            </div>

                        </form>
                    </div>
                </div>

            </div>
        </div>
        <!-- .card -->

    </div>
    <!--/.col-->
</asp:Content>
