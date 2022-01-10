<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Secretary.master" AutoEventWireup="true" CodeFile="Dispatched.aspx.cs" Inherits="Masterpages_Default" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/Masterpages/Secretary.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%-- <link href="../dist/css/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />--%>
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>

     <script src=" https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.jssrc"></script>
 <script src="https://cdn.datatables.net/buttons/1.6.4/js/dataTables.buttons.min.jssrc"></script>
 <script src="://cdn.datatables.net/buttons/1.6.4/js/buttons.colVis.min.jssrc" ></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Dispatch File / Record</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Dispatch File / Record</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
            <!-- SELECT2 EXAMPLE -->
          <asp:Panel ID="pnlDispatch" runat="server">
              <div class="row">
              <div class="col-md-12">
                  <div class="card card-dark">
                      <div class="card-header">
                          <h3 class="card-title">Dispatch File Record</h3>

                          <div class="card-tools">
                              <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                              <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
                          </div>
                      </div>
                      <!-- /.card-header -->
                      <div class="card-body">

                          
                      </div>
                  </div>
              </div>
          </div><!-- /.row -->

          </asp:Panel>
          
        
          
          <!-- /.row -->
          <asp:Panel ID="pnlCreatefile" runat="server">
              <div class="row">
                    <!-- /.col -->
                    <div class="col-md-12">
                        <div class="card card-dark">
                            <div class="card-header">
                                <h3 class="card-title">File Name,File Number, Subject, Dispatcher and Remarks</h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Select Department</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="drpDept" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpDept_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label>Priority</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="drpPriority" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Send To</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="drpReceiver" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>File No</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtfileno" class="form-control" placeholder="File No" runat="server"></asp:TextBox>

                                            </div>


                                        </div>

                                    </div>

                                </div>
                                
                                <div class="form-group">
                                    <asp:TextBox ID="txtfileName" runat="server" class="form-control" placeholder="File name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtsubject" class="form-control" placeholder="Subject" runat="server"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label for="message">
                                        Description
                                        <span class="text-danger">*</span>

                                    </label>
                                    <textarea id="txtdescription" class="summernote form-control" runat="server"></textarea>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDispatcherName" runat="server" class="form-control" placeholder="Dispatcher Name"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtremark" class="form-control" placeholder="Remarks" runat="server"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group row">
                                  <label for="message" class="col-sm-2 col-form-label">
                                       Attachment
                                     <span class="text-danger"><i class="fa fa-paperclip"></i></span>

                                   </label>
                                 <div class="col-sm-10">

                                     <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control" />

                                     <asp:Label ID="label1" runat="server" Text="Label" Visible="False"></asp:Label>

                                     <asp:TextBox ID="txtUpdfileName" runat="server" Visible="false"></asp:TextBox>
                                 </div>

                             </div>
                            </div>
                            <!-- /.card-body -->
                            <div class="card-footer">
                                <div class="float-right">
                                    <button type="reset" class="btn btn-default"><i class="fas fa-times"></i> Discard</button>
                                </div>
<%--                                <button type="submit" id="btnsubmit" class="btn btn-primary" runat="server" onserverclick="btnsubmit_ServerClick"><i class="far fa-envelope"></i> Send</button>
                                --%>
                            </div>
                            <!-- /.card-footer -->
                        </div>
                        <!-- /.card -->
                    </div>
                    <!-- /.col -->

                </div><!-- /.row -->

          </asp:Panel>
         
           

          <asp:Panel ID="pnlTrackfile" runat="server">
              <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">TRACK FILE</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>

            </div>
          </asp:Panel>

          <asp:Panel ID="pnlVirtualshelf" runat="server">
              <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">VIRTUAL SHELF</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvvirtual" runat="server" AutoGenerateColumns="false" 
                                class="table table-bordered table-striped table-responsive">
                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfilen" runat="server" Text='<%# Eval("Fileno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfilename" runat="server" Text='<%# Eval("Filename") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("FILESUBJECT") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("FileDescription") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartfrom" runat="server" Text='<%# Eval("DepartmentfromId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpriority" runat="server" Text='<%# Eval("FilePriority") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsender" runat="server" Text='<%# Eval("Sender") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created By" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreatedby" runat="server" Text='<%# Eval("CreatedBy") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receiver">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreceiver" runat="server" Text='<%# Eval("Receiver") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldatecreated" runat="server" Text='<%# Eval("DateCreated") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Upload">
                                        <ItemTemplate>
                                            <asp:Label ID="lblupdpathe" runat="server" Text='<%# Eval("UploadPath") %>' Format="MMMM d, yyyy"><span class="glyphicon glyphicon-folder"></span></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("FILEID") %>' CommandName="Edit" class="btn btn-primary btn-xs"><span class="glyphicon glyphicon-pencil">&nbsp;Edit</span></asp:LinkButton>

                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("FILEID") %>' CommandName="Delete"><span class="glyphicon glyphicon-trash">&nbsp;Delete</span></asp:LinkButton>
                                          

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>

            </div>
          </asp:Panel>
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
 <%--   <script>
        $(function () {
            //Add text editor
            $('#<%=txtcomposed.ClientID%>').summernote()
    })
</script>--%>
<script type="text/javascript">
    function GetSubject() {
        ebugger;
        document.getElementById("#<%=txtsubject.ClientID%>").value = $('#<%=txtsubject.ClientID%>').summernote('code');
    }
</script>
 <script>
         $(document).ready(function () {
             $('#<%= gvvirtual.ClientID%>').prepend($("<thead></thead>").append($("#<%=gvvirtual.ClientID%>").find("tr:first"))).DataTable({
                 dom: 'Bfrtip', 
                 stateSave: true,
                 responsive: true,

                 //"paging": true,
                 //"lengthChange": true,
                 //"searching": true,
                 //"ordering": true,
                 //"info": true,
                 //"autoWidth": true,

                 //columnDefs: [{
                 //    targets: [0],
                 //    orderData: [0, 1]
                 //}, {
                 //    targets: [1],
                 //    orderData: [1, 0]
                 //}, {
                 //    targets: [4],
                 //    orderData: [4, 0]
                 //}],

                 //buttons: [
                 //    {
                 //        extend: 'colvis',
                 //        collectionLayout: 'fixed two-column'
                 //    }
                 //]

                
             });
         });
    </script>
 
</asp:Content>

