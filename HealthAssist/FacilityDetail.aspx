<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FacilityDetail.aspx.cs" Inherits="HealthAssist.FacilityDetail" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" style="margin: 0"> 
         <div class="row">  
              <div class="col-md-2"> 
                 
              </div>
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                  <asp:HiddenField ID="FacilityID" runat="server" />
                  <p>Facility Name</p>
                  <input id="FacilityName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Facility Name"/>
                  <p>Contact Person</p>
                  <input id="ContactPerson" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Contact Person"/>
                   <p>Designation</p>
                  <input id="Designation" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Designation"/>
                  <p>Type</p>
                  <asp:DropDownList ID="ddlFacilityType" class="form-control mr-sm-2" runat="server">
                      <asp:ListItem>Clinic</asp:ListItem>
                      <asp:ListItem>Hospital</asp:ListItem>
                      </asp:DropDownList>
                 
                      <p>Contact No</p>
                  <input id="txtContact" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Contact"/>
                  <p>Email</p>
                  <input id="txtEmail" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Email"/>              
                   <p>Province</p>
                  <asp:DropDownList ID="ddlProvince" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                  <p>Address</p>
                   <textarea id="txtAddress"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Address"></textarea><br />

                    <br /><br />
                      <button type="button" runat ="server" onserverclick="AddData"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="CloseData" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                </form> 

              </div>
             <div class="col-md-3"> 
               
                 <p>Date Accreditation</p>
                 <div class="form-group">
                        <div class='input-group date' id='DateAccreditation'>
                          <input type='text' id ="Accreditation" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                   </div> 

                 <p>Expiration</p>
                  <div class="form-group">
                        <div class='input-group date' id='DateExpiration'>
                          <input type='text' id ="Expiration" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                   </div> 

                 <p>Cash Bond</p>
                  <input id="CashBond" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Cash Bond"/>

                 <p>Status</p>
                       <asp:DropDownList ID="ddlStatus" class="form-control mr-sm-2" runat="server"></asp:DropDownList>

                   <p>Notes</p>
                   <textarea id="txtNote"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Note"></textarea>
                    <br />
                    <br />

                  </div>
             <div class="col-md-2"> 

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
            $('#DateAccreditation').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });

        $(function () {
            $('#DateExpiration').datetimepicker({
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
