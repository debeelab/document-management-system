<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Secretary.master" AutoEventWireup="true" CodeFile="Create_Memo.aspx.cs" Inherits="Masterpages_Default" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="TopContent">
      <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>INTERNAL MEMO</h1>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                             <div class="form-group row">
                                 <label for="inputEmail3" class="col-sm-2 col-form-label">Subject</label>
                                 <div class="col-sm-10">
                                     <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" required></asp:TextBox>
                                 </div>
                             </div>

                             <div class="form-group row">
                                 <label for="inputPassword3" class="col-sm-2 col-form-label">Document Type</label>
                                 <div class="col-sm-10">
                                     <asp:DropDownList ID="drpDocumentType" runat="server" CssClass="form-control">
                                     </asp:DropDownList>
                                 </div>
                             </div>

                             <div class="form-group row">
                                 <label for="inputPassword3" class="col-sm-2 col-form-label">Department To</label>
                                 <div class="col-sm-10">
                                     <asp:DropDownList ID="drpDepartmentToID" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="drpDepartmentToID_SelectedIndexChanged">
                                     </asp:DropDownList>
                                 </div>
                             </div>
                             <div class="form-group row">
                                 <label for="inputPassword3" class="col-sm-2 col-form-label">Send To</label>
                                 <div class="col-sm-10">
                                     <asp:DropDownList ID="drpMemoTo" runat="server" CssClass="form-control" AppendDataBoundItems="true"
                                         EnableViewState="true">
                                     </asp:DropDownList>
                                 </div>
                             </div>
                             <div class="form-group row">
                                 <label for="inputPassword3" class="col-sm-2 col-form-label">Priority</label>
                                 <div class="col-sm-10">
                                     <asp:DropDownList ID="drpPriority" runat="server" CssClass="form-control"></asp:DropDownList>
                                 </div>
                             </div>
                             <div class="form-group row">
                                 <label for="inputPassword3" class="col-sm-2 col-form-label">Body</label>
                                 <div class="col-sm-10">
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

                             <%--<div class="form-group">
                  <div class="btn btn-default btn-file">
                    <i class="fas fa-paperclip"></i> Attachment
                    <input type="file" name="attachment" />
                  </div>
                </div>--%>
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
<%--    <script>
        function Confirm()
        {
            var result = confirm("Are you sure you want to Save this Record");
            if (result == true)
            {
                document.getElementById("<%=txtmssg.ClientID%>").value = "Yes";
            }
            else
            {
                document.getElementById("<%=txtmssg.ClientID%>").value = "No";
            }
        }
</script>--%>
</asp:Content>




