<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Secretary.master" AutoEventWireup="true" CodeFile="ViewMemo.aspx.cs" Inherits="Masterpages_Default" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<%--<link href="../dist/css/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>--%>
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>

<style>
    body {font-family: Arial, Helvetica, sans-serif;}
* {box-sizing: border-box;}
   
    /* Set a style for all buttons */
button {
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}
 #pnldisplay {
        padding:10px;
    }
button:hover {
  opacity:1;
}

/* Float cancel and delete buttons and add an equal width */
.cancelbtn, .deletebtn {
  float: left;
  width: 50%;
}

/* Add a color to the cancel button */
.cancelbtn {
  background-color: #ccc;
  color: black;
}

/* Add a color to the delete button */
.deletebtn {
  background-color: #f44336;
}

/* Add padding and center-align text to the container */
.container {
  padding: 16px;
  text-align: center;
}

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  /*background-color: #474e5d;*/
  padding-top: 50px;
}

/* Modal Content/Box */
.modal-content {
  background-color: #fefefe;
  margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
  border: 1px solid #888;
  width: 80%; /* Could be more or less, depending on screen size */
}

/* Style the horizontal ruler */
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}
 
/* The Modal Close Button (x) */
.close {
  position: absolute;
  right: 35px;
  top: 15px;
  font-size: 40px;
  font-weight: bold;
  color: #f1f1f1;
}

.close:hover,
.close:focus {
  color: #f44336;
  cursor: pointer;
}

/* Clear floats */
.clearfix::after {
  content: "";
  clear: both;
  display: table;
}

/* Change styles for cancel button and delete button on extra small screens */
@media screen and (max-width: 300px) {
  .cancelbtn, .deletebtn {
     width: 100%;
  }
}


body {
	font-family: 'Varela Round', sans-serif;
}
.modal-confirm {		
	color: #636363;
	width: 400px;
}
.modal-confirm .modal-content {
	padding: 20px;
	border-radius: 5px;
	border: none;
	text-align: center;
	font-size: 14px;
}
.modal-confirm .modal-header {
	border-bottom: none;   
	position: relative;
}
.modal-confirm h4 {
	text-align: center;
	font-size: 26px;
	margin: 30px 0 -10px;
}
.modal-confirm .close {
	position: absolute;
	top: -5px;
	right: -100px;
    color: #999;
}
.modal-confirm .modal-body {
	color: #999;
}
.modal-confirm .modal-footer {
	border: none;
	text-align: center;		
	border-radius: 5px;
	font-size: 13px;
	padding: 10px 15px 25px;
}
.modal-confirm .modal-footer a {
	color: #999;
}		
.modal-confirm .icon-box {
	width: 80px;
	height: 80px;
	margin: 0 auto;
	border-radius: 50%;
	z-index: 9;
	text-align: center;
	border: 3px solid #f15e5e;
}
.modal-confirm .icon-box i {
	color: #f15e5e;
	font-size: 46px;
	display: inline-block;
	margin-top: 13px;
}
.modal-confirm .btn, .modal-confirm .btn:active {
	color: #fff;
	border-radius: 4px;
	/*background: #60c7c1;*/
    background:rgb(48, 133, 214);
	text-decoration: none;
	transition: all 0.4s;
	line-height: normal;
	min-width: 120px;
	border: none;
	min-height: 40px;
	border-radius: 3px;
	margin: 0 5px;
}
.modal-confirm .btn-secondary {
	 background:rgb(48, 133, 214);
}
.modal-confirm .btn-secondary:hover, .modal-confirm .btn-secondary:focus {
	background: #a8a8a8;
}
.modal-confirm .btn-danger {
	background: #f15e5e;
}
.modal-confirm .btn-danger:hover, .modal-confirm .btn-danger:focus {
	background: #ee3535;
}
.trigger-btn {
	display: inline-block;
	margin: 100px auto;
}

