<%@ Page Language="C#" MasterPageFile="~/Masterpages/Secretary.master" AutoEventWireup="true" CodeFile="Dispatch.aspx.cs" Inherits="Masterpages_Default" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/Masterpages/Secretary.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>
</asp:Content>    

<asp:Content ID="Content1" runat="server" contentplaceholderid="TopContent">
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Create Dispatch File / Record</h1>
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
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
     <!-- Content Header (Page header) -->
    

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
          <asp:Panel ID="pnlCreatefile" runat="server" Visible="false">
              <div class="row">
                  <!-- /.col -->
                  <div class="col-md-12">
                      <div class="card card-dark">
                          <div class="card-header">
                              <h3 class="card-title">File Name,File Number, Subject, Dispatcher and Remarks</h3>
                              
                          </div>
                          <!-- /.card-header -->
                          <div class="card-body">
                              <div class="form-group" style="text-align:center">
                                  <h2>
                                      <small>
                                          <asp:Label ID="lbldispatchType" runat="server" Visible="False"></asp:Label>

                                      </small>

                                  </h2>
                              </div>



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
                                              <asp:DropDownList ID="drpPriority" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpDept_SelectedIndexChanged"></asp:DropDownList>
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <div class="col-sm-10">
                                              <asp:TextBox ID="txtfileName" runat="server" class="form-control" placeholder="File name"></asp:TextBox>
                                          </div>
                                      </div>
                                  </div>
                                  <div class="col-md-6">
                                      
                                      <div class="form-group">
                                          <label>Submitter/Dispatcher Name</label>
                                          <div class="col-sm-10">
                                              <asp:DropDownList ID="drpReceiver" runat="server" CssClass="form-control"></asp:DropDownList>
                                          </div>
                                      </div>

                                      <div class="form-group">
                                          <label>File No</label>
                                          <div class="col-sm-10">
                                              <asp:TextBox ID="txtfileno" CssClass="form-control" placeholder="File No" runat="server"></asp:TextBox>

                                          </div>

                                      </div>
                                      <div class="form-group">
                                          <div class="col-sm-10">
                                              <asp:TextBox ID="txtsubject" class="form-control" placeholder="Subject" runat="server"></asp:TextBox>

                                          </div>
                                          

                                      </div>

                                  </div>
                              </div>

                             
                                <div class="form-group">
                                    <label for="message">
                                        Description
                                        <span class="text-danger">*</span>

                                    </label>
                                    <textarea id="txtdescription" class="summernote form-control" runat="server"></textarea>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDispatcherName" runat="server" class="form-control" placeholder="Receiver Name"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtremark" class="form-control" placeholder="Remarks" runat="server"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group row">
                                  <label for="message" class="col-sm-2 col-form-label">
                                       Attachment
                                      <span class="text-danger"><i class="fa fa-paperclip"></i></span>

                                   </label>
                                    <div class="col-sm-10"><asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control" />

                                     <asp:Label ID="label1" runat="server" Text="Label" Visible="False"></asp:Label>

                                     <asp:TextBox ID="txtUpdfileName" runat="server" Visible="false"></asp:TextBox>
                                 </div>

                             </div>

                          </div>
                          <div class="card-footer">
                                <div class="float-right">
                                    <button type="reset" class="btn btn-default"><i class="fas fa-times"></i> Discard</button>
                                </div>
                                <button type="submit" id="btnsubmit" class="btn btn-primary" runat="server" onserverclick="btnsubmit_ServerClick"><i class="far fa-envelope"></i> Send</button>
                                
                            </div>
                      </div>
                  </div>

              </div>

          </asp:Panel>

           <asp:Panel ID="pnlVirtualshelf" runat="server" Visible="false">
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
                                    <asp:TemplateField HeaderText="Receiver">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreceiver" runat="server" Text='<%# Eval("Sender") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dispacher Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreceiver" runat="server" Text='<%# Eval("Receiver") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created By" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreatedby" runat="server" Text='<%# Eval("CreatedBy") %>' Format="MMMM d, yyyy"></asp:Label>
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
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("FILEID") %>' CommandName="Edit" CssClass="btn btn-primary"><span class="glyphicon glyphicon-pencil">&nbsp;Edit</span></asp:LinkButton>

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
      </div>

    </section>
     
</asp:Content>



       

