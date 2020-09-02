<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="ClientDetail.aspx.cs" Inherits="HealthAssist.ClientDetail" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" style="margin: 0"> 
         <div class="row">  
              <div class="col-md-2"> 
                 
              </div>
             <div class="col-md-3"> 
                  <form class="form-inline my-2 my-lg-0">
                  <asp:HiddenField ID="ClientID" runat="server" />
                  <p>Business Code</p>
                  <input id="Code" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Code"/>
                  <p>Company Name</p>
                  <input id="CompanyName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Company Name"/>
                  <p>Contact Person</p>
                  <input id="ContactPerson" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Contact Person"/>
                  <p>Country</p>
                  <asp:DropDownList ID="ddlCountryCode" class="form-control mr-sm-2" runat="server"></asp:DropDownList>
                 
                      <p>Contact No</p>
                  <input id="txtContact" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Contact"/>
                  <p>Email</p>
                  <input id="txtEmail" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Email"/>              
                  
                  <p>Address</p>
                   <textarea id="txtAddress"  rows="5" cols="75" runat="server" maxlength="700" placeholder="Address"></textarea><br />

                    <br /><br />
                      <button type="button" runat ="server" onserverclick="AddData"  class="btn btn-primary" ><span class="glyphicon glyphicon-ok-sign"></span> Save</button>
                      <button type="button"  runat ="server" onserverclick="CloseData" class="btn btn-warning" ><span class="glyphicon glyphicon-remove-sign"></span> Close</button>
                </form> 

              </div>
             <div class="col-md-3"> 
               
                 
              
              </div>
             <div class="col-md-2"> 

              </div>
         </div>
     </div>
</asp:Content>
