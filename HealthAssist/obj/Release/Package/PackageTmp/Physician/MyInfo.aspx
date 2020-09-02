<%@ Page Title="" Language="C#" MasterPageFile="~/PhysicianMain.Master" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="HealthAssist.MyInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Profile
        <small>My Info</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active"><asp:Label ID="ActiveForm" runat="server" Text="My Info"></asp:Label></li>
      </ol>
    </section>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container-fluid" style="margin: 0"> 
         <div class="row">  
        
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                  <asp:HiddenField ID="PhysicianID" runat="server" />
                  <p>Last Name</p>
                  <input id="LastName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Last Name"/>
                  <p>First Name</p>
                  <input id="FirstName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="First Name"/>
                  <p>Specialty</p>
                  <input id="Specialty" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Specialty"/>
                  
                      <p>Contact No</p>
                  <input id="txtContact" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Contact"/>
                  <p>Email</p>
                  <input id="txtEmail" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Email"/>              
                  
                  <p>Address</p>
                   <textarea id="txtAddress"  rows="5" cols="60" runat="server" maxlength="600" placeholder="Address"></textarea><br />

                    <br /><br />
                      <button type="button" runat ="server" onserverclick="AddData"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                     
                </form> 

              </div>
             <div class="col-md-3"> 
               
                  <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addPhysicianFacility"><span class="glyphicon glyphicon-plus"></span> Add</button>
                    
                       <asp:GridView ID="gvFacility" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="gvFacility_PageIndexChanging" Width="100%" CssClass="table table-striped">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="ID" HeaderText="ID" />
                              <asp:BoundField DataField="FacilityName" HeaderText="Facility Name" />
                                <asp:TemplateField>
                                <ItemTemplate>
                                     <button type="button" id="deleteFacilityID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#deletePhysicianFacility" data-id ='<%# Eval("id")%>'><span class="glyphicon glyphicon-remove"></span></button>
                                </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>
                          <EditRowStyle BackColor="#999999" />
                          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#E9E7E2" />
                          <SortedAscendingHeaderStyle BackColor="#506C8C" />
                          <SortedDescendingCellStyle BackColor="#FFFDF8" />
                          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                      </asp:GridView>
              
              </div>
             <div class="col-md-2"> 

              </div>
         </div>

          <!-- Physician --> 

    <div class="modal fade" id="deletePhysicianFacility" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="FacilityHeading">Reason for deletion </h4>
      </div>
          <div class="modal-body">
          <div class="form-group">
         <p> Are you sure to delete physician facility <asp:Label ID="lblPhysicianFacility" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldPhysicianFacility" ClientIDMode ="Static" runat="server" />
        <textarea id="deletePhysicianFacilityReason"  rows="4" cols="75" runat="server" maxlength="500" placeholder="reason"></textarea><br /><br />
              
        </div>
       
      </div>
          <div class="modal-footer ">
          <asp:Button ID="deletePhysicianFacilityButton" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="DeletePhysicianFacility_ServerClick"/>
              <button type="button" id="closebutton" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
    </div>

    <div  class="modal fade" id="addPhysicianFacility" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="AddMedicationHeading">Add Physician Facility </h4>
      </div>
         <div class="modal-body">
          <div class="form-group">
                   <p>Health Facility</p>
                       <asp:DropDownList ID="ddlHospitalName" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
        </div>
       
      </div>
        <div class="modal-footer ">
          <input type="button" id="addPhysicianFacilityButton" runat="server" class="btn btn-primary" onserverclick="AddPhysicianFacility_ServerClick" value="OK" />
            <button type="button" id="closemedbut" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> Cancel</button>
      </div>
        </div>
    <!-- /.modal-content --> 
  </div>
      <!-- /.modal-dialog --> 
    </div>
     </div>
</asp:Content>
