<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Report.Master" AutoEventWireup="true" CodeBehind="MedCertificate.aspx.cs" Inherits="HealthAssist.Reports.MedCertificate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div><p class="c15"><span style="overflow: hidden; display: inline-block; margin: 0.00px 0.00px; border: 0.00px solid #000000; transform: rotate(0.00rad) translateZ(0px); 
-webkit-transform: rotate(0.00rad) translateZ(0px); width: 816.00px; height: 143.93px;">
    <img alt="" src="Telemed_MED CERT/images/image1.jpg" style="width: 816.00px; height: 143.93px; margin-left: 0.00px; margin-top: 0.00px; transform: rotate(0.00rad) translateZ(0px); 
-webkit-transform: rotate(0.00rad) translateZ(0px);" title=""></span></p></div>

    <p class="c0"><span class="c8"></span></p><p class="c2">
    <span class="c1">DATE: <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></span></p><p class="c0"><span class="c1"></span></p><p class="c0"><span class="c1"></span></p><p class="c13">
    <span class="c9">MEDICAL CERTIFICATE</span></p><p class="c7"><span class="c9"></span></p><p class="c2"><span class="c10">TO WHOM IT MAY CONCERN:</span></p>
    <p class="c0"><span class="c9"></span></p><p class="c2">
        <span class="c1">THIS IS TO CERTIFY that  <asp:Label ID="lblPatient" runat="server" Text="Label" Font-Bold="True" Font-Underline="True"></asp:Label> Age <asp:Label ID="lblAge" runat="server" Text="Label" Font-Bold="True"></asp:Label> Sex  <asp:Label ID="lblGender" runat="server" Text="Label" Font-Bold="True"></asp:Label></span></p><p class="c0"><span class="c1"></span></p>
    <p class="c2" id="h.gjdgxs"><span class="c6">With insurance number under  <asp:Label ID="lblCompany" runat="server" Text="Label"></asp:Label> has undergone teleconsultation on </span><span class="c14"> <asp:Label ID="lblEncounterDate" runat="server" Text="Label"></asp:Label> </span>
    <span class="c1">with the following findings:</span></p><p class="c0"><span class="c1"></span></p><p class="c2">
    <span class="c1"><b>DIAGNOSIS: </b><br /> <asp:Label ID="lblDiagnosis" runat="server" Text="Label"></asp:Label></span></p>
    <span class="c1"><b>MEDICATIONS: </b> <br />  <asp:Label ID="lblMeds" runat="server" Text="Label"></asp:Label></span>
    <p class="c2">
    <span class="c1"><asp:Label ID="lblRecomen" runat="server" Text="Label"></asp:Label></span></p><p class="c0"><span class="c1"></span></p><p class="c0"><span class="c1"></span></p><p class="c0"><span class="c1"></span></p>
    <p class="c0"><span class="c1"></span></p><p class="c2">
    <span class="c6">This Medical Certificate is being issued upon the request of the above named Patient for whatever purpose it may serve. </span>
    <span class="c14">This is not for Medico-Legal purposes</span><span class="c1">.</span></p><p class="c0"><span class="c1"></span></p><p class="c0">
    <span class="c1"></span></p><p class="c0"><span class="c1"></span></p><p class="c0"><span class="c1"></span></p><p class="c2 c16">
    <span class="c1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
    <p class="c2 c3"><span class="c1"> <asp:Label ID="lblPhysician" runat="server" Text="Label" Font-Bold="True" Font-Overline="False" Font-Underline="True"></asp:Label> <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Attending Physician <br /> <br /></span>
        <span class="c6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lic. No  <asp:Label ID="lblPhysicianLicense" runat="server" Text="Label"></asp:Label></span>
    </p>
   
</asp:Content>
