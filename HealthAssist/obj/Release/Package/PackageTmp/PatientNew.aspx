<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="PatientNew.aspx.cs" Inherits="HealthAssist.PatientNew" EnableEventValidation="false"%>
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

     
    </script>

     <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>