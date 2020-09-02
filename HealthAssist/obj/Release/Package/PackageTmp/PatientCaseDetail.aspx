<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="PatientCaseDetail.aspx.cs" Inherits="HealthAssist.PatientCaseDetail" EnableEventValidation="false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Patient Case
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
              <div class="col-md-2"> 
                 
              </div>
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                       <asp:HiddenField ID="CaseID" runat="server" />
                  <p>Reference No.</p>
                  <input id="RefNo" runat ="server"  class="form-control mr-sm-2" type="text" placeholder="Case No"/>
                   <p>Date</p>
                  <div class='input-group date' id='dateCase'>
                          <input type='text' id ="CaseDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                       </div>
                  <p>Patient Number</p>
                  <input id="PatientNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Patient Name"/>
                  <p>Patient Name</p>
                  <input id="PatientName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Patient Name" />
                  <p>Date of Birth</p>
                  <input id="DOB" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Date of Birth"/>
                  <p>Assistance Company</p>
                      <asp:DropDownList ID="ddlCompany" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                       <p>Insurance No</p>
                  <input id="InsuranceNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Insurance No"/>
                  <p>Health Facility</p>
                       <asp:DropDownList ID="ddlHospitalName" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                <br /><br />
                      <button type="button" runat ="server" onserverclick="AddPatientCase" class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="ClosePatientCase" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
              
                </form> 

              </div>
             <div class="col-md-3"> 
                 <form class="form-inline my-2 my-lg-0">
                   <p>Type of Service</p>
                   <select id="ServiceType" runat="server" name="ServiceType" class="form-control mr-sm-2" >
                    <option value="IPD">IPD</option>
                    <option value="OPD">OPD</option>                   
                  </select>
                  <p>Date Admitted</p>
                   <div class="form-group">
                        <div class='input-group date' id='DateAdmit'>
                          <input type='text' id ="AdmitDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                     </div>           
                  <p>Date Discharged</p>
                  <div class="form-group">
                      <div class='input-group date' id='DateDischarged'>
                          <input type='text' id ="DischargeDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                     </div>  
                   <p>Physician</p>
                   <asp:DropDownList ID="ddlPhysician" class="form-control mr-sm-2" runat="server"></asp:DropDownList>                
                </form> 

                   <p>Remarks</p>
                   <textarea id="Remarks"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Remarks"></textarea><br />
                   <p>Status</p>
                       <asp:DropDownList ID="ddlStatus" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                  </div>
             <div class="col-md-2"> 

              </div>
         </div>
           
        <br />

        <div class="row">
             <div class="col-md-2"> 
                
            </div>
          
                <div class="col-md-8"> 
                 <div class="jumbotron"> 
                        
                  <ul class="nav nav-tabs">
                      <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#diagnosis">Diagnosis</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#procedures">Procedures</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#medications">Medications</a>
                      </li>
                 
                </ul>
                 <div id="myTabContent" class="tab-content">
                  <div class="tab-pane fade show active" id="diagnosis">  
                       <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addDiagnosis" ><span class="glyphicon glyphicon-plus" ></span> Add</button>
                     <asp:GridView ID="gvDiagnosis" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="gvDiagnosis_PageIndexChanging" Width="100%" CssClass="table table-striped">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <button type="button" id="deleteDiagnosisID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#deleteDiagnosis" data-id ='<%# Eval("id")%>'><span class="glyphicon glyphicon-remove"></span></button>
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

                  <div class="tab-pane fade show active" id="procedures">  
                        <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addProcedure"><span class="glyphicon glyphicon-plus"></span> Add</button>
                                                    
                        <asp:GridView ID="gvProcedure" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="gvProcedure_PageIndexChanging" Width="100%" CssClass="table table-striped">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
                               <asp:TemplateField>
                                <ItemTemplate>
                               <button type="button" id="deleteProcedureID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#deleteProcedure" data-id ='<%# Eval("id")%>'><span class="glyphicon glyphicon-remove"></span></button>
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

                  <div class="tab-pane fade" id="medications">
                       <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addMedication"><span class="glyphicon glyphicon-plus"></span> Add</button>
                    
                       <asp:GridView ID="gvMedications" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="gvMedication_PageIndexChanging" Width="100%" CssClass="table table-striped">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
                               <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                               <asp:TemplateField>
                                <ItemTemplate>
                                     <button type="button" id="deleteMedicationID" title="Delete" class="btn btn-danger btn-xs"data-toggle="modal" data-target="#deleteMedication" data-id ='<%# Eval("id")%>'><span class="glyphicon glyphicon-remove"></span></button>
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
                 
                </div>
                </div>

               
            </div>
         
        </div>

         

    <!-- Diagnosis --> 

    <div class="modal fade" id="deleteDiagnosis" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading1">Reason for deletion </h4>
      </div>
          <div class="modal-body">
          <div class="form-group">
         <p> Are you sure to delete patient diagnosis <asp:Label ID="lblPatientDiagnosis" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldPatientDiagnosis" ClientIDMode ="Static" runat="server" />
        <textarea id="itemname"  rows="4" cols="75" runat="server" maxlength="500" placeholder="reason"></textarea><br /><br />
              
        </div>
       
      </div>
          <div class="modal-footer ">
          <%--<input type="button" id="btnsubmit" runat="server" onserverclick="DeleteDiagnosis_ServerClick" class="btn btn-primary"  value="Save" />--%>
          <asp:Button ID="btnOk" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="DeleteDiagnosis_ServerClick"/>
              <button type="button" id="closebutupdate" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
    </div>

    <div  class="modal fade" id="addDiagnosis" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading">Add Diagnosis </h4>
      </div>
         <div class="modal-body">
          <div class="form-group">
                    <p>ICD Code</p>
                  <input id="txtICDCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
              <p>Description</p>
                   <textarea id="txtICDDescription"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Description"></textarea><br />
        </div>
       
      </div>
        <div class="modal-footer ">
          <input type="button" id="saveDiagnosis" runat="server" class="btn btn-primary" onserverclick="AddDiagnosis_ServerClick" value="OK" />
            <button type="button" id="closebut" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> Cancel</button>
      </div>
        </div>
    <!-- /.modal-content --> 
  </div>
      <!-- /.modal-dialog --> 
    </div>

         <!-- Procedure --> 

    <div class="modal fade" id="deleteProcedure" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading2">Reason for deletion </h4>
      </div>
          <div class="modal-body">
          <div class="form-group">
         <p> Are you sure to delete patient procedure <asp:Label ID="lblPatientProcedure" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldPatientProcedure" ClientIDMode ="Static" runat="server" />
        <textarea id="deleteCPTReason"  rows="4" cols="75" runat="server" maxlength="500" placeholder="reason"></textarea><br /><br />
              
        </div>
       
      </div>
          <div class="modal-footer ">
          <asp:Button ID="deleteProcedureButton" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="DeleteProcedure_ServerClick"/>
              <button type="button" id="closeProcedureupdate" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
    </div>

    <div  class="modal fade" id="addProcedure" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="AddProcedureHeading">Add Procedure </h4>
      </div>
         <div class="modal-body">
          <div class="form-group">
                    <p>CPT Code</p>
                  <input id="txtCPTCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
              <p>Description</p>
                   <textarea id="txtCPTDescription"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Description"></textarea><br />
        </div>
       
      </div>
        <div class="modal-footer ">
          <input type="button" id="addProcedureButton" runat="server" class="btn btn-primary" onserverclick="AddProcedure_ServerClick" value="OK" />
            <button type="button" id="closecptbut" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> Cancel</button>
      </div>
        </div>
    <!-- /.modal-content --> 
  </div>
      <!-- /.modal-dialog --> 
    </div>

            <!-- Medication --> 

    <div class="modal fade" id="deleteMedication" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="MedicationHeading">Reason for deletion </h4>
      </div>
          <div class="modal-body">
          <div class="form-group">
         <p> Are you sure to delete patient medication <asp:Label ID="lblPatientMedication" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldPatientMedication" ClientIDMode ="Static" runat="server" />
        <textarea id="deleteMedicationReason"  rows="4" cols="75" runat="server" maxlength="500" placeholder="reason"></textarea><br /><br />
              
        </div>
       
      </div>
          <div class="modal-footer ">
          <asp:Button ID="deleteMedicationButton" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="DeleteMedication_ServerClick"/>
              <button type="button" id="closeMedicationupdate" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
    </div>

    <div  class="modal fade" id="addMedication" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="AddMedicationHeading">Add Procedure </h4>
      </div>
         <div class="modal-body">
          <div class="form-group">
                    <p>Medication Code</p>
                  <input id="txtMedCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
              <p>Description</p>
                   <textarea id="txtMedDescription"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Description"></textarea><br />
              <p>Medication Dosage</p>
                  <input id="txtMedDose" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Dosage"/>  
        </div>
       
      </div>
        <div class="modal-footer ">
          <input type="button" id="addMedicationButton" runat="server" class="btn btn-primary" onserverclick="AddMedication_ServerClick" value="OK" />
            <button type="button" id="closemedbut" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> Cancel</button>
      </div>
        </div>
    <!-- /.modal-content --> 
  </div>
      <!-- /.modal-dialog --> 
    </div>

     </div>

    <script>
        $(document).ready(function ()
            {
            $('myTable').DataTable();
            }
        )
        $(document).on("click", "#deleteDiagnosisID", function ()
        {
            var _id = $(this).data("id");
            $("#deleteDiagnosis #lblPatientDiagnosis").text(_id);
            $("#deleteDiagnosis #HiddenFieldPatientDiagnosis").val(_id);
        }        
        )

        $(document).on("click", "#deleteProcedureID", function () {
            var _id = $(this).data("id");
            $("#deleteProcedure #lblPatientProcedure").text(_id);
            $("#deleteProcedure #HiddenFieldPatientProcedure").val(_id);
        }
       )

        $(document).on("click", "#deleteMedicationID", function () {
            var _id = $(this).data("id");
            $("#deleteMedication #lblPatientMedication").text(_id);
            $("#deleteMedication #HiddenFieldPatientMedication").val(_id);
        }
      )

        $(function () {
            $('#DateAdmit').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });

        $(function () {
            $('#DateDischarge').datetimepicker({
               // format: 'YYYY-MM-DD'
            });
        });

        $(function () {
           // $('#dateCase').datetimepicker({ format: 'YYYY-MM-DD' });
        });
    </script>

     <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>
