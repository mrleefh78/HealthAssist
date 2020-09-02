<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="InvoiceDetail.aspx.cs" Inherits="HealthAssist.InvoiceDetail" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" style="margin: 0"> 
         <div class="row">  
              <div class="col-md-2"> 
                 
              </div>
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                  <asp:HiddenField ID="InvoiceID" runat="server" />
                  <asp:HiddenField ID="PatientNo" runat="server" />
                  <p>Invoice No</p>
                  <input id="InvoiceNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Invoice No"/>

                   <p>Insurance Company</p>
                  <asp:DropDownList ID="ddlInsurance" class="form-control mr-sm-2" runat="server"></asp:DropDownList>

                 <p>Patient Name</p>
                  <asp:DropDownList ID="ddlPatient" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                  <p>Case No</p>
                  <input id="CaseNo" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Case No"/>
                 <p>Invoice Date</p>
                 <div class="form-group">
                        <div class='input-group date' id='DateInvoice'>
                          <input type='text' id ="InvoiceDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                   </div> 
                   <p>Medex</p>
                  <input id="Medex" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Medex"/>
                  <p>Case Fee</p>
                  <input id="CaseFee" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Case Fee"/>
                  <p>Total Billed</p>
                  <input id="TotalBill" runat ="server" class="form-control mr-sm-2" type="text" value ="0" placeholder="Total Billed"/>              
                 
                  
                    <br /><br />
                      <button type="button" runat ="server" onserverclick="AddData"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="CloseData" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                </form> 

              </div>
             <div class="col-md-3"> 
               
                 <p>Date Billed</p>
                  <div class="form-group">
                        <div class='input-group date' id='DateBilled'>
                          <input type='text' id ="BillingDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                   </div> 
                  <p>Date Paid</p>
                  <div class="form-group">
                        <div class='input-group date' id='DatePaid'>
                          <input type='text' id ="PaidDate" runat ="server" class="form-control" ></input>    
                          <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                          </span>
                        </div>
                   </div> 

                  <p>Status</p>
                  <asp:DropDownList ID="ddlStatus" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                  <p>Remarks</p>
                   <textarea id="txtRemarks"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Remarks"></textarea><br />

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
            $('#DateInvoice').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });
      

        $(function () {
            $('#DateBilled').datetimepicker({
                //format: 'YYYY-MM-DD'

            });
        });

        $(function () {
            $('#DatePaid').datetimepicker({
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
