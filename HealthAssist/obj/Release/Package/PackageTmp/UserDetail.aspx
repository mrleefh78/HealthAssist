<%@ Page Title="" Language="C#" MasterPageFile="~/BrightCareAdmin.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="HealthAssist.UserDetail" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <section class="content-header">
      <h1>
        User
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
                  <asp:HiddenField ID="UserID" runat="server" />
                  <p>Last Name</p>
                  <input id="LastName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="Last Name"/>
                  <p>First Name</p>
                  <input id="FirstName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="First Name"/>
                  <p>User Name</p>
                  <input id="UserName" runat ="server" class="form-control mr-sm-2" type="text" placeholder="User Name"/>
                  <p>User Password</p>
                  <input id="UserPassword" runat ="server" class="form-control mr-sm-2" type="password" placeholder="User Password"/>
                   <p>Account Type</p>
                   <select id="AccountType" runat="server" name="AccountType" class="form-control mr-sm-2" >
                    <option value="Admin">Admin</option>
                    <option value="Staff">Staff</option>    
                        <option value="Physician">Physician</option>    
                        <option value="Patient">Patient</option>                   
                  </select>
                 
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
