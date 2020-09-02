<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="PatientEncounterDetail.aspx.cs" Inherits="HealthAssist.PatientEncounterDetail" EnableEventValidation="false"%>
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
                   <select id="ServiceType" runat="server" name="ServiceType" class="form-control mr-sm-2" >
                    <option value="OPD">OPD</option> 
                    <option value="IPD">IPD</option>
                                     
                  </select>
                 
                   <p>Physician</p>
                   <asp:DropDownList ID="ddlPhysician" class="form-control mr-sm-2" runat="server" OnSelectedIndexChanged="PhysicianRate" AutoPostBack="true"></asp:DropDownList>   

                    <p>Consultation Rate</p>
                  <input id="txRate" runat ="server" class="form-control mr-sm-2" type="text" placeholder="rate" readonly/>
                 

                 
                   <p>Status</p>
                       <asp:DropDownList ID="ddlStatus" class="form-control mr-sm-2" runat="server" Enabled ="false" Width="100%" ></asp:DropDownList>
                     </form> 
                      
                      
                      <br /><br />
                      <button type="button" runat ="server" id="btnSave" onserverclick="AddPatientEncounter" class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="ClosePatientCase" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                        <button type="button" runat ="server"  id="btnSaveDoctor" onserverclick="AddPatientEncounter" class="btn btn-info" ><span class="glyphicon glyphicon-ok-sign"></span> Save and Send To Doctor</button>
                      <br />
                       <br />
                       <button type="button" runat ="server" id="btnMedCertificate" onserverclick="PrintMedCertificate" class="btn btn-success" ><span class="glyphicon glyphicon-file"></span> Medical Certificate</button>
                        <button type="button" runat ="server" id="btnPrescription" onserverclick="PrinPrescription" class="btn btn-success" ><span class="glyphicon glyphicon-file"></span> Prescription</button>
              
                </form> 

              </div>
             <div class="col-md-8"> 
           
              <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#tab_1" data-toggle="tab">Patient Assessment</a></li>
              <li><a href="#tab_2" data-toggle="tab">Physician Orders</a></li>
              <li><a href="#tab_3" data-toggle="tab">Medications</a></li>
              <li><a href="#tab_4" data-toggle="tab">Encounter Status Log</a></li>
             
            </ul>
            <div class="tab-content">
              <div class="tab-pane active" id="tab_1">           
                  
            <div class="box-body">
                 <!-- vitals -->

                <div class="col-md-6"> 
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
                  <label>Chief Complaint</label>
                  <textarea class="form-control" rows="6" id="txtCC" runat ="server" placeholder="Enter reasons for encounter"></textarea>
                </div>

                 <div class="form-group" >
                  <label>Remarks</label>
                  <textarea class="form-control" rows="3" id="Remarks" runat ="server" placeholder="other notes"></textarea>
                </div>
            </div>
              </div>
              <!-- /.tab-pane -->
              <div class="tab-pane" id="tab_2">
                    
                 
                <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnOrdersPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
                               <asp:BoundField DataField="Notes" HeaderText="Doctor Notes" />
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

           
                  <button type="button"  runat ="server" onserverclick ="ExportOrdersToPDF"  class="btn btn-success" ><span class="glyphicon glyphicon-print"></span> Print</button>
              </div>
              <!-- /.tab-pane -->
              <div class="tab-pane" id="tab_3">
               
               <asp:GridView ID="gvPrescription" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnMedsPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Code" />
                              <asp:BoundField DataField="Description" HeaderText="Description" />
                              <asp:BoundField DataField="Dosage" HeaderText="Prescription" />
                              <asp:BoundField DataField="Notes" HeaderText="Doctor Notes" />
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

                  
                   <button type="button"  runat ="server" onserverclick ="ExportMedsToPDF" class="btn btn-success" ><span class="glyphicon glyphicon-print"></span> Print</button>
              </div>
              <!-- /.tab-pane -->
            <div class="tab-pane" id="tab_4">
               
               <asp:GridView ID="gvEncounterLog" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnLogPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="LogDate" HeaderText="Date" />
                              <asp:BoundField DataField="Status" HeaderText="Status" />
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

                  
              </div>
            </div>
            <!-- /.tab-content -->
          </div>
                 
              </div>

             <div class="col-md-2"> 

              </div>
         </div>
           
        <br />

    

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
     
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>