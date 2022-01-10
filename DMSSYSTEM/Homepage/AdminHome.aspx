<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Admin.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Masterpages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>ADMIN DASHBOARD</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Dashboard</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <!-- Main content -->
    <section class="content">
     
         
        
        <!-- /.row -->

        <div class="row">
            <div class="col-lg-3 col-6">
                <!-- small box -->
                <div class="small-box bg-info">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblnewmemo" runat="server" Text='<%#Eval("DepartmentToId")%>'></asp:Label></h3>

                        <p>ALL Memo</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <%-- <a href="../Memo/ViewMemo.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>--%>
                    <asp:LinkButton ID="lnkbtnDisplayAllMemo" runat="server" OnClick="lnkbtnDisplayAllMemo_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>

                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-6">
                <!-- small box -->
                <div class="small-box bg-success">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lbltreated" runat="server" Text="Label"></asp:Label><%--<sup style="font-size: 20px">%</sup>--%></h3>

                        <p>Treated</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-stats-bars"></i>
                    </div>
                    <asp:LinkButton ID="lnktreated" runat="server" OnClick="lnktreated_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
                    <%--<a href="../Memo/ViewMemo.aspx"  runat="server" id="treated" onclick="treated"></a>--%>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-6">
                <!-- small box -->
                <div class="small-box bg-danger">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblpending" runat="server" Text=""></asp:Label></h3>

                        <p>Untreated</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-pie-graph"></i>
                    </div>
                    <asp:LinkButton ID="lnkUntreated" runat="server" OnClick="lnkUntreated_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
                    <%--<a href="../Memo/ViewMemo.aspx" " runat="server"></a>--%>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-6">
                <!-- small box -->
                <div class="small-box bg-warning">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblconf" runat="server" Text=""></asp:Label></h3>

                        <p>CONFIDENTIAL MEMO</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-add"></i>
                    </div>
                    <asp:LinkButton ID="lnkConfidential" runat="server" OnClick="lnkConfidential_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
                    <%--<a href="~/Memo/ViewMemo.aspx"  runat="server" id="lnkconfidential"></a>--%>
                </div>
            </div>
            <!-- ./col -->

        </div>
        
        <hr />
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
                    <asp:Label ID="lblconfidentialoutgoing" runat="server" Text=""></asp:Label>

                </span>
              </div>
              <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
          </div>
          <!-- /.col -->
            </div><!---/row -->
        </asp:Panel> 

        <asp:Panel ID="PnlAllMemo" runat="server" Visible="false">
            <div class="row">
            <div class="col-12">
                <div class="card card-dark">
                    <div class="card-header">
                        <h3 class="card-title">ALL MEMO</h3>

                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
                        <asp:GridView ID="gvwdisplayallmemo" runat="server" class="table table-bordered table-striped table-responsive"
                            AutoGenerateColumns="false" OnRowDataBound="gvwdisplayallmemo_RowDataBound" ClientIDMode="Static">
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
                                <asp:TemplateField HeaderText="Department To">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' Format="MMMM d, yyyy"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sender">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsender" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Receiver">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreceiver" runat="server" Text='<%# Eval("RecievedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-danger"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpriority" runat="server" Text='<%# Eval("PriorityID") %>' CssClass="badge badge-warning"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Created">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldatecreated" runat="server" Text='<%# Eval("DateCreated") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Treated">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldatetreated" runat="server" Text='<%# Eval("DateTreated") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>



                    </div>

                </div>

            </div>
        </div>

        </asp:Panel>
        <asp:Panel ID="PnlTreated" runat="server" Visible="false">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">TREATED MEMO</h3>

                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvwTreatedmemo" runat="server" class="table table-bordered table-striped table-responsive"
                                AutoGenerateColumns="false" ClientIDMode="Static">
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
                                    <asp:TemplateField HeaderText="Department To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsender" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receiver">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreceiver" runat="server" Text='<%# Eval("RecievedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatusTreated" runat="server" Text='<%# Eval("StatusID") %>' class="btn btn-block btn-success"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Treated">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmemodate" runat="server" Text='<%# Eval("DateTreated") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>



                        </div>

                    </div>

                </div>

            </div>

        </asp:Panel>
        <asp:Panel ID="PnlPending" runat="server" Visible="false">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">UNTREATED MEMO</h3>

                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvPending" runat="server" class="table table-bordered table-striped table-responsive"
                                AutoGenerateColumns="false" ClientIDMode="Static">

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
                                            <asp:Label ID="lbluntreateddepartfrom" runat="server" Text='<%# Eval("DepartmentfromId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluntreateddepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluntreateddoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluntreatedsender" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receiver">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluntreatedreceiver" runat="server" Text='<%# Eval("RecievedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluntreatedstatus" runat="server" Text='<%# Eval("StatusID") %>' class="btn btn-block btn-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluntreateddate" runat="server" Text='<%# Eval("DateCreated") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </div>

                    </div>

                </div>

            </div>

        </asp:Panel>
        <asp:Panel ID="PnlConfidential" runat="server" Visible="false">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">CONFIDENTIAL MEMO</h3>

                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView ID="gvConfidential" runat="server" class="table table-bordered table-striped table-responsive"
                                AutoGenerateColumns="false" ClientIDMode="Static">

                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfimemoid" runat="server" Text='<%# Eval("MemoID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfisubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department From">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfidepartfrom" runat="server" Text='<%# Eval("DepartmentfromId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbconfildepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfisender" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receiver">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfireceiver" runat="server" Text='<%# Eval("RecievedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' class="btn btn-block btn-warning"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfistatus" runat="server" Text='<%# Eval("StatusID") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfidate" runat="server" Text='<%# Eval("DateCreated") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>


                        </div>

                    </div>

                </div>

            </div>

        </asp:Panel>

      
    </section>
    <!-- /.content -->
      
      <script>
        $(document).ready(function () {
            $('[id*=gvwdisplayallmemo]').prepend($("<thead></thead>").append($("#<%=gvwdisplayallmemo.ClientID%>").find("tr:first"))).DataTable({
                stateSave: true,
                responsive: true,

            });
        });
          $(document).ready(function () {
              $('[id*=gvwTreatedmemo]').prepend($("<thead></thead>").append($("#<%=gvwTreatedmemo.ClientID%>").find("tr:first"))).DataTable({
                  stateSave: true,
                  responsive: true,

              });
          });
        $(document).ready(function () {
            $('[id*=gvPending]').prepend($("<thead></thead>").append($("#<%=gvPending.ClientID%>").find("tr:first"))).DataTable({
                 stateSave: true,
                 responsive: true,

             });
        });
        $(document).ready(function () {
            $('#<%= gvConfidential.ClientID%>').prepend($("<thead></thead>").append($("#<%=gvConfidential.ClientID%>").find("tr:first"))).DataTable({
                stateSave: true,
                responsive: true,

            });
        });
    </script>
      </form>
</asp:Content>


