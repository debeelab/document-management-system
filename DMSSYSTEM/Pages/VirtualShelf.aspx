<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Secretary.master" AutoEventWireup="true" CodeFile="VirtualShelf.aspx.cs" Inherits="Masterpages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" Runat="Server">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlVirtualshelf" runat="server" Style="padding-left:7.5px">
        <div class="row">
            <div class="col-md-12">
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
                                <asp:TemplateField HeaderText="Receiver Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsender" runat="server" Text='<%# Eval("Sender") %>' Format="MMMM d, yyyy"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created By" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcreatedby" runat="server" Text='<%# Eval("CreatedBy") %>' Format="MMMM d, yyyy"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dispatcher Name">
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

     <script>
         $(document).ready(function () {
             $('#<%= gvvirtual.ClientID%>').prepend($("<thead></thead>").append($("#<%=gvvirtual.ClientID%>").find("tr:first"))).DataTable({
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
</asp:Content>

