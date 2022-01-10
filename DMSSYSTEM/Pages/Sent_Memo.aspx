<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Directors.master" AutoEventWireup="true" CodeFile="Sent_Memo.aspx.cs" Inherits="Masterpages_Default" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <%--   <link href="../dist/css/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
     <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>--%>
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Outgoing Memo</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">Outgoing Memo</li>
                    </ol>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <section class="content">
        <asp:Panel ID="PnlOutgoingmail" runat="server">
             <h5 class="mb-2">Outgoing Mails</h5>
            <div class="row">
                <div class="col-12 col-sm-6 col-md-3">
                    <div class="info-box">
                        <span class="info-box-icon bg-info elevation-1"><i class="fas fa-cog"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">All Outgoing mail</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblalloutgoing" runat="server" Text='<%#Eval("DepartmentfromID")%>'></asp:Label>
                                <%--<small>%</small>--%>
                            </span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>

                <div class="col-12 col-sm-6 col-md-3">
                    <div class="info-box mb-3">
                        <span class="info-box-icon bg-success elevation-1"><i class="fas fa-thumbs-up"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Treated</span>
                            <span class="info-box-number"><asp:Label ID="lblTreatedOutgoing" runat="server"></asp:Label></span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>

                <!-- /.col -->
                
          <!-- fix for small devices only -->
          <div class="clearfix hidden-md-up"></div>
          <!-- /.col -->
          <div class="col-12 col-sm-6 col-md-3">
                    <div class="info-box mb-3">
                        <span class="info-box-icon bg-danger elevation-1"><i class="ion ion-pie-graph"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Untreated</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblUntreatedOutgoing" runat="server" Text=""></asp:Label>

                            </span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
          <!-- /.col -->
          <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-warning elevation-1"><i class="far fa-copy"></i></span>

              <div class="info-box-content">
                <span class="info-box-text">Confidential</span>
                <span class="info-box-number">
                    <asp:Label ID="lblconfidentialoutgoing" runat="server"></asp:Label>

                </span>
              </div>
              <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
          </div>
          <!-- /.col -->
            </div><!---/row -->
        </asp:Panel>

        <hr />
         
        <asp:Panel ID="pnldisplay" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">OUTGOING MEMO <asp:Label ID="lblmemoid" runat="server" ></asp:Label>
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
                                                        <asp:Label ID="lbldocType" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group row">
                                                    <label for="inputPassword3" class="col-sm-2 col-form-label">Status</label>
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblStatus" runat="server" CssClass="badge badge-danger"></asp:Label>

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
                                                        <asp:Label ID="lbldeptTo" runat="server"></asp:Label>
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

                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <!-- /.col-->
            </div>

        </asp:Panel>

        <asp:Panel ID="Pnltimeline" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="timeline timeline-inverse">

                        <div>

                            <%--<i class="fas fa-envelope bg-blue"></i>--%>
                            <i class="fa fa-send bg-dark"></i>

                            <div class="timeline-item">
                                <span class="time"><i class="fas fa-clock"></i>
                                    <asp:Label ID="lblDateCreated" Text='<%#Eval("DateCreated")%>' runat="server" /></span>
                                <h3 class="timeline-header"><a href="#">
                                    <asp:Label ID="lblSender" runat="server" Text='<%#Eval("DepartmentfromID")%>'></asp:Label></a> sent you a memo</h3>

                                <div class="timeline-body">
                                    <p id="psender" runat="server"></p>
                                </div>

                                <div class="timeline-footer" id="footerdownload" runat="server">
                                    <asp:LinkButton ID="lnkbtndwnpath" runat="server" class="text-danger" Text='<%# Eval("UploadPath")  %>' OnClick="lnkbtndwnpath_Click" CommandArgument='<%#Eval("MemoID")%>'>
                                       <i class="fa fa-paperclip"></i> 
                                       Download Attachment

                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <asp:Repeater ID="RepeatervwSent" runat="server" OnItemDataBound="RepeatervwSent_ItemDataBound">
                            <ItemTemplate>
                                <div id="divreplied" runat="server">

                                    <%--<i class="fas fa-comments bg-green"></i>--%>
                                    <i class="fa fa-reply bg-success-close"></i>
                                    <div class="timeline-item">
                                        <span class="time"><i class="fas fa-clock"></i>
                                            <asp:Label ID="lblDateTreated" Text='<%#Eval("DateTreated")%>' runat="server" />
                                        </span>
                                        <h3 class="timeline-header"><a href="#">
                                            <asp:Label ID="lblreplied" runat="server" Text='<%#Eval("SentBy")%>'></asp:Label></a> Replied</h3>

                                        <div class="timeline-body">
                                            <p id="preplied" runat="server" innerhtml='<%#Eval("RepliedMessage")%>'></p>
                                        </div>
                                        <div class="timeline-footer">
                                            <asp:LinkButton ID="lnkgetdownloadreplied" runat="server" class="text-danger" Text='<%# Eval("UploadPath")  %>' OnClick="lnkgetdownloadreplied_Click"> 
                                        <i class="fa fa-paperclip">
                                        </i> Download Attachment</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        
                        <div id="divresponse" runat="server">

                            <%--<i class="fas fa-comments bg-green"></i>--%>
                            <i class="fa fa-share bg-danger"></i>
                            <div class="timeline-item">
                                <span class="time"><i class="fas fa-clock"></i>
                                    <asp:Label ID="Label2" Text='<%#Eval("DateTreated")%>' runat="server" />
                                </span>
                                <h3 class="timeline-header"><a href="#">
                                    <asp:Label ID="lblresponse" runat="server" Text='<%#Eval("DepartmentfromID")%>'></asp:Label></a> Response</h3>

                                <div class="timeline-body">
                                    <p id="presponse" runat="server"></p>
                                </div>
                            </div>
                        </div>

                        <!-- timeline item -->
                        <div>
                            <i class="fas fa-envelope bg-blue"></i>
                            <div class="timeline-item">
                                <span class="time"><i class="fas fa-clock"></i><%: DateTime.Now %> </span>
                                <h3 class="timeline-header"><a href="#">Reply</a></h3>

                                <div class="timeline-body">
                                    <div class="mb-3">
                                        <label for="message">
                                            Message
                                            <span class="text-danger">*</span>

                                        </label>
                                        <textarea id="txtreplymemo" class="summernote" runat="server"></textarea>

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
                                    <%--<asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click" class="btn btn-danger btn-lg" OnClientClick="GetResponse ();" /><asp:Label ID="lblresult" runat="server"></asp:Label>--%>
                                    <asp:Button ID="btnSend" runat="server" Text="Send" class="btn btn-danger btn-lg" OnClick="btnSend_Click" OnClientClick="GetResponse ();" />


                                </div>
                            </div>
                        </div>
                        <!-- END timeline item -->
                        <div>
                            <i class="fas fa-clock bg-gray"></i>
                        </div>
                    </div>

                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="PnlLoadgvw" runat="server">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">

                        <div class="card-header">
                            <h3 class="card-title">Outgoing Memo</h3>

                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvMemo" runat="server" OnRowDataBound="gvMemo_RowDataBound" OnRowCommand="gvMemo_RowCommand"
                                class="table table-bordered table-striped table-responsive" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkmemo" runat="server" Text='<%# Eval("MemoID") %>' CommandArgument='<%# Eval("MemoID") %>' CommandName="Showmemo"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' CssClass="badge badge-warning"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Created/Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateTreated" runat="server" Text='<%# Eval("DateCreated") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkviewreply" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="ViewReply" class="btn btn-primary btn-sm">
                                                <i class="fas fa-folder"></i> View
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkbtnReject" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Reject" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#modal-primary1">
                                                <i class="fas fa-trash"></i> Reject
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </div>
                    </div>

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
                        <button type="button" class="btn btn-primary" id="savechanges" runat="server" onserverclick="savechanges_ServerClick">
                            Yes close it!</button>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

        <div class="modal fade" id="modal-primary1">
            <div class="modal-dialog">
                <div class="modal-content bg-primary">
                    <div class="modal-header">
                        <h1 class="modal-title">Remark</h1>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <%--<p>Do you really want to close this record? This process cannot be undone</p>--%>
                        <table class="table">
                            <tr>
                                <td style="border-top:none">
                                    <div class="form-group row">
                                        <div class="col-sm-12">
                                            <asp:TextBox ID="txtremark" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>

                                </td>

                                
                            </tr>

                        </table>
                    </div>
                    <div class="modal-footer justify-content-between">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <button type="button" class="btn btn-primary" id="Button1" runat="server" onserverclick="savechanges_ServerClick">
                            Send!</button>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- /.content -->
    <script>
        $(document).ready(function () {
            $('#<%= gvMemo.ClientID%>').prepend($("<thead></thead>").append($("#<%=gvMemo.ClientID%>").find("tr:first"))).DataTable({
                 stateSave: true,
                 responsive: true,

                 //"paging": true,
                 //"lengthChange": true,
                 //"searching": true,
                 //"ordering": true,
                 //"info": true,
                 //"autoWidth": false,
             });
         });
    </script>
    <%--   <script type="text/javascript">
          function GetResponse() {
              $("#<%= message.ClientID %>").val($('.summernote').summernote('code'));
        }
</script>--%>
<script type="text/javascript">
     function GetResponse() {
         $("#<%= txtreplymemo.ClientID %>").val($('.summernote').summernote('code'));
     }

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