</style>
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceholderID="TopContent" runat="server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-6">
                            <h1>INCOMING MEMO</h1>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
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
<asp:Content ID="bodycontent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       
<section class="content">
    <%--<form id="submission" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> </form>--%>
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <asp:Panel ID="pnldisplay" runat="server" Visible="false">
                 <div class="card-header">
                        <h3 class="card-title"> Reply to a Memo
                        </h3>
                    </div>
                  <div class="card-body">
                       <div class="row">
                           <div class="col-md-12">
                               <form class="form-horizontal" id="form1" method="post">

                                       <div class="form-group row">
                                           <label for="inputEmail3" class="col-sm-2 col-form-label">Subject</label>
                                           <div class="col-sm-10">
                                               <asp:Label ID="lblSubject" runat="server"></asp:Label>
                                               <%--<asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                           </div>
                                       </div>
                                       <div class="form-group row">
                                           
                                           <label for="inputEmail3" class="col-sm-2 col-form-label">Document Type</label>
                                           <div class="col-sm-10">
                                               <asp:Label ID="txtdocType" runat="server"></asp:Label>
                                           </div>
                                       </div>
                                    <div class="form-group row">

                                       <label for="inputEmail3" class="col-sm-2 col-form-label">Department From</label>
                                       <div class="col-sm-10">
                                           <asp:Label ID="lblFrom" runat="server"></asp:Label>
                                       </div>
                                   </div>
                                   <div class="form-group row">

                                       <label for="inputEmail3" class="col-sm-2 col-form-label">Department To</label>
                                       <div class="col-sm-10">
                                           <asp:Label ID="lblDeptTo" runat="server"></asp:Label>
                                       </div>
                                   </div>

                                   <div class="form-group row">
                                           <label for="inputPassword3" class="col-sm-2 col-form-label">Status</label>
                                           <div class="col-sm-10">
                                               <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                           </div>
                                       </div>

                                   <div class="card-footer">
                                       <asp:Label ID="lblInfo" runat="server" Text="Message"></asp:Label>

                                   </div>
                                  
                                       <asp:Button ID="btnupdate" runat="server" Text="Upadate" CssClass="btn btn-info" OnClick="btnUpdate_Click" Visible="false" />
                                       <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmOnFormSubmit="true" ConfirmText="Are you sure want to Update this record" TargetControlID="btnupdate" runat="server" />
                                       <div class="form-group row">
                                           <div class="offset-sm-2 col-sm-10">
                                           </div>
                                       </div>
                                   </form>

                           </div>
                       </div>
                      
                  </div>

                </asp:Panel>
                

            </div>
            

        </div>

    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="pnlTimeline" runat="server">
                <div class="timeline timeline-inverse">
                <!-- timeline item -->

                    <div class="form-group row">
                        <i class="fas fa-user bg-green"></i>
                        
                        <div class="timeline-item" style="width: 100%;" >
                            <%--<label for="inputPassword3" class="col-sm-2 col-form-label">Status</label>--%>

                            <span class="time"><i class="fas fa-clock"></i>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("DateCreated")%>'></asp:Label></span>
                            <h3 class="timeline-header"><a href="#">
                                <asp:Label ID="lblLoadstatus" runat="server" Text='Status'></asp:Label></a></h3>
                            <div class="timeline-body">
                                <asp:DropDownList ID="drpStatusID" runat="server" CssClass="form-control select2" Style="width: 100%;">
                                </asp:DropDownList>

                            </div>


                        </div>


                    </div>
                    <div id="sendermemo" runat="server">
                    <i class="fas fa-envelope bg-blue"></i>
                    <div class="timeline-item">
                        <span class="time"><i class="fas fa-clock"></i>
                            <asp:Label ID="lblDateCreated" runat="server" Text='<%#Eval("DateCreated")%>'></asp:Label></span>
                        <h3 class="timeline-header"><a href="#"><asp:Label ID="lblSender" runat="server" Text='<%#Eval("DepartmentfromID")%>'></asp:Label></a> sent you a memo</h3>

                        <div class="timeline-body">
                            <p id="psender" runat="server"></p>
                 
                        </div>
                        
                        <div class="timeline-footer">
                           <%-- <a class="btn btn-primary btn-sm">Read more</a> <a class="btn btn-danger btn-sm" ></a>
                            <a href="#" class="text-danger" target="_blank" runat="server" id="dwnfile">
                               <i class="fa fa-paperclip"></i> Download Attachment<br/>
                               </a>   --%>
                           
                                
                         
                            <asp:LinkButton ID="dwnpath" runat="server" class="text-danger" target="_blank" OnClick="lbldwnpath_Click"  CommandArgument='<%# Eval("UploadPath") %>'><i class="fa fa-paperclip"></i> Download Attachment</asp:LinkButton> 

                        </div>
                    </div>
                </div>
                    <div id="receiver" runat="server">
                    <i class="fas fa-envelope bg-blue"></i>
                    <div class="timeline-item">
                        <span class="time"><i class="fas fa-clock"></i><asp:Label ID="lblDateTreated" runat="server" Text='<%#Eval("DateTreated")%>'></asp:Label></span>
                        <h3 class="timeline-header"><a href="#"><asp:Label ID="lblreciever" runat="server" Text='<%#Eval("RecievedBy")%>'></asp:Label></a> Replied</h3>

                        <div class="timeline-body">
                            <p id="preciever" runat="server"></p>

                        </div>
                        <div class="timeline-footer">
                           <%-- <a class="btn btn-primary btn-sm">Read more</a>
                            <a class="btn btn-danger btn-sm">Delete</a>--%>
                        </div>
                    </div>
                </div>
                    
                    <div>
                    <i class="fas fa-comments bg-green"></i>
                    <%--<i class="fas fa-comments bg-yellow"></i>--%>
                    <div class="timeline-item">
                        <span class="time"><i class="fas fa-clock"></i><%: DateTime.Today %> </span>
                        <h3 class="timeline-header"><a href="#"></a> Reply</h3>
                        <div class="timeline-body">
                            
                                <form id="replyForm" method="post">
                                    <div class="form-group">
                                        <label for="message">
                                            Message
                                            <span class="text-danger">*</span>
                                            
                                        </label>
                                        <textarea id="txtmessage" class="summernote form-control" runat="server" required></textarea>
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
                                    <div class="form-group row">
                                        <div class="offset-sm-2 col-sm-10">
                                        </div>
                                    </div>

                                </form>
                            
                 
                        </div>
                    </div>
                </div>
                <!-- END timeline item -->
                <div>
                    <i class="fas fa-clock bg-gray"></i>
                </div>
            </div>
                <div class="card-footer">
                <asp:Button ID="Save" runat="server" Text="Send" CssClass="btn btn-danger btn-lg" OnClick="Save_Click"
                    OnClientClick="GetResponse();" />

                </div>

            </asp:Panel>
            

        </div>

    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <asp:Panel ID="Pnldisplaygrid" runat="server">
                    <div class="card-header">
                    <h3 class="card-title">INCOMING MEMO </h3>

                </div>
                 <!-- /.card-header -->
                <div class="card-body">
                    <div class="form-group row">
                        <div class="offset-sm-2 col-sm-10">
                        </div>
                    </div>

                    <asp:GridView ID="gvwallmemo" runat="server" class="table table-bordered table-striped table-responsive" AutoGenerateColumns="false"
                        OnRowCommand="gvwallmemo_RowCommand" OnRowEditing="gvwallmemo_RowEditing" OnRowDeleting="gvwallmemo_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="S/No">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref No">
                                <ItemTemplate>
                                    <asp:Label ID="lblmemoid" runat="server" Text='<%# Eval("MemoID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
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
                                    <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentType") %>' Format="MMMM d, yyyy"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sender">
                                <ItemTemplate>
                                    <asp:Label ID="lblsender" runat="server" Text='<%# Eval("CreatedBy") %>' Format="MMMM d, yyyy"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbldatein" runat="server" Text='<%# Eval("DateIn") %>' Format="MMMM d, yyyy"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit" class="btn btn-primary btn-xs"><span class="glyphicon glyphicon-pencil">&nbsp;Edit</span></asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("MemoID") %>' CommandName="Delete"><span class="glyphicon glyphicon-trash">&nbsp;Delete</span></asp:LinkButton>
                                    <!-- Modal -->
                                    <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog modal-confirm">
                                            <div class="modal-content">
                                                <div class="modal-header flex-column">
                                                    <div class="icon-box">
                                                        <i class="material-icons"></i>
                                                    </div>
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h1 class="modal-title w-100" id="myModalLabel">Are You Sure !</h1>
                                                </div>
                                                <div class="modal-body">
                                                    <p>Do you really want to delete this record? This process cannot be undone.</p>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="btnconfirmOk" runat="server" Text="Yes, close it!" class="btn btn-primary" OnClick="btnconfirmOk_Click" CommandArgument='<%# Eval("MemoID") %>' CommandName="Delete" />
                                                    <%--<button type="button" id="btnconfirmOk" class="btn btn-primary" runat="server">Yes, close it!</button>--%>
                                                    <button type="button" id="btnconfirmCancel" class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancel</button>

                                                </div>
                                            </div>
                                            <!-- /.modal-content -->
                                        </div>
                                        <!-- /.modal-dialog -->
                                    </div>
                                    <!-- /.modal -->

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                </div>
                <!-- /.card-body -->

                </asp:Panel>
                
            </div>

        </div>

    </div>
</section>
    
    <!-- /.card -->
        
    <!-- page script -->

     <script>
         $(document).ready(function () {
             $('#<%= gvwallmemo.ClientID%>').prepend($("<thead></thead>").append($("#<%=gvwallmemo.ClientID%>").find("tr:first"))).DataTable({
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

    <script>
        //$(document).ready(function () {
      $(function () {
            $("[id*=btnDelete]").removeAttr("onclick");
            $('#myModal').modal({
                backdrop: 'static',
                show: false,
                
                modal: true,
                autoOpen: false,
                width: 350,
                height: 160,
            })

            $("[id*=btnDelete]").click(function ()
            //$('#btnDelete').click(function ()
            {
                if ($(this).attr("rel") != "delete") {
                    $('#myModal').modal("show");
                    return false;

                }
                else {
                    __doPostBack(this.name, '');
                }

                
            });

        });
    </script>
 <script type="text/javascript">
     function GetResponse() {
         debugger;
         document.getElementById("#<%=txtmessage.ClientID%>").value = $('#<%=txtmessage.ClientID%>').summernote('code');
         }
    </script>
 
</asp:Content>




