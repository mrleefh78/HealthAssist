<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="HealthAssist.Clients" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Insurance
        <small>Providers</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active"><asp:Label ID="ActiveForm" runat="server" Text="Insurance Company"></asp:Label></li>
      </ol>
    </section>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin: 0">
         <div class="row">  
             <div class="col-md-1"> 
             </div>
             <div class="col-md-6"> 
               <button type="button" runat ="server" onserverclick="AddClick"  class="btn btn-primary" ><span class="glyphicon glyphicon-plus"></span> Add</button>
      
             </div>
             <div class="col-md-2"> 
                 <form class="form-inline my-2 my-lg-0">
                   <input class="form-control mr-sm-2" type="text" id="searchKeyword"  runat ="server" placeholder="Search">
                 
                </form> 
             </div>
             <div class="col-md-2"> 
                  <button class="btn btn-secondary my-2 my-sm-0" type="submit" runat ="server" onserverclick="SearchClick" >Search</button>
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
            <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="gvList_PageIndexChanging" Width="100%" CssClass="table table-striped" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
               
                <asp:BoundField DataField="ID" HeaderText="ID">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="100px" />
                </asp:BoundField>
              
                <asp:BoundField DataField="Code" HeaderText="Business Code">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
            
                <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                  <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="CountryName" HeaderText="Country" />
              

                <asp:TemplateField>
                    <ItemTemplate>
                       
                        <button type="button" id="updateButton" title="Edit" data-id ='<%# Eval("id")%>' onserverclick="UpdateClick"  runat ="server"  class="btn btn-success btn-xs" data-toggle="modal" data-target="#edit"><span class="glyphicon glyphicon-edit"></span></button>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <button type="button" id="deleteID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal"  data-target="#delete" data-id ='<%# Eval("id")%>' ><span class="glyphicon glyphicon-remove"></span></button>
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
         <p> Are you sure to delete insurance provider <asp:Label ID="lblSelectedItem" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldItem" ClientIDMode ="Static" runat="server" />
        <textarea id="itemname"  rows="4" cols="75" runat="server" maxlength="500" placeholder="reason"></textarea><br /><br />
              
        </div>
       
      </div>
          <div class="modal-footer ">
                <asp:Button ID="btnOk" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="Ok_ServerClick"/>
         <button type="button" id="closebutupdate" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
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
            $("#delete #itemname").val(_id);
            $("#delete #lblSelectedItem").text(_id);
            $("#delete #HiddenFieldItem").val(_id);
        }
        
        )
    </script>
</asp:Content>
