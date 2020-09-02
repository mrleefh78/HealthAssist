<%@ Page Title="" Language="C#" MasterPageFile="~/PhysicianMain.Master" AutoEventWireup="true" CodeBehind="MyPatientDetail.aspx.cs" Inherits="HealthAssist.MyPatientDetail" EnableEventValidation="false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Patient Encounter
        <small>Detail</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="Dashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active"><asp:Label ID="ActiveForm" runat="server" Text="Patient Encounter"></asp:Label></li>
      </ol>
    </section>

    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin: 0"> 
         <div class="row">  
             
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                   <asp:HiddenField ID="EncounterID" runat="server" />
                 
                   <p>Encounter No.</p>
                  <input id="EncounterNo" runat ="server"  class="form-control mr-sm-2" type="text" placeholder="Encounter No" readonly/>
                   <p>Date</p>
                     <input id="EncounterDate" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Encounter Date" readonly/>
                    
                  <p>Patient Number</p>
                  <input id="PatientNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Patient No" readonly/>
                  <p>Patient Name</p>
                  <input id="PatientName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Patient Name" readonly/>
                  <p>Date of Birth</p>
                  <input id="DOB" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Date of Birth" readonly/>
                  <p>Insurance Company</p>
                      <asp:DropDownList ID="ddlCompany" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                 
                       <p>Insurance No</p>
                  <input id="InsuranceNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Insurance No"/>
                 <%-- <p>Health Facility</p>
                       <asp:DropDownList ID="ddlHospitalName" class="form-control mr-sm-2" runat="server"></asp:DropDownList>--%>
                
                <form class="form-inline my-2 my-lg-0">
                   <p>Type of Service</p>
                   <select id="ServiceType" runat="server" name="ServiceType" class="form-control mr-sm-2" readonly>
                    <option value="IPD">IPD</option>
                    <option value="OPD">OPD</option>                   
                  </select>

                                   
                   <p>Physician</p>
                   <asp:DropDownList ID="ddlPhysician" class="form-control mr-sm-2" runat="server" Enabled ="false"  readonly ></asp:DropDownList>   
                                     
                 
                   <p>Status</p>
                       <asp:DropDownList ID="ddlStatus" class="form-control mr-sm-2" runat="server" Enabled ="false" readonly ></asp:DropDownList>
                     </form> 
                      
                      
                      <br /><br />
                      <button type="button" runat ="server" onserverclick="AddPatientEncounter" class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="ClosePatientCase" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                       <button type="button"  runat ="server" onserverclick="CompletePatientEncounter" class="btn btn-success" ><span class="glyphicon glyphicon-ok-sign"></span> Save and Complete</button>

              
                </form> 

              </div>
             <div class="col-md-8"> 
           
              <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#tab_1" data-toggle="tab">Patient Assessment</a></li>
                <li><a href="#tab_2" data-toggle="tab">Diagnosis</a></li>
              <li><a href="#tab_3" data-toggle="tab">Laboratory/Radiology Orders</a></li>
              <li><a href="#tab_4" data-toggle="tab">Medications</a></li>
             
            </ul>
            <div class="tab-content">
              <div class="tab-pane active" id="tab_1">           
                  
            <div class="box-body">
                 <!-- vitals -->

                <div class="col-md-6"> 
                     <asp:HiddenField ID="hfVitalsID" runat="server" />
                    <div class="form-group">
                        <label>Temperature</label>
                        <input type="number" id ="txtTemperature" runat ="server"  class="form-control" placeholder="temperature" required>
                    </div>

                     <div class="form-group">
                        <label>Blood Pressure (systolic)</label>
                        <input type="number" id="txtSystolic" runat ="server"  class="form-control" placeholder="systolic" required>
                    </div>
                    <div class="form-group">
                        <label>Blood Pressure (diastolic)</label>
                        <input type="number" id ="txtDiastolic" runat ="server"  class="form-control" placeholder="diastolic" Required>
                    </div>
                     <div class="form-group">
                        <label>Blood Sugar (mg/dl)</label>
                        <input type="number" id ="txtBloodSugar" runat ="server"  class="form-control" placeholder="blood sugar" Required>
                    </div>
                </div>

                  <div class="col-md-6"> 
                    <div class="form-group">
                        <label>Pulse Rate</label>
                        <input type="number" id="txtPulseRate" runat ="server" class="form-control" placeholder="pulse rate" required>
                    </div>
                     <div class="form-group">
                        <label>Height (Ft)</label>
                        <input type="number" id="txtHeight" runat ="server" class="form-control" placeholder="height" required>
                    </div>
                     <div class="form-group">
                        <label>Weight (Kls)</label>
                        <input type="number" id ="txtWeight" runat ="server" class="form-control" placeholder="weight" required>
                    </div>

                     <div class="form-group">
                        <label>Other</label>
                        <input type="text" id ="txtOther" runat ="server"  class="form-control" placeholder="other detail" Required>
                    </div>

                </div>
              
                <!-- cc -->
                <div class="form-group" >
                  <asp:HiddenField ID="hfAssessmentID" runat="server" />
                  <label>Chief Complaint</label>
                  <textarea class="form-control" rows="6" id="txtCC" runat ="server" placeholder="Enter reasons for encounter"></textarea>
                </div>

                 <div class="form-group" >
                  <label>History of Present Illness (HPI)</label>
                  <textarea class="form-control" rows="6" id="txtHPI" runat ="server" placeholder="Enter History of Present Illness"></textarea>
                </div>

                 <div class="form-group" >
                  <label>Review of System (ROS)</label>
                  <textarea class="form-control" rows="6" id="txtROS" runat ="server" placeholder="Enter Review of System"></textarea>
                </div>

                <div class="form-group" >
                  <label>Past Family Social and Surgical History(PFSH)</label>
                  <textarea class="form-control" rows="6" id="txtPFSC" runat ="server" placeholder="Enter Past Family Social and Surgical History"></textarea>
                </div>

                 <div class="form-group" >
                  <label>Physical Exam</label>
                  <textarea class="form-control" rows="6" id="txtPhysicalExam" runat ="server" placeholder="Enter physical examination note"></textarea>
                </div>

                 <div class="form-group" >
                  <label>Physician Note</label>
                  <textarea class="form-control" rows="6" id="txtDoctorNote" runat ="server" placeholder="Enter doctor's note"></textarea>
                </div>

                 <div class="form-group" >
                  <label>Remarks</label>
                  <textarea class="form-control" rows="3" id="Remarks" runat ="server" placeholder="other notes"></textarea>
                </div>
            </div>
              </div>
                <!-- /.tab-pane -->
              <div class="tab-pane" id="tab_2">
                    
                 <div class="form-group">
                    <p>ICD Code</p>
                    <asp:DropDownList ID="ddlICD" class="form-control mr-sm-2" runat="server"  readonly></asp:DropDownList><br />   
                    <input id="ICDCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
                    <p>Description</p>
                    <textarea id="ICDDesc"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Description"></textarea><br />
                 
                </div>

                <button type="button" runat ="server"  class="btn btn-primary" onserverclick="AddDiagnosis_ServerClick" ><span class="glyphicon glyphicon-plus" ></span> Add</button>
                 
                <asp:GridView ID="gvDiagnosis" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnOrdersPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
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

           
                 <%--  <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addDiagnosis" ><span class="glyphicon glyphicon-plus" ></span> Add</button>--%>
              </div>
              <!-- /.tab-pane -->
              <div class="tab-pane" id="tab_3">
                    
                 <div class="form-group">
                    <p>CPT Code</p>
                    <asp:DropDownList ID="ddlCpt" class="form-control mr-sm-2" runat="server"  readonly></asp:DropDownList><br />   
                    <input id="CPTCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
                    <p>Description</p>
                    <textarea id="CPTDesc"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Description"></textarea><br />
                 
                </div>

                   <button type="button" runat ="server"  class="btn btn-primary" onserverclick="AddProcedure_ServerClick"><span class="glyphicon glyphicon-plus"></span> Add</button>

                <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnOrdersPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
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

           
                 <%-- <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addProcedure"><span class="glyphicon glyphicon-plus"></span> Add</button>--%>
              </div>
              <!-- /.tab-pane prescription -->
              <div class="tab-pane" id="tab_4">

                  <div class="input-group input-group-sm">
                <input type="text" class="form-control">
                    <span class="input-group-btn">
                      <button type="button" class="btn btn-info btn-flat">Go!</button>
                    </span>                       

              </div>
                               

                  

                    <div class="form-group">
                    <p>Medication</p> 
                          <asp:DropDownList ID="myDropDownlistID" runat="server"></asp:DropDownList>
                           <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#searchMedication"><span class="glyphicon glyphicon-plus"></span> Search Medicine</button>                     
                    <input id="MedCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
                    <p>Description</p>
                    <textarea id="MedDescription"  rows="5" cols="150" runat="server" maxlength="700" placeholder="Description"></textarea><br />
                    <p>Prescription</p>
                    <asp:DropDownList ID="ddlPrescriptionTemplate" class="form-control mr-sm-2" runat="server" onchange="onPrescriptionTemplateChange();" readonly></asp:DropDownList><br />   
                     <textarea id="Prescription"  rows="5" cols="150" runat="server" maxlength="700" placeholder="Prescription"></textarea><br />
                       <asp:CheckBox ID="cbFavorite" runat="server" Text="Add to favorites" />
                </div>

                     <button type="button" runat ="server"  class="btn btn-primary" onserverclick="AddMedication_ServerClick" href="#tab_4" data-toggle="tab"><span class="glyphicon glyphicon-plus"></span> Add</button>
               
               <asp:GridView ID="gvPrescription" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnMedsPageIndexChanging">
                        
                 
                   
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
                              <asp:BoundField DataField="Dosage" HeaderText="Prescription" />
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

                  
                 <%--  <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addMedication"><span class="glyphicon glyphicon-plus"></span> Add</button>--%>
                
              </div>
              <!-- /.tab-pane -->
            </div>
            <!-- /.tab-content -->
          </div>
                 
              </div>
             <div class="col-md-2"> 

              </div>
         </div>
           
        <br />
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
        <h4 class="modal-title custom_align" id="AddMedicationHeading">Add Medication </h4>
      </div>
         <div class="modal-body">
          <div class="form-group">
                    <p>Medication Code</p>
                  <input id="txtMedCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
              <p>Description</p>
                   <textarea id="txtMedDescription"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Description"></textarea><br />
              <p>Prescription</p>
                  <input id="txtMedDose" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Prescription"/>  
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

        <div  class="modal fade" id="searchMedication" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="SearchMedicationHeading">Search and Select Medication </h4>
      </div>
         <div class="modal-body">
          <div class="form-group">
                    <p>Medicine</p>
                  <input id="SearchMed" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/> 
               <asp:CheckBoxList ID="cbMedList" runat="server" RepeatColumns ="2"></asp:CheckBoxList>
            
        </div>
       
      </div>
        <div class="modal-footer ">
          <input type="button" id="Button1" runat="server" class="btn btn-primary" onserverclick="AddMedication_ServerClick" value="OK" />
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
                format: 'YYYY-MM-DD'
               
            });

            $('.select2').select2()
        });

        $(function () {
            $('#DateDischarge').datetimepicker({
                format: 'YYYY-MM-DD'
            });
        });

        $(function () {
            $('#dateCase').datetimepicker({ format: 'YYYY-MM-DD' });
        });

        function onPrescriptionTemplateChange() {
          var ddlvalue = $("#<%= ddlPrescriptionTemplate.ClientID %> option:selected").val(); // use the ClientID from the ddCategory dropdown
            var textBox = document.getElementById('<%= Prescription.ID%>');
               
           textBox.innerText = ddlvalue.options[ddlvalue.selectedIndex].text;
           // textBox.value = ddlvalue.text;
        }

        function onSelectedTab() {
            var activeTab =$("#")
        }

        $("#dropdownid").change(function () {
            alert($(this).find("option:selected").text());
        });

        $('#yourdropdownid').find('option:selected').text();

        $(document).ready(function () { $("#myDropDownlistID").select2(); });
       
        $(function () { $("#myDropDownlistID2").select2(); });

    </script>

    <script>
  $(function () {
    //Initialize Select2 Elements
    $('.select2').select2()

    //Datemask dd/mm/yyyy
    $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    //Datemask2 mm/dd/yyyy
    $('#datemask2').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' })
    //Money Euro
    $('[data-mask]').inputmask()

    //Date range picker
    $('#reservation').daterangepicker()
    //Date range picker with time picker
    $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, locale: { format: 'MM/DD/YYYY hh:mm A' }})
    //Date range as a button
    $('#daterange-btn').daterangepicker(
      {
        ranges   : {
          'Today'       : [moment(), moment()],
          'Yesterday'   : [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
          'Last 7 Days' : [moment().subtract(6, 'days'), moment()],
          'Last 30 Days': [moment().subtract(29, 'days'), moment()],
          'This Month'  : [moment().startOf('month'), moment().endOf('month')],
          'Last Month'  : [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        startDate: moment().subtract(29, 'days'),
        endDate  : moment()
      },
      function (start, end) {
        $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'))
      }
    )

    //Date picker
    $('#datepicker').datepicker({
      autoclose: true
    })

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
      checkboxClass: 'icheckbox_minimal-blue',
      radioClass   : 'iradio_minimal-blue'
    })
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
      checkboxClass: 'icheckbox_minimal-red',
      radioClass   : 'iradio_minimal-red'
    })
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
      checkboxClass: 'icheckbox_flat-green',
      radioClass   : 'iradio_flat-green'
    })

    //Colorpicker
    $('.my-colorpicker1').colorpicker()
    //color picker with addon
    $('.my-colorpicker2').colorpicker()

    //Timepicker
    $('.timepicker').timepicker({
      showInputs: false
    })
  })
</script>

               <!-- Select2 -->
<script src="../AdminLTE/bower_components/select2/dist/js/select2.full.min.js"></script>
<script src="../AdminLTE/bower_components/jquery/dist/jquery.min.js"></script>

<!-- Bootstrap 3.3.7 -->
<script src="../AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
   

</asp:Content>