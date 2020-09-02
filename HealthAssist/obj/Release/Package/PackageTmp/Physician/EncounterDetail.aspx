<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncounterDetail.aspx.cs" Inherits="HealthAssist.EncounterDetail" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>HealthAssist | e-Consult</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/Ionicons/css/ionicons.min.css">
  <!-- daterange picker -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/bootstrap-daterangepicker/daterangepicker.css">
  <!-- bootstrap datepicker -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
  <!-- iCheck for checkboxes and radio inputs -->
  <link rel="stylesheet" href="../AdminLTE/plugins/iCheck/all.css">
  <!-- Bootstrap Color Picker -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css">
  <!-- Bootstrap time Picker -->
  <link rel="stylesheet" href="../AdminLTE/plugins/timepicker/bootstrap-timepicker.min.css">
  <!-- Select2 -->
  <link rel="stylesheet" href="../AdminLTE/bower_components/select2/dist/css/select2.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../AdminLTE/dist/css/AdminLTE.min.css">
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href="../AdminLTE/dist/css/skins/_all-skins.min.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition skin-blue sidebar-mini">
<div class="wrapper">

  <header class="main-header">
    <!-- Logo -->
    <a href="../../index2.html" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>A</b>LT</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>HealthAssist</b> </span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </a>

      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
                  
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <img src="../AdminLTE/dist/img/user2-160x160.jpg" class="user-image" alt="User Image">
              <span class="hidden-xs">
                <asp:Label ID="UserFullNameSide" runat="server" Text="Label"></asp:Label>

              </span>
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              <li class="user-header">
                <img src="../AdminLTE/dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">

                <p>
                 <asp:Label ID="UserFullName" runat="server" Text="Label"></asp:Label> 
                  <small><asp:Label ID="UserSpecialty" runat="server" Text="Label"></asp:Label> Physician</small>
                    
                </p>
              </li>
              <!-- Menu Body -->
              <li class="user-body">
                
                <!-- /.row -->
              </li>
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-left">
                  <a href="profile.aspx" class="btn btn-default btn-flat">Profile</a>
                </div>
                <div class="pull-right">
                  <a href="../login.aspx" class="btn btn-default btn-flat">Sign out</a>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li>
            <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
          </li>
        </ul>
      </div>
    </nav>
  </header>
  <!-- Left side column. contains the logo and sidebar -->
  <aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <!-- Sidebar user panel -->
      <div class="user-panel">
        <div class="pull-left image">
          <img src="../AdminLTE/dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
        </div>
        <div class="pull-left info">
          <p><asp:Label ID="UserFullNameMain" runat="server" Text="Label"></asp:Label></p>
          <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
        </div>
      </div>
     
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">MAIN NAVIGATION</li>
        <li><a href="EncounterList.aspx?View=Pending"><i class="fa fa-circle-o text-red"></i> <span>Active Patients</span></a></li>
        <li><a href="EncounterList.aspx?View=All"><i class="fa fa-circle-o text-yellow"></i> <span>All Patients</span></a></li>
        <li><a href="Profile.aspx"><i class="fa fa-circle-o text-aqua"></i> <span>My Profile</span></a></li>
          <li><a href="../login.aspx"><i class="fa fa-circle-o text-aqua"></i> <span>Sign Out</span></a></li>
      </ul>
    </section>
    <!-- /.sidebar -->
  </aside>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Encounter
        <small>Detail</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="Profile.aspx">Forms</a></li>
        <li class="active">My Profile</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <form id="form1" runat="server">

       
     <div class="box box-default collapsed-box">
        <div class="box-header with-border">
          <h3 class="box-title"><asp:Label ID="PatientNameValue" runat="server" Text="Label"></asp:Label></h3>

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
            
           <%-- <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
          </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body">
          <div class="row">
            <div class="col-md-6">
              <asp:HiddenField ID="EncounterID" runat="server" />
              <div class="form-group">
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
              </div>
              <!-- /.form-group -->
              
              <!-- /.form-group -->
            </div>
            <!-- /.col -->
            <div class="col-md-6">
              
             <div class="form-group">
                 <p>Insurance Company</p>
                   <input id="Insurance" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Insurance" readonly/>  
                  
                  <p>Insurance No</p>
                    <input id="InsuranceNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Insurance No"/>
                   <p>Type of Service</p>
                   <input id="ServiceType" runat ="server" class="form-control mr-sm-2" type="text" placeholder="ServiceType" readonly/>                    
                                   
                   <p>Physician</p>
                    <input id="PhysicianName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="PhysicianName" readonly/>          
                    <asp:HiddenField ID="PhysicianID" runat="server" />  
                    <p>Status</p>
                 <input id="Status" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Status" readonly/>      
                   
              </div>
              
              <!-- /.form-group -->
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
         
        </div>
      </div>
      
      <!-- /.box -->
            <div  class="row">
                 <div class="col-md-6">
                      <button type="button" id ="btnSave" runat ="server" onserverclick="SavePatientEncounter" class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="ClosePatientCase" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                       <button type="button" id ="btnSaveComplete"  runat ="server" onserverclick="CompletePatientEncounter" class="btn btn-success" ><span class="glyphicon glyphicon-ok-sign"></span> Save and Complete</button>
                     <br />
                 </div>
                 <div class="box-footer">
         
                </div>
                 
            </div>
         
      <div class="row">
        <div class="col-md-6">

            <div class="box box-warning">
            <div class="box-header">
              <h3 class="box-title">Subjective</h3>
            </div>
            <div class="box-body">   
                
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
                                
                 
                                           


            </div>
            <!-- /.box-body -->
          </div>

              <div class="box box-info">
            <div class="box-header">
              <h3 class="box-title">Objective</h3>
            </div>
            <div class="box-body">
             
                 <asp:HiddenField ID="hfVitalsID" runat="server" />
                 <div class="form-group" >
                  <label>Physical Exam</label>
                  <textarea class="form-control" rows="6" id="txtPhysicalExam" runat ="server" placeholder="Enter physical examination note"></textarea>
                </div> 

                 <div class="col-md-6">
                      <div class="form-group">
                        <label>Temperature</label>
                        <input type="text" id ="txtTemperature" runat ="server"  class="form-control" placeholder="temperature" >
                    </div>

                    <div class="form-group">
                        <label>Blood Pressure (systolic)</label>
                        <input type="text" id="txtSystolic" runat ="server"  class="form-control" placeholder="systolic" >
                 </div>

                    <div class="form-group">
                        <label>Blood Pressure (diastolic)</label>
                        <input type="text" id ="txtDiastolic" runat ="server"  class="form-control" placeholder="diastolic" >
                 </div>
                 
                     <div class="form-group">
                        <label>Blood Sugar (mg/dl)</label>
                        <input type="text" id ="txtBloodSugar" runat ="server"  class="form-control" placeholder="blood sugar" >
                 </div>
                 </div>

                <div class="col-md-6">
                       <div class="form-group">
                        <label>Pulse Rate</label>
                        <input type="text" id="txtPulseRate" runat ="server" class="form-control" placeholder="pulse rate" >
                </div>

                    <div class="form-group">
                        <label>Height (Ft)</label>
                        <input type="text" id="txtHeight" runat ="server" class="form-control" placeholder="height" >
                </div>

                    <div class="form-group">
                        <label>Weight (Kls)</label>
                        <input type="text" id ="txtWeight" runat ="server" class="form-control" placeholder="weight" >
                </div>

                    <div class="form-group">
                        <label>Other</label>
                        <input type="text" id ="txtOther" runat ="server"  class="form-control" placeholder="other detail" >
                 </div>
                </div>
               

                 <div class="form-group" >
                  <label>Remarks</label>
                  <textarea class="form-control" rows="3" id="Remarks" runat ="server" placeholder="other notes"></textarea>
                </div>

                                

            </div>
            <!-- /.box-body -->
          </div>

        

        </div>
        <!-- /.col (left) -->
        <div class="col-md-6">

            <div class="box box-danger">
            <div class="box-header">
              <h3 class="box-title">Assessment</h3>
            </div>
            <div class="box-body">    
                
                 <div class="nav-tabs-custom">
                     <ul class="nav nav-tabs" id="DiagnosisTab">
                      <li class="active"><a href="#tab_1" data-toggle="tab">Diagnosis</a></li>
                        <li><a href="#tab_2" data-toggle="tab">Physician Note</a></li>                  
             
                     </ul>
                      <div class="tab-content">
                          <div class="tab-pane active" id="tab_1">   
                              <div class="box-body">
                                    
                                    <button type="button" runat ="server"  class="btn btn-primary" data-toggle="modal" data-target="#addDiagnosis"><span class="glyphicon glyphicon-plus" ></span> Add Diagnosis</button>
                 
                                    <asp:GridView ID="gvDiagnosis" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnDiagnosisPageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="ICD Code" />
                              <asp:BoundField DataField="Description" HeaderText="ICD Description" />
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

                      <!-- /.tab-pane -->
                         <div class="tab-pane" id="tab_2">
                             <div class="box-body">
                                  <div class="form-group" >
                                      <label>Physician Note</label>
                                      <textarea class="form-control" rows="6" id="txtDoctorNote" runat ="server" placeholder="Enter doctor's note"></textarea><br />
                                      
                                    </div>  
                             </div>

                        </div>
                      </div>
                 </div>        
              


            </div>
            <!-- /.box-body -->
          </div>

            <div class="box box-success">
            <div class="box-header">
              <h3 class="box-title">Plan</h3>
            </div>
            <div class="box-body">

                                <div class="form-group">
                                    <p>Disposition</p>
                                    <asp:DropDownList ID="ddlDisposition" class="form-control mr-sm-2" runat="server" ></asp:DropDownList><br />   
                                    <p>Recommendation</p>
                                     <p>Number of Days rest</p>
                                     <input type="text" id ="RestDays" runat ="server"  class="form-control" placeholder="No. of Days rest" >
                                    <p>Work Restriction as follows:</p>
                                    <textarea class="form-control" rows="6" id="Recommendation" runat ="server" placeholder="Enter work restrictions"></textarea>
                                     <p>Follow-up Date</p>
                                   
                                    <div class="input-group date">
                                      <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                      </div>
                                        <input type="text" id ="FollowUpDate" runat ="server"  class="form-control pull-right" placeholder="Followup Date" >
                                    </div>                                     
                 
                                </div>

                                   

                                    <button type="button" runat ="server"  class="btn btn-success" data-toggle="modal" data-target="#addMedication"><span class="glyphicon glyphicon-plus"></span> Add Medication</button>
               
                                    <asp:GridView ID="gvPrescription" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnMedsPageIndexChanging">
                        
                 
                   
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="Drug Code" />
                              <asp:BoundField DataField="Description" HeaderText="Medicine" />
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

                                 

                                    <button type="button" runat ="server" id="btnCpt" class="btn btn-warning" data-toggle="modal" data-target="#addProcedure"><span class="glyphicon glyphicon-plus"></span> Add Lab/Rad Request </button>
               
                                    <asp:GridView ID="gvCpt" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" CssClass="table table-striped" OnPageIndexChanging="OnCptPageIndexChanging">
                        
                 
                   
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <Columns>
                              <asp:BoundField DataField="code" HeaderText="CPT Code" />
                              <asp:BoundField DataField="Description" HeaderText="CPT Description" />
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
            <!-- /.box-body -->
           
          </div>

            
          <!-- /.box -->
         
          
            
          <!-- /.box -->
        </div>
        <!-- /.col (right) -->
      </div>
      <!-- /.row -->

             <!-- Add Modal --> 
       <!-- Diagnosis --> 

        <div class="modal fade" id="addDiagnosis" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
          <div class="modal-dialog">
        <div class="modal-content">
              <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
            <h4 class="modal-title custom_align" id="DiagnosisHeading">Add Diagnosis </h4>
          </div>
              <div class="modal-body">
              <div class="form-group">
                    <p>Select ICD</p>
                    <asp:DropDownList ID="ddlICD" class="form-control select2" onchange="onICDSelectChange();"  runat="server" Width="100%" ></asp:DropDownList><br /> 
                    <p>ICD Code</p>  
                    <input id="ICDCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
                    <p>Description</p>                    
                    <textarea class="form-control" rows="6" id="ICDDesc" runat ="server" placeholder="description"></textarea>
                 
                </div>
       
          </div>
              <div class="modal-footer ">
              <%--<input type="button" id="btnsubmit" runat="server" onserverclick="DeleteDiagnosis_ServerClick" class="btn btn-primary"  value="Save" />--%>
              <asp:Button ID="btnAddDiagnosis" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="AddDiagnosis_ServerClick" />
                  <button type="button" id="closeDiagnosisButton" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
          </div>
            </div>
  
      </div>
     
        </div>

    <!-- Medication --> 

        <div class="modal fade" id="addMedication" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
          <div class="modal-dialog">
        <div class="modal-content">
              <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
            <h4 class="modal-title custom_align" id="PrescriptionHeading">Add Medication </h4>
          </div>
              <div class="modal-body">
              <div class="form-group" >
                    <label>Medication</label><br />
                   <asp:DropDownList ID="medsList" class="form-control select2" Width="100%" runat="server"></asp:DropDownList>
               </div>

               <div class="form-group" >
                    <label>Prescription</label><br />
                     <asp:DropDownList ID="ddlPrescriptionTemplate" class="form-control select2" Width="100%" runat="server" onchange="onPrescriptionTemplateChange();" readonly></asp:DropDownList><br />   
                     <textarea class="form-control" rows="6" id="Prescription" runat ="server" placeholder="Prescription"></textarea>
                </div>

                <div class="form-group">                                                                     
                   <asp:CheckBox ID="cbFavorite" runat="server" Text="Add to favorites" />
                </div>
       
          </div>
              <div class="modal-footer ">
           
              <asp:Button ID="Button1" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="AddMedication_ServerClick" />
                  <button type="button" id="closeMedicationButton" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
          </div>
            </div>
  
      </div>
     
        </div>

              <!-- Procedure --> 

        <div class="modal fade" id="addProcedure" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
          <div class="modal-dialog">
        <div class="modal-content">
              <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
            <h4 class="modal-title custom_align" id="ProcedureHeading">Add Medication </h4>
          </div>
              <div class="modal-body">
                <div class="form-group" >
                     <label>CPT</label><br />
                     <asp:DropDownList ID="ddlCpt" class="form-control select2" Width="100%" onchange="onCPTSelectChange();" runat="server"></asp:DropDownList>
                 </div>

                 <div class="form-group" >
                        <p>CPT Code</p>  
                         <input id="CPTCode" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>  
                         <p>Description</p>                    
                         <textarea class="form-control" rows="6" id="CPTDesc" runat ="server" placeholder="description"></textarea>
                  </div>

                   
          </div>
              <div class="modal-footer ">
           
              <asp:Button ID="Button2" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="AddProcedure_ServerClick" />
                  <button type="button" id="closeProcedureButton" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
          </div>
            </div>
  
      </div>
     
        </div>

       <!-- Delete Modal --> 
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
        </form>
    </section>
    <!-- /.content -->

   


  </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">
      <b>Version</b> 2.4.18
    </div>
    <strong>Copyright &copy; 2020 <a href="www.brightcare-assist.com">Brightcare-Assist</a>.</strong> All rights
    reserved.
  </footer>

  <!-- Control Sidebar -->
  <aside class="control-sidebar control-sidebar-dark">
    <!-- Create the tabs -->
    <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
      <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
      <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
      <!-- Home tab content -->
      <div class="tab-pane" id="control-sidebar-home-tab">
        <h3 class="control-sidebar-heading">Recent Activity</h3>
        <ul class="control-sidebar-menu">
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-birthday-cake bg-red"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                <p>Will be 23 on April 24th</p>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-user bg-yellow"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Frodo Updated His Profile</h4>

                <p>New phone +1(800)555-1234</p>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-envelope-o bg-light-blue"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Nora Joined Mailing List</h4>

                <p>nora@example.com</p>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-file-code-o bg-green"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Cron Job 254 Executed</h4>

                <p>Execution time 5 seconds</p>
              </div>
            </a>
          </li>
        </ul>
        <!-- /.control-sidebar-menu -->

        <h3 class="control-sidebar-heading">Tasks Progress</h3>
        <ul class="control-sidebar-menu">
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Custom Template Design
                <span class="label label-danger pull-right">70%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Update Resume
                <span class="label label-success pull-right">95%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-success" style="width: 95%"></div>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Laravel Integration
                <span class="label label-warning pull-right">50%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-warning" style="width: 50%"></div>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Back End Framework
                <span class="label label-primary pull-right">68%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-primary" style="width: 68%"></div>
              </div>
            </a>
          </li>
        </ul>
        <!-- /.control-sidebar-menu -->

      </div>
      <!-- /.tab-pane -->
      <!-- Stats tab content -->
      <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
      <!-- /.tab-pane -->
      <!-- Settings tab content -->
      <div class="tab-pane" id="control-sidebar-settings-tab">
        <form method="post">
          <h3 class="control-sidebar-heading">General Settings</h3>

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Report panel usage
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Some information about this general settings option
            </p>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Allow mail redirect
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Other sets of options are available
            </p>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Expose author name in posts
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Allow the user to show his name in blog posts
            </p>
          </div>
          <!-- /.form-group -->

          <h3 class="control-sidebar-heading">Chat Settings</h3>

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Show me as online
              <input type="checkbox" class="pull-right" checked>
            </label>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Turn off notifications
              <input type="checkbox" class="pull-right">
            </label>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Delete chat history
              <a href="javascript:void(0)" class="text-red pull-right"><i class="fa fa-trash-o"></i></a>
            </label>
          </div>
          <!-- /.form-group -->
        </form>
      </div>
      <!-- /.tab-pane -->
    </div>
  </aside>
  <!-- /.control-sidebar -->
  <!-- Add the sidebar's background. This div must be placed
       immediately after the control sidebar -->
  <div class="control-sidebar-bg"></div>
