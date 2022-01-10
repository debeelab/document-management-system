<%@ page title="" language="C#" masterpagefile="~/Masterpages/Directors.master" autoeventwireup="true" inherits="Masterpages_Default, App_Web_yciumzpf" validaterequest="false" %>


<%@ MasterType VirtualPath="~/Masterpages/Directors.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <%--<link href="../dist/css/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
         <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>  --%>
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <style type="text/css">
        body,
        h1,
        h2,
        h3,
        h4,
        h5,
        h6 {
            font-family: "Open Sans", sans-serif;
        }
        /*.modal-content {
        background-color: #fefefe;
        margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered *
  border: 1px solid #888;
  width: 80%; /* Could be more or less, depending on screen size *

    }*/
        .alert-primary {
            color: #004085 !important;
            background-color: #cce5ff !important;
            border-color: #b8daff !important;
        }

            .alert-primary hr {
                border-top-color: #9fcdff;
            }

            .alert-primary .alert-link {
                color: #002752 !important;
            }

        .alert-secondary {
            color: #383d41 !important;
            background-color: #e2e3e5 !important;
            border-color: #d6d8db !important;
        }

            .alert-secondary hr {
                border-top-color: #c8cbcf !important;
            }

            .alert-secondary .alert-link {
                color: #202326 !important;
            }

        .alert-success {
            color: #155724 !important;
            background-color: #d4edda !important;
            border-color: #c3e6cb !important;
        }

            .alert-success hr {
                border-top-color: #b1dfbb !important;
            }

            .alert-success .alert-link {
                color: #0b2e13 !important;
            }

        .alert-info {
            color: #0c5460 !important;
            background-color: #d1ecf1 !important;
            border-color: #bee5eb !important;
        }

            .alert-info hr {
                border-top-color: #abdde5 !important;
            }

            .alert-info .alert-link {
                color: #062c33 !important;
            }

        .alert-warning {
            color: #856404 !important;
            background-color: #fff3cd !important;
            border-color: #ffeeba !important;
        }

            .alert-warning hr {
                border-top-color: #ffe8a1 !important;
            }

            .alert-warning .alert-link {
                color: #533f03 !important;
            }

        .alert-danger {
            color: #721c24 !important;
            background-color: #f8d7da !important;
            border-color: #f5c6cb !important;
        }

            .alert-danger hr {
                border-top-color: #f1b0b7 !important;
            }

            .alert-danger .alert-link {
                color: #491217 !important;
            }

        .alert-light {
            color: #818182 !important;
            background-color: #fefefe !important;
            border-color: #fdfdfe !important;
        }

            .alert-light hr {
                border-top-color: #ececf6 !important;
            }

            .alert-light .alert-link {
                color: #686868 !important;
            }

        .alert-dark {
            color: #1b1e21 !important;
            background-color: #d6d8d9 !important;
            border-color: #c6c8ca !important;
        }

            .alert-dark hr {
                border-top-color: #b9bbbe !important;
            }

            .alert-dark .alert-link {
                color: #040505 !important;
            }

        .note-editor.note-frame {
            border: none !important;
        }

        .err-msg {
            font-weight: 400;
            color: #a90000;
            font-size: 13px;
        }
        .table:not(.table-dark) {
            color: #000;
        }
        .modal-body p {
            color: #000;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Incoming Memo</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Incoming Memo</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <section class="content">
        
        <asp:Panel ID="Pnldisplay" runat="server" >
            <div class="row">
                <div class="col-md-12">
                    
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">
                                Reply to Memo &nbsp; 
                                <asp:Label ID="lblmemoid" runat="server" Text="Label"></asp:Label>
                            </h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <table class="table">
                                        <tr>
                                           <td>
                                                
                                                <div class="form-group row">
                                                    <label for="inputEmail3" class="col-sm-2 col-form-label">Subject</label>
                                                  <div class="col-sm-10">
                                                        <asp:Label ID="lblSubject" runat="server"></asp:Label>
                                                        <%--<asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group row">

                                                    <label for="inputEmail3" class="col-sm-2 col-form-label">Type</label>
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="txtdocType" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group row">
                                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Status</label>
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblUntreated" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-danger" />
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                    </table>
                                    
                                    
                                    


                            </div>
                                <div class="col-md-6">
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <div class="form-group row">

                                                    <label for="inputEmail3" class="col-sm-2 col-form-label">From</label>
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblFrom" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group row">

                                                    <label for="inputEmail3" class="col-sm-2 col-form-label">To</label>
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblDeptTo" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group row">

                                                    <label for="inputEmail3" class="col-sm-2 col-form-label">Priority</label>
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblPriority" runat="server" CssClass="badge badge-warning"></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                
                                

                                

                            </div>

                            </div>
                            <div class="row">
                                  <div class="col-md-12 text-center">
                                      <%-- <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" class="btn btn-success-close" data-toggle="modal" data-target="#modal-primary" />--%>
                                      <button type="button" class="btn btn-success-close" data-toggle="modal" data-target="#modal-primary">Close</button>
                                      <asp:LinkButton ID="lnkbtnReject" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Reject" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#modal-primary1">
                                          <i class="fas fa-trash"></i> Reject
                                      </asp:LinkButton>
                                  </div>


                            </div>
                        </div>

                    </div>
                </div>
                <!-- /.col-->
            </div>

        </asp:Panel>

        <!-- ./row -->

        <!-- Timelime example  -->

        <asp:Panel ID="pnlTimeline" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <!-- The time line -->
                    <div class="timeline timeline-inverse">
                        <div id="divsent" runat="server">
                            <i class="fa fa-send bg-dark"></i>
                            <div class="timeline-item">
                                <span class="time"><i class="fas fa-clock"></i>
                                    <asp:Label ID="lblDateCreated" runat="server" Text='<%#Eval("DateCreated")%>'></asp:Label></span>
                                <h3 class="timeline-header"><a href="#">
                                    <asp:Label ID="lblSender" runat="server" Text='<%#Eval("DepartmentfromID")%>'></asp:Label></a> sent you a memo</h3>

                                <div class="timeline-body" runat="server">
                                    <p id="psender" runat="server" innertext='<%#Eval("MemoBody")%>'></p>

                                </div>

                                <div class="timeline-footer" id="footerdownload" runat="server">
                                    <asp:LinkButton ID="lnkbtndwnpath" runat="server" class="text-danger" Text='<%# Eval("UploadPath")  %>' OnClick="lnkbtndwnpath_Click" CommandArgument='<%#Eval("MemoID")%>'>
                                       <i class="fa fa-paperclip">
                                        </i> Download Attachment</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <asp:Repeater ID="rpMessages" runat="server" OnItemDataBound="rpMessages_ItemDataBound">
                            <ItemTemplate>
                                <div id="divreplied" runat="server">
                                    <i class="fa fa-reply bg-success-close"></i>
                                    <div class="timeline-item">
                                        <span class="time"><i class="fas fa-clock"></i>
                                            <asp:Label ID="lblDateTreated" runat="server" Text='<%#Eval("DateTreated")%>'></asp:Label></span>
                                        <h3 class="timeline-header"><a href="#">
                                            <asp:Label ID="lblreplied" runat="server" Text='<%#Eval("SentBy")%>'></asp:Label></a> Replied</h3>

                                        <div class="timeline-body">
                                            <p id="preplied" runat="server" innerhtml='<%#Eval("RepliedMessage")%>'></p>

                                        </div>
                                        <div class="timeline-footer">
                                            <asp:LinkButton ID="lnkgetdownloadreplied" runat="server" class="text-danger" Text='<%#DataBinder.Eval(Container.DataItem, "Fileupdpath")  %>' OnClick="lnkgetdownloadreplied_Click">
                                                        <i class="fa fa-paperclip"></i> Download Attachment
                                            </asp:LinkButton>
                                            <%--<asp:LinkButton ID="lnkgetdownloadreplied" runat="server" class="text-danger" Text='<%# Eval("Uploadpath")  %>' OnClick="lnkgetdownloadreplied_Click" CommandArgument='<%#Eval("MemoID")%>'>
                                                        <i class="fa fa-paperclip"></i> Download Attachment</asp:LinkButton>--%>
                                        </div>
                                    </div>

                                </div>



                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- timeline item -->
                        <div>
                            <i class="fa fa-send bg-dark"></i>
                            <div class="timeline-item">
                                <span class="time"><i class="fas fa-clock"></i><%: DateTime.Now %> </span>
                                <h3 class="timeline-header"><a href="#">Reply</a></h3>
                                <div class="timeline-body">
                                    <div class="mb-3">
                                        <label for="message">
                                            Message
                                                     <span class="text-danger">*</span>

                                        </label>
                                        <%--<asp:TextBox ID="TextBox1" runat="server" class="summernote" ></asp:TextBox>--%>
                                   <%-- <textarea id="txtreplymemo" class="summernote" runat="server" required="required"></textarea>--%>

                                    </div>
                                    <div class="form-group">
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
                                </div>
                                <div class="timeline-footer">
                                    
                                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" class="btn btn-danger btn-lg"/>
                                    
                                </div>
                            </div>
                        </div>
                        <div>
                            <i class="fas fa-clock bg-gray"></i>
                        </div>
                    </div>

                      
                   

                       
                </div>
                <!-- /.col -->
            </div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </asp:Panel>

        <asp:Panel ID="PnlvwAllMemo" runat="server">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">TREATED & UNTREATED MEMO</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvassignedmemo" runat="server" AutoGenerateColumns="false" 
                                CssClass="table table-bordered table-striped table-responsive" OnRowCommand="gvassignedmemo_RowCommand"
                                 OnRowEditing="gvassignedmemo_RowEditing" ClientIDMode="Static" OnRowDataBound="gvassignedmemo_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblmemoid" runat="server" Text='<%# Eval("MemoID") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="btnEdit" runat="server" Text='<%# Eval("MemoID") %>' CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit"></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                            <p>
                                                <span class="text-success">
                                                    <i class="fa fa-comment"></i> <asp:Label ID="lblreadmssg" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                </span> &nbsp;&nbsp;
                                                <span class="text-danger">
                                                    <%--<i class="fa fa-paperclip" ></i>
                                                    <label id="vwallattachment" runat="server" text='<%# Eval("UploadPath")  %>'/>--%>
                                                    
                                                    <asp:Label ID="lblvwalldwnpath" runat="server" Text='<%# Eval("UploadPath")  %>' class="fa fa-paperclip">

                                                    </asp:Label>

                                                </span>

                                            </p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartfrom" runat="server" Text='<%# Eval("From") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("To") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("Document") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <%--  <asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsender" runat="server" Text='<%# Eval("Sentby") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwAllstatus" runat="server" Text='<%# Eval("Status") %>' CssClass="badge badge-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvwAllPriority" runat="server" Text='<%# Eval("Priority") %>' CssClass="badge badge-warning"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbntvwallreply" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit" class="btn btn-primary btn-sm">
                                                <i class="fas fa-folder"></i> View
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkbtnvwallReject" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Reject" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#modal-primary1">
                                                <i class="fas fa-trash"></i> Reject
                                            </asp:LinkButton>
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

        <asp:Panel ID="PnlTreated" runat="server">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">TREATED MEMO</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvwTreated" runat="server" AutoGenerateColumns="false" 
                                CssClass="table table-bordered table-striped table-responsive" OnRowCommand="gvassignedmemo_RowCommand" 
                                OnRowDataBound="gvwTreated_RowDataBound"
                                OnRowEditing="gvassignedmemo_RowEditing" ClientIDMode="Static">
                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblmemoid" runat="server" Text='<%# Eval("MemoID") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="lblTreated" runat="server" Text='<%# Eval("MemoID") %>' CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit"></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                              <p>
                                                <span class="text-success">
                                                    <i class="fa fa-comment"></i> <asp:Label ID="lblreadmssg" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                </span> &nbsp;&nbsp;
                                                  <span class="text-danger">
                                                       <asp:Label ID="lbltreatedattachment" runat="server" Text='<%# Eval("UploadPath") %>'  class="fa fa-paperclip">

                                                       </asp:Label>

                                                  </span>

                                              </p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartfrom" runat="server" Text='<%# Eval("DepartmentfromId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsender" runat="server" Text='<%# Eval("CreatedBy") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTreatedstatus" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-success-close"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                            <asp:Label ID="Priority" runat="server" Text='<%# Eval("PriorityID") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
<%--                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit" CssClass="btn btn-primary" ><span class="glyphicon glyphicon-pencil">&nbsp;Edit</span></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>

                            </asp:GridView>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>

            </div>

        </asp:Panel>

        <asp:Panel ID="PnlUntreated" runat="server">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">UNTREATED MEMO</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvwUntreated" runat="server" AutoGenerateColumns="false" 
                                CssClass="table table-bordered table-striped table-responsive" OnRowCommand="gvassignedmemo_RowCommand" OnRowDataBound="gvwUntreated_RowDataBound"
                                 OnRowEditing="gvassignedmemo_RowEditing" ClientIDMode="Static">
                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblmemoid" runat="server" Text='<%# Eval("MemoID") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="btnEdit" runat="server" Text='<%# Eval("MemoID") %>' CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit"></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                            <p>
                                                <span class="text-success">
                                                    <i class="fa fa-comment"></i>
                                                    <asp:Label ID="lblreadmssg" runat="server" Text='<%# Eval("Comment") %>'>

                                                    </asp:Label>
                                                </span> &nbsp;&nbsp;
                                                <span class="text-danger">
                                                    <%--<i class="fa fa-paperclip" ></i>
                                                    <label id="lbluntreatedattachment" runat="server" text='<%# Eval("UploadPath")  %>'/>--%>
                                                    
                                                    <asp:Label ID="lbluntreatedattachment" runat="server" Text='<%# Eval("UploadPath")  %>' class="fa fa-paperclip">

                                                    </asp:Label>

                                                </span>
                                               
                                            </p>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department From">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartfrom" runat="server" Text='<%# Eval("DepartmentfromId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsender" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntreatedPriority" runat="server" Text='<%# Eval("PriorityID") %>' CssClass="badge badge-warning"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntreatedstatus" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Date/Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntreateddatecreated" runat="server" Text='<%# Eval("DateCreated") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkviewreply" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit" class="btn btn-primary btn-sm">
                                                <i class="fas fa-folder"></i> View
                                            </asp:LinkButton><asp:LinkButton ID="lnkbtnReject" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Reject" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#modal-primary1">
                                                <i class="fas fa-trash"></i> Reject
                                            </asp:LinkButton>
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
         
        <div class="modal fade" id="modal-primary">
            <div class="modal-dialog">
                <div class="modal-content bg-primary">
                    <div class="modal-header">
                        <h1 class="modal-title">Are You Sure !</h1>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <p>Do you really want to close this record? This process cannot be undone</p>
                    </div>
                    <div class="modal-footer justify-content-between">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <button type="button" class="btn btn-primary" id="savechanges" runat="server"
                            onserverclick="savechanges_ServerClick">
                            Yes close it!</button>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        
        <%--<div class="modal fade" id="modal-primary1">
            <div class="modal-dialog">
                <div class="modal-content bg-primary">
                    <div class="modal-header">
                        <h1 class="modal-title">Remark</h1>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <tr>
                                <td style="border-top:none">
                                    <div class="form-group row">
                                        <asp:Label ID="lblreason" runat="server" Text="Write the reason of Rejection?"></asp:Label>
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtremark" runat="server" CssClass="form-control" TextMode="MultiLine" required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                </td>

                                
                            </tr>

                        </table>
                    </div>
                    <div class="modal-footer justify-content-between">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <asp:Button ID="btnSendRejectfile" class="btn btn-primary" runat="server" Text="Send!" OnClick="btnSendRejectfile_Click" />

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>--%>
    </section>


    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=gvassignedmemo]').prepend($("<thead></thead>").append($("#<%=gvassignedmemo.ClientID%>").find("tr:first"))).DataTable({
                stateSave: true,
                responsive: true,
                //stateSave: true,
                //"responsive": true,
                //"sPaginationType": "full_numbers",
                //"paging": true,
                //"lengthChange": true,
                //"searching": true,
                //"ordering": true,
                //"info": true,

            });
        });
        $(document).ready(function () {
            $('[id*=gvwUntreated]').prepend($("<thead></thead>").append($("#<%=gvwUntreated.ClientID%>").find("tr:first"))).DataTable({
                stateSave: true,
                responsive: true,

            });
        });
        $(document).ready(function () {
            $('[id*=gvwTreated]').prepend($("<thead></thead>").append($("#<%=gvwTreated.ClientID%>").find("tr:first"))).DataTable({
                 stateSave: true,
                 responsive: true,

             });
         });
    </script>
    
    <script>
    $(document).ready(function () {
        $(".alert").fadeTo(10000, 500).slideUp(500, function () {
            $(".alert").slideUp(500);
        });
    });
    $('.toastrDefaultSuccess').click(function () {
        toastr.success('Record closed successfully.')
    });


</script>

</asp:Content>

