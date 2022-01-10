<%@ page title="" language="C#" masterpagefile="~/Masterpages/Directors.master" autoeventwireup="true" inherits="Masterpages_Default, App_Web_2wvr2ujv" %>

<%@ MasterType VirtualPath="~/Masterpages/Directors.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="../dist/css/bootstrap/3.3.7/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main content -->
    <section class="content">
        <div class="container-fluid">
            <div class="row mb-2">
          <div class="col-sm-6">
            <h1>DIRECTOR'S DASHBOARD</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Dashboard</li>
            </ol>
          </div>
        </div>
            
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- /.content -->
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <section class="content">
        <asp:Panel ID="PnlOffice" runat="server">
        <!-- /.col -->
        <div class="card card-success">
          <div class="card-body">
            <div class="row">
              <div class="col-md-12 col-lg-6 col-xl-4">
                <div class="card mb-2 bg-gradient-dark">
                  <img class="card-img-top" src="../dist/img/document-tracking-1.jpg" alt="Dist Photo 1" />
                </div>
              </div>
              <div class="col-md-12 col-lg-6 col-xl-4">
                <div class="card mb-2">
                  <img class="card-img-top" src="../dist/img/document-tracking-3.png" alt="Dist Photo 2" />
                </div>
              </div>
              <div class="col-md-12 col-lg-6 col-xl-4">
                <div class="card mb-2">
                  <img class="card-img-top" src="../dist/img/document-tracking-1.jpg" alt="Dist Photo 3" />
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- /.col -->

        </asp:Panel>
        <!-- Small boxes (Stat box) -->
        <asp:Panel ID="Pnlmoreinfo" runat="server">
            <!-- row -->
            <h5 class="mb-2">Incoming Mails</h5>
            
            <div class="row">
                <div class="col-lg-3 col-6">
                    <!-- small box -->
                    <div class="small-box bg-info">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblallmemo" runat="server" Text='<%#Eval("DepartmentToID")%>'></asp:Label></h3>

                            <p>ALL Memo</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <asp:LinkButton ID="lnkvwAll" runat="server" OnClick="lnkvwAll_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>

                   <%--     <a href="../Memo/viewAssignedMemo.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                   --%> </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-6">
                    <!-- small box -->
                    <div class="small-box bg-success">
                        <div class="inner">
                            <h3><%--<asp:Label ID="lbltreated" runat="server" Text="Label"></asp:Label><sup style="font-size: 20px">%</sup>--%>
                                <asp:Label ID="lbltreated" runat="server" Text=""></asp:Label>
                            </h3>

                            <p>Treated</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <asp:LinkButton ID="lnkTreated" runat="server" OnClick="lnkTreated_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>

                        <%--<a href="../Memo/ViewMemo.aspx" class="small-box-footer" runat="server" >More info <i class="fas fa-arrow-circle-right"></i></a>--%>
                    </div>
                </div>
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

                        <%--<a href="../Memo/ViewMemo.aspx" class="small-box-footer" runat="server">More info <i class="fas fa-arrow-circle-right"></i></a>--%>
                    </div>
                </div>
                <!-- ./col -->

                <!-- ./col -->
                <div class="col-lg-3 col-6">
                    <!-- small box -->
                    <div class="small-box bg-warning">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblconfi" runat="server" Text=""></asp:Label></h3>

                            <p>CONFIDENTIAL MEMO</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>
                        <asp:LinkButton ID="lnkConfidential" runat="server" OnClick="lnkConfidential_Click" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>

                        <%--<a href="../Memo/ViewMemo.aspx" class="small-box-footer" runat="server">More info <i class="fas fa-arrow-circle-right"></i></a>--%>
                    </div>
                </div>
                <!-- ./col -->
            </div>
            <!-- /.row -->

        </asp:Panel>
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
           
        <asp:Panel ID="PnlTreated" runat="server" Visible="false">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <h3 class="card-title">TREATED MEMO</h3>

                        </div>
                        <div class="card-body">
                            <asp:GridView ID="gvTreatedmemo" runat="server" class="table table-bordered table-striped table-responsive" 
                                AutoGenerateColumns="false" ClientIDMode="Static">

                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
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
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("StatusID") %>' class="btn btn-block btn-success"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldateTreated" runat="server" Text='<%# Eval("DateTreated") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="PnlUntreated" runat="server" Visible="false">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <div class="card-header">
                            <!-- /.card-header -->
                            <h3 class="card-title">UNTREATED MEMO</h3>

                        </div>
                        <div class="card-body">
                            <asp:GridView ID="gvUntreated" runat="server" class="table table-bordered table-striped" 
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
                                    
                                    <asp:TemplateField HeaderText="Deparment To">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartTo" runat="server" Text='<%# Eval("DepartmentToID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' Format="MMMM d, yyyy"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("StatusID") %>' class="btn btn-block btn-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date/Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("DateCreated") %>' Format="MMMM d, yyyy"></asp:Label>
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
                            <!-- /.card-header -->
                            <h3 class="card-title">CONFIDENTIAL MEMO</h3>

                        </div>
                        <div class="card-body">
                            <asp:GridView ID="gvConfidential" runat="server" class="table table-bordered table-striped" 
                                AutoGenerateColumns="false" OnRowDataBound="gvConfidential_RowDataBound" ClientIDMode="Static">
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
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconfstatus" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>' class="btn btn-block btn-warning"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>


                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="PnlViewAll" runat="server" Visible="false">
            <div class="row">
                <div class="col-12">
                    <div class="card card-dark">
                        <!-- /.card-header -->
                        <div class="card-header">
                            <h3 class="card-title">VIEW ALL</h3>

                        </div>
                        <div class="card-body">
                            <asp:GridView ID="gvwdisplayallmemo" runat="server" class="table table-bordered table-striped" 
                                AutoGenerateColumns="false" OnRowDataBound="gvwdisplayallmemo_RowDataBound" ClientIDMode="Static">

                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S/No">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmemoid" runat="server" Text='<%# Eval("MemoID") %>'></asp:Label>
                                           <%-- <asp:LinkButton ID="btnEdit" runat="server" Text='<%# Eval("MemoID") %>' CommandArgument='<%# Eval("MemoID") %>' CommandName="Edit"></asp:LinkButton>--%>

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
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvwallstatus" runat="server" Text='<%# Eval("StatusID") %>' CssClass="badge badge-danger"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoctype" runat="server" Text='<%# Eval("DocumentTypeID") %>'></asp:Label>
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
             $('[id*=gvTreatedmemo]').prepend($("<thead></thead>").append($("#<%=gvTreatedmemo.ClientID%>").find("tr:first"))).DataTable({
                  stateSave: true,
                  responsive: true,

              });
          });
          $(document).ready(function () {
              $('[id*=gvUntreated]').prepend($("<thead></thead>").append($("#<%=gvUntreated.ClientID%>").find("tr:first"))).DataTable({
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
</asp:Content>