</div>
<!-- ./wrapper -->

<!-- jQuery 3 -->
<script src="../AdminLTE/bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="../AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- Select2 -->
<script src="../AdminLTE/bower_components/select2/dist/js/select2.full.min.js"></script>
<!-- InputMask -->
<script src="../AdminLTE/plugins/input-mask/jquery.inputmask.js"></script>
<script src="../AdminLTE/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="../AdminLTE/plugins/input-mask/jquery.inputmask.extensions.js"></script>
<!-- date-range-picker -->
<script src="../AdminLTE/bower_components/moment/min/moment.min.js"></script>
<script src="../AdminLTE/bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
<!-- bootstrap datepicker -->
<script src="../AdminLTE/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
<!-- bootstrap color picker -->
<script src="../AdminLTE/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
<!-- bootstrap time picker -->
<script src="../AdminLTE/plugins/timepicker/bootstrap-timepicker.min.js"></script>
<!-- SlimScroll -->
<script src="../AdminLTE/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- iCheck 1.0.1 -->
<script src="../AdminLTE/plugins/iCheck/icheck.min.js"></script>
<!-- FastClick -->
<script src="../AdminLTE/bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="../AdminLTE/dist/js/adminlte.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../AdminLTE/dist/js/demo.js"></script>
<!-- Page script -->
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

    $('#FollowUpDate').datepicker({
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

    

    function SetCptTab() {
        $('[href="#tab_5"]').tab('show');
    }

    $('#btnAddCPT').on('click', function (event) {
        event.preventDefault();
        var tab = $(this).data('next');
        $(tab).tab('show');
    })

  
  })
