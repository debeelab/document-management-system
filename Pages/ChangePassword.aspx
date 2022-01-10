<%@ page title="" language="C#" masterpagefile="~/Masterpages/Directors.master" autoeventwireup="true" inherits="Masterpages_Default, App_Web_eth4qio2" %>
<%@ MasterType VirtualPath="~/Masterpages/Directors.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .content 
        {
            margin: auto 50px;
        }
        .field-validation-error
        {
            color: #E80C4D;
            font-weight: bold;
            font-size: 17px;
        }
    </style>
  <%--  <link href="../dist/css/StyleSheet.css" rel="stylesheet" />
    <link href="../dist/css/components.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server" class="form-horizontal">
      <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <!-- left column -->
          <div class="col-md-12">
            
            <!-- Horizontal Form -->
            <div class="card card-info">
              <div class="card-header">
                <h3 class="card-title" style="color:#e7505a!important;">Change Password</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form class="form-horizontal">
                <div class="card-body">
                  <div class="form-group row">
                    <label for="inputEmail3" class="col-sm-2 col-form-label">Old Password</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtoldpwd" runat="server" class="form-control" placeholder="Old Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_oldpwd" runat="server" ErrorMessage="* Required" 
                            ControlToValidate="txtoldpwd" CssClass="field-validation-error" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">New Password</label>
                    <div class="col-md-4">
                      <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvnewpwd" runat="server" ErrorMessage="* Required" ControlToValidate="txtNewPassword" 
                            CssClass="field-validation-error" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Confirm New Password</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtConfirmNewPassword" runat="server" class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvconfirmnewpwd" runat="server" ErrorMessage="* Required" 
                            CssClass="field-validation-error" ControlToValidate="txtConfirmNewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                      
                    </div>
                  </div>
                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info" OnClick="btnSubmit_Click"/>
                  <button type="submit" class="btn btn-default float-right">Cancel</button>
                </div>
                <!-- /.card-footer -->
              </form>
            </div>
            <!-- /.card -->

          </div>
        </div>
        <!-- /.row -->
      </div>
        <!-- /.container-fluid -->
    </section>
</asp:Content>

