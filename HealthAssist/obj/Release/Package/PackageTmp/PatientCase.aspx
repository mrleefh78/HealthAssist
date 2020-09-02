<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="PatientCase.aspx.cs" Inherits="HealthAssist.PatientCase" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Patient
        <small>Case</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active"><asp:Label ID="ActiveForm" runat="server" Text="Patient Case"></asp:Label></li>
      </ol>
    </section>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin: 0">
        <div class="row">  
             <div class="col-md-1"> 
             </div>
             <div class="col-md-6"> 
              <%--  <button type="button" runat ="server" onserverclick="AddClick"  class="btn btn-primary" ><span class="glyphicon glyphicon-plus"></span> Add</button>--%>
      
             </div>
              <div class="col-md-2"> 
                 <form class="form-inline my-2 my-lg-0">
                 
                  <input class="form-control mr-sm-2" type="text" id="searchKeyword"  runat ="server" placeholder="Search">
                 
                </form> 
             </div>
             <div class="col-md-2"> 
                   <button class="btn btn-info my-2 my-sm-0" type="submit" runat ="server" onserverclick="SearchClick" >Search</button>
             </div>
             <div class="col-md-1"> 
             </div>
          </div> 
          
        <div class="row">  
            <h4 class="page-header"></h4>
            <div class="col-md-1"> 
             </div>
             <div class="col-md-10">           

                        
                 
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="gvList_PageIndexChanging" Width="100%" CssClass="table table-striped">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                
                <asp:BoundField DataField="CaseNo" HeaderText="Reference Number">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="CaseDate" DataFormatString="{0:d}" HeaderText="Date Entry">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="InsuranceNo" HeaderText="Insurance Number">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="dob" DataFormatString="{0:d}" HeaderText="DOB">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="PhysicianName" HeaderText="Attending Physician">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FacilityName" HeaderText="Hospital Name" />
                <asp:BoundField DataField="CompanyName" HeaderText="Assistance Company" />
                <asp:BoundField DataField="status" HeaderText="Status" />

                <asp:TemplateField>
                    <ItemTemplate>
                       
                    <%--    <asp:ImageButton ID="btnEdit" runat="server" CommandName="EditCommand" class="btn btn-success" Text="Edit" ToolTip="Edit" />--%>
                        <button type="button" id="updateButton" title="Edit" data-id ='<%# Eval("id")%>' onserverclick="UpdateClick"  runat ="server"  class="btn btn-success btn-xs" data-toggle="modal" data-target="#edit"><span class="glyphicon glyphicon-edit"></span></button>
                   <%-- <td style="width: 50px;"><p data-placement="top" data-toggle="tooltip" title="Edit"><button type="button" class="btn btn-success btn-xs" data-toggle="modal" data-target="#edit"><span class="glyphicon glyphicon-edit"></span></button></p></td>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <button type="button" id="deleteID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#delete"  data-id ='<%# Eval("id")%>' ><span class="glyphicon glyphicon-remove"></span></button>
                      <%--    <td style="width: 50px;"><p data-placement="top" data-toggle="tooltip" title="Reject"><button type="button" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-delete"></span></button></p></td>--%>
  
                        <%--<asp:ImageButton ID="btnDel" runat="server" CommandName="DelCommand" class="btn btn-danger" Text="Delete" ToolTip="Delete" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" CssClass="GridPager" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        
        </div>

      <!-- /delete.modal-content --> 

    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading1">Reason for deletion </h4>
      </div>
          <div class="modal-body">
          <div class="form-group">
        <p> Are you sure to delete patient case <asp:Label ID="lblPatientCase" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldPatientCase" ClientIDMode ="Static" runat="server" />
        <textarea id="itemname"  rows="4" cols="75" runat="server" maxlength="500" placeholder="reason"></textarea><br /><br />
              
        </div>
       
      </div>
          <div class="modal-footer ">
              <input type="button" id="btnsubmit" runat="server" class="btn btn-primary" onserverclick="Ok_ServerClick" value="Save" />
       <%-- <button type="button"class="btn btn-primary" runat="server" onServerClick="Ok_ServerClick"><span class="glyphicon glyphicon-ok-sign"></span> Save</button>--%>
        <button type="button" id="closebutupdate" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
    </div>

     <!-- /.approve modal-dialog --> 
 <div  class="modal fade" id="edit1" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading">Approve this request </h4>
      </div>
          <div class="modal-body">
       
       <div class="alert alert-danger"><span class="glyphicon glyphicon-warning-sign"></span> Are you sure you want to Approve <strong>?</strong></div>
       
      </div>
        <div class="modal-footer ">
        <button type="button"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Yes</button>
        <button type="button" id="closebut" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> No</button>
      </div>
        </div>
    <!-- /.modal-content --> 
  </div>
      <!-- /.modal-dialog --> 
    </div>
             </div>
             <div class="col-md-1"> </div>     

             </div>
     
    </div>

     <script>
        $(document).ready(function ()
            {
            $('myTable').DataTable();
            }
        )
        $(document).on("click", "#deleteID", function ()
        {
            var _id = $(this).data("id");
             $("#delete #lblPatientCase").text(_id);
            $("#delete #HiddenFieldPatientCase").val(_id);
        }
        
        )

        $(function () {
            $('#DateAdmit').datetimepicker({
                format: 'YYYY-MM-DD'

            });
        });

        $(function () {
            $('#DateDischarge').datetimepicker({
                format: 'YYYY-MM-DD'
            });
        });

        $(function () {
            $('#dateCase').datetimepicker({ format: 'YYYY-MM-DD' });
        });
    </script>
</asp:Content>
