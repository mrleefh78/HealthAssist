<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="AppointmentDetail.aspx.cs" Inherits="HealthAssist.AppointmentDetail" EnableEventValidation="false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        Patient Appointment
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
                  <asp:HiddenField ID="AppointmentID" runat="server" />
                  <p>Patient Number</p>
                  <input id="PatientNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Patient Name" readonly/>
                  <p>Patient Name</p>
                  <input id="PatientName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Patient Name" readonly/>
                  <p>Date of Birth</p>
                  <input id="DOB" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Date of Birth" readonly/>
                  <p>Case No</p>
                  <input id="CaseNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Case No"/>
                 
              
                      
                 <p>Appointment Date</p>

                 <div class="form-group">
                        <div class='input-group date' id='DateAppointment'>
                          <input type='text' id ="AppointmentDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                   </div> 

                  <p>Appointment Type</p>
                  <asp:DropDownList ID="ddlAppointmentType" class="form-control mr-sm-2" runat="server">
                      <asp:ListItem Value="Regular Visit">Regular Visit</asp:ListItem>
                      <asp:ListItem>Patient Case</asp:ListItem>
                      </asp:DropDownList>

                   <p>Hospital Facility</p>
                  <asp:DropDownList ID="ddlHospital" class="form-control mr-sm-2" runat="server"></asp:DropDownList>

                 <p>Physician</p>
                  <asp:DropDownList ID="ddlPhysician" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                 
                 <p>Status</p>
                  <asp:DropDownList ID="ddlStatus" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                  <p>Remarks</p>
                   <textarea id="txtRemarks"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Remarks"></textarea><br />

                 
                  
                    <br /><br />
                      <button type="button" runat ="server" onserverclick="AddData"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="CloseData" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>

                       <button type="button" runat ="server" onserverclick="AddEncounter"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Create New Encounter</button>

                      <button type="button" id="btnConsent" runat ="server" onserverclick="PrintConsentForm"  class="btn btn-success" ><span class="glyphicon glyphicon-ok-sign"></span> Generate Consent</button>
                </form> 

              </div>
             <div class="col-md-3"> 
               
                 

                 
                  </div>
             <div class="col-md-2"> 

              </div>
         </div>
     </div>

      <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
      <script>
        $(document).ready(function ()
            {
            $('myTable').DataTable();
            }
        )

        $(function () {
            $('#DateAppointment').datetimepicker({
                format: 'YYYY-MM-DD'

            });
        });
      
        $('[id$="datetimepicker2"]').datetimepicker({
            format: 'dd/MM/yyyy hh:mm:ss',
            language: 'en',
            pick12HourFormat: true
        });
       
    </script>

   

</asp:Content>