</script>

    <script type="text/javascript">

        function onPrescriptionTemplateChange()
            {
            var ddl = document.getElementById('<%=ddlPrescriptionTemplate.ClientID %>');
            var textBox = document.getElementById('<%= Prescription.ClientID%>');

            textBox.value = ddl.options[ddl.selectedIndex].text;
            }

         function onICDSelectChange()
            {
                var ddl = document.getElementById('<%=ddlICD.ClientID %>');
                     var textICDCode = document.getElementById('<%= ICDCode.ClientID%>');
                      var textICDDesc = document.getElementById('<%= ICDDesc.ClientID%>');

                     textICDCode.value = ddl.options[ddl.selectedIndex].value;
                     textICDDesc.value = ddl.options[ddl.selectedIndex].text;
         }

        function onCPTSelectChange()
            {
                var ddl = document.getElementById('<%=ddlCpt.ClientID %>');
                     var textCode = document.getElementById('<%= CPTCode.ClientID%>');
                      var textDesc = document.getElementById('<%= CPTDesc.ClientID%>');

             textCode.value = ddl.options[ddl.selectedIndex].value;
             textDesc.value = ddl.options[ddl.selectedIndex].text;
            }


</script>

 <script type="text/javascript" language="javascript">
    function FuncAlert() {
        alert("hello!");
    }
</script>

</body>
</html>
