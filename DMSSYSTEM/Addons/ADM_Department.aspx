<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true" CodeFile="ADM_Department.aspx.cs" Inherits="Masterpages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>ADD NEW DEPARTMENT</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">ADD NEW DEPARTMENT</li>
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
                        <h3 class="card-title">Create Department
                        </h3>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
                        <form class="form-horizontal" id="form1">
                            <div class="card-body">
                                <div class="form-group row">
                                    <label for="inputEmail3" class="col-sm-2 col-form-label">Department Name</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtdepartmentName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Department Code</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtdepartmentCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-10">
                                    </div>
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="Save" runat="server" Text="Save" CssClass="btn btn-info" OnClick="Save_Click" />
                                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </form>


                    </div>

                </div>
            </div>
            <!-- /.col-->
        </div>
    </section>
</asp:Content>


