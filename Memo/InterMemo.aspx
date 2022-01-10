<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Directors.master" AutoEventWireup="true" CodeFile="InterMemo.aspx.cs" Inherits="Masterpages_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="card card-info">
        <div class="card-header">
            <h3 class="card-title">Memo</h3>
        </div>
        <!-- /.card-header -->
        <!-- form start -->
        <form class="form-horizontal" id="form1" >

             
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
                        <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="true"  CssClass="form-control" >
                         </asp:DropDownList> 
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Date In</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDateIn" runat="server" CssClass="form-control" required></asp:TextBox>
                        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtDateIn" Format="MM-dd-yyyy"></ajaxToolkit:CalendarExtender>

                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Memo Date</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtMemoDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtMemoDate" Format="MM-dd-yyyy"/>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Upload</label>
                    <div class="col-sm-10">
                        <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control" />

                        <asp:Label ID="label1" runat="server" Text="Label" Visible="False"></asp:Label>

                        <asp:TextBox ID="txtfileName" runat="server" Visible="false"></asp:TextBox>
                    </div>

                </div>
                <div class="form-group row">
                    <div class="offset-sm-2 col-sm-10">
                    </div>
                </div>

                <div class="card-footer">
                    <asp:Button ID="Save" runat="server" Text="Save" CssClass="btn btn-info" OnClick="Save_Click" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" ConfirmOnFormSubmit="true" ConfirmText="Are you sure want to save this record" TargetControlID="save" runat="server" />
            
                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

