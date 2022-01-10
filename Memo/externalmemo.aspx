<%@ page title="" language="C#" masterpagefile="~/Masterpages/Directors.master" autoeventwireup="true" inherits="Masterpages_Default, App_Web_mb0ix2u4" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>EXTERNAL MEMO</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="../Homepage/DirectorHome.aspx">Home</a></li>
                        <li class="breadcrumb-item active">INTER MEMO</li>
                    </ol>
                </div>
            </div>
            <div class="row mb-2">
            </div>

        </div>
        <!-- /.row -->

        <!-- /.container-fluid -->
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <section class="content">
         <div class="row">
             <div class="col-md-12">
                 <div class="card card-dark">
                     <div class="card-header">
                         <h3 class="card-title">Create New Memo</h3>
                     </div>
                     <!-- /.card-header -->
                     <!-- form start -->
                     <form class="form-horizontal" id="form1" method="post">
                         <div class="card-body">
                             <div class="row">
                                  <div class="col-md-6">
                                      <div class="form-group">
                                          <label>Subject</label>
                                          <div class="col-sm-10">
                                              <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Subject" required></asp:TextBox>
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <label for="inputPassword2" class="col-sm-2 col-form-label">Company</label>
                                          <div class="col-sm-10">
                                              <asp:DropDownList ID="drpDepartmentToID" runat="server" AutoPostBack="true" CssClass="form-control">
                                              </asp:DropDownList>
                                          </div>
                                      </div>
                                  </div>
                                  <div class="col-md-6">
                                      <div class="form-group">
                                          <div class="col-sm-10">
                                              <label>Document Type</label>
                                              <asp:TextBox ID="txtdoctype" CssClass="form-control" placeholder="Document Type" runat="server"></asp:TextBox>

                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <label for="inputPassword3" class="col-sm-2 col-form-label">Priority</label>
                                          <div class="col-sm-10">
                                              <asp:DropDownList ID="drpPriority" runat="server" CssClass="form-control"></asp:DropDownList>
                                          </div>
                                      </div>

                                  </div>
                              </div>
                             
                                 <div class="form-group row">
                                 <label for="inputPassword4" class="col-form-label"> &nbsp; &nbsp; Body</label>
                                 <div class="col-sm-12">
                                     <textarea id="txtmemobody" name="memobody" cols="20" rows="2" class="summernote form-control" runat="server"></textarea>

                                 </div>
                             </div>
                             
                             
                             
                             <div class="form-group row">
                                 <%--<label for="inputPassword3" >Upload</label>--%>
                                  <label for="message" class="col-sm-2 col-form-label">
                                       Attachment
                                     <span class="text-danger"><i class="fa fa-paperclip"></i></span>

                                   </label>
                                 <div class="col-sm-10">

                                     <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control" />

                                     <asp:Label ID="label1" runat="server" Text="Label" Visible="False"></asp:Label>

                                     <asp:TextBox ID="txtfileName" runat="server" Visible="false"></asp:TextBox>
                                     <p class="help-block"><b>File Type:</b> jpg,jpeg,png,gif,pdf,doc,docx,xls,xlsx | <b>Max file size:</b> 5MB</p>

                                 </div>

                             </div>

                             <div class="form-group row">
                                 <div class="offset-sm-2 col-sm-10">
                                 </div>
                             </div>

                             <div class="card-footer">
                                 <asp:Button ID="Save" runat="server" Text="Send" CssClass="btn btn-danger btn-lg" OnClick="Save_Click" OnClientClick="Getmemobody();" />
                                 <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" ConfirmOnFormSubmit="true" ConfirmText="Are you sure want to save this record" TargetControlID="save" runat="server" />
                                 <%--<asp:Label ID="result" runat="server" Text="Show result" ></asp:Label>--%>
                             </div>
                         </div>
                     </form>

                 </div>
             </div>
         </div>
    </section>
    <script type="text/javascript">
        function Getmemobody() {
            debugger;
            document.getElementById("#<%=txtmemobody.ClientID%>").value = $('#<%=txtmemobody.ClientID%>').summernote('code');
         }
    </script>
</asp:Content>

