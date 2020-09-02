<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HealthAssist.Login" EnableEventValidation="false" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HealthAssist Login</title>
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    
     <script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
     <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
      <%--<link rel="stylesheet" href="https://bootswatch.com/3/flatly/bootstrap.min.css"/>--%>
    <link rel="stylesheet" href="Content/css/cerulean/bootstrap.min.css"/>   
                   
    
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="icon" type="image/x-icon" href="favicon.ico"/>

</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
           <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <h4 class="page-header"></h4>
                    <div class="login-panel panel panel-primary">
                          <div class="panel-heading">
                                <h2 class="panel-title">Login to HealthAssist</h2>
                          </div>                     

                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <img src="content/images/logo_fin.png" class="img-responsive center-block " style="max-height: 100%; max-width: 100%;">
                                </div>
                                 <div class="form-group">
                                      
                                    <label>Username</label>
                                      <asp:TextBox ID="txbUsername" runat="server" required class="form-control"  name="username" placeholder="Your Username" ></asp:TextBox>
                                    <%--<input type="text" required class="form-control"  name="username" placeholder="Your Username" />--%>
                                </div>
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox ID="txbPassword" runat="server" required class="form-control"  name="password"  placeholder="Your Password" TextMode="Password"></asp:TextBox>
                                    <%--<input type="password" required class="form-control"  name="password"  placeholder="Your Password"/>--%>
                                </div>
                               
                                <asp:Button ID="btnLogin" runat="server" Text="Login Now..." class="btn btn-primary btn-sm" OnClick="btnLogin_Click"  />
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </fieldset>

                        </div>
                  
                    </div>
                </div>
           </div>

     </div>
                                   
   </form>
                   
</body>

</html>
