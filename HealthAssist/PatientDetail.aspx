<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="PatientDetail.aspx.cs" Inherits="HealthAssist.PatientDetail" EnableEventValidation="false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Patient
        <small>Detail</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active"><asp:Label ID="ActiveForm" runat="server" Text="Patient Register"></asp:Label></li>
      </ol>
    </section>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" style="margin: 0"> 
         <div class="row">  
          
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                  <asp:HiddenField ID="PatientID" runat="server" />
                  <p>Patient No.</p>
                  <input id="PatientNo" runat ="server"  class="form-control mr-sm-2" type="text" placeholder="Patient No" readonly/>
                  <p>Last Name</p>
                  <input id="LastName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Last Name"/>
                  <p>First Name</p>
                  <input id="FirstName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="First Name"/>
                  <p>Middle Name</p>
                  <input id="MiddleName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Middle Name"/>
                  <p>Gender</p>
                  <select id="Gender" runat="server" name="Gender" class="form-control mr-sm-2" >
                    <option value="Male">Male</option> 
                    <option value="Female">Female</option>
                                     
                  </select>
                  <p>Date of Birth</p>
                  <div class="form-group">
                        <div class='input-group date' id='DateBirth'>
                          <input type='text' id ="DOB" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                     </div> 

                    <p>Contact No</p>
                  <input id="Contact" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Contact"/>
                  <p>Email</p>
                  <input id="PatientEmail" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Email"/>              
                  
                  <p>Address</p>
                   <textarea id="txtAddress"  rows="5" cols="55" runat="server" maxlength="700" placeholder="Address"></textarea><br />
                    <br /><br />
                      <button type="button" runat ="server" onserverclick="AddPatient"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="ClosePatient" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                </form> 

              </div>
            
             <div class="col-md-6"> 
                 <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#tab_1" data-toggle="tab">Patient Insurance Detail</a></li>
              <li><a href="#tab_2" data-toggle="tab">Dependents</a></li>            
             
            </ul>
            <div class="tab-content">
              <div class="tab-pane active" id="tab_1">           
                  
            <div class="box-body">
                 <!-- vitals -->

                <div class="col-md-6"> 
                    <div class="form-group">
                        <label>Insurance Company</label>
                         <asp:DropDownList ID="ddlInsuranceCompany" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                    </div>

                     <div class="form-group">
                        <label>Policy No</label>
                        <input type="text" id="txtPolicyNo" runat ="server"  class="form-control" placeholder="Insurance Policy No" required>
                    </div>
                     <p>Start Date</p>
                  <div class="form-group">
                        <div class='input-group date' id='DateStart'>
                          <input type='text' id ="txtDateStart" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                     </div>
                     <p>Expiration Date</p>
                  <div class="form-group">
                        <div class='input-group date' id='DateExpire'>
                          <input type='text' id ="txtDateExpire" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                     </div>  
                    <div class="form-group">
                        <label>Membership Type</label>
                         <select id="MembershipType" runat="server" name="MembershipType" class="form-control mr-sm-2" >
                            <option value="Principal">Principal</option>
                            <option value="Dependent">Dependent</option>                   
                          </select>
                    </div>
                     <div class="form-group">
                        <label>Employee No</label>
                        <input type="text" id ="txtEmployeeNo" runat ="server"  class="form-control" placeholder="employee no" Required>
                    </div>
                     <div class="form-group">
                        <label>Company</label>
                        <input type="text" id ="txtCompany" runat ="server"  class="form-control" placeholder="company" Required>
                    </div>

                    <div class="form-group" >
                      <label>Remarks</label>
                      <textarea class="form-control" rows="3" id="Remarks" runat ="server" placeholder="other notes"></textarea>
                    </div>
                </div>
                
                 
            </div>
              </div>
              <!-- /.tab-pane -->
             <div class="tab-pane" id="tab_2">
                    
                 
                <asp:GridView ID="gvDependents" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Patient No" />
                              <asp:BoundField DataField="Description" HeaderText="Last Name" />
                               <asp:BoundField DataField="Notes" HeaderText="First Name" />
                               <asp:TemplateField>
                                <ItemTemplate>
                              <%-- <button type="button" id="deleteProcedureID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#deleteProcedure" data-id ='<%# Eval("id")%>'><span class="glyphicon glyphicon-remove"></span></button>--%>
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

           
                  <button type="button"  runat ="server" class="btn btn-primary" ><span class="glyphicon glyphicon-plus"></span> Add Dependent</button>
              </div>
            </div>
            <!-- /.tab-content -->
          </div>
              </div>
         </div>
     </div>

     <script>
        $(document).ready(function ()
            {
            $('myTable').DataTable();
            }
        )
      

        $(function () {
            $('#DateBirth').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });

        $(function () {
            $('#DateStart').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });

        $(function () {
            $('#DateExpire').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });

     
    </script>

     <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>
