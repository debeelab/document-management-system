<%@ page title="" language="C#" masterpagefile="~/Masterpages/Admin.master" autoeventwireup="true" inherits="Masterpages_Default, App_Web_udy2jg3r" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>ADD NEW USER</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">ADD NEW USER</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>       
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
      <section class="content">
           <div class="row">
                <div class="col-md-12">
                    
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">
                                Create Users
                            </h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <form class="form-horizontal" id="form3">


                                <div class="form-group row">

                                    <label for="inputEmail3" class="col-sm-2 col-form-label">Staff ID</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtStaffID" runat="server" CssClass="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Role</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="drpRole" runat="server" CssClass="form-control" required>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Fullname</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtfullName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Password</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
                                    </div>


                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-10">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Department</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="drpDepartment" runat="server" CssClass="form-control" required>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="Save" runat="server" Text="Save" CssClass="btn btn-info" OnClick="Save_Click" />
                                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                                </div>

                            </form>

                        </div>

                    </div>
                </div>
                <!-- /.col-->
            </div>
      </section>
</asp:Content>


