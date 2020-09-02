<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsentForm.aspx.cs" Inherits="HealthAssist.Reports.ConsentForm" %>

<!DOCTYPE html>

<html><head><meta content="text/html; charset=UTF-8" http-equiv="content-type">
    <style type="text/css">@import url(https://themes.googleusercontent.com/fonts/css?kit=fpjTOVmNbO4Lz34iLyptLTi9jKYd1gJzj5O2gWsEpXqXAclpnZFHBUh5ixCAZY3J);
ol.lst-kix_list_3-1{list-style-type:none}ol.lst-kix_list_3-2{list-style-type:none}.lst-kix_list_3-1>li{counter-increment:lst-ctn-kix_list_3-1}ol.lst-kix_list_3-3{list-style-type:none}
 ol.lst-kix_list_3-4.start{counter-reset:lst-ctn-kix_list_3-4 0}ol.lst-kix_list_3-4{list-style-type:none}.lst-kix_list_2-1>li{counter-increment:lst-ctn-kix_list_2-1}
  ol.lst-kix_list_3-0{list-style-type:none}.lst-kix_list_1-1>li{counter-increment:lst-ctn-kix_list_1-1}ol.lst-kix_list_2-6.start{counter-reset:lst-ctn-kix_list_2-6 0}
  .lst-kix_list_3-0>li:before{content:"" counter(lst-ctn-kix_list_3-0,decimal) ". "}ol.lst-kix_list_3-1.start{counter-reset:lst-ctn-kix_list_3-1 0}
  .lst-kix_list_3-1>li:before{content:"" counter(lst-ctn-kix_list_3-1,lower-latin) ". "}.lst-kix_list_3-2>li:before{content:"" counter(lst-ctn-kix_list_3-2,lower-roman) ". "}
  ol.lst-kix_list_1-8.start{counter-reset:lst-ctn-kix_list_1-8 0}ol.lst-kix_list_2-3.start{counter-reset:lst-ctn-kix_list_2-3 0}.lst-kix_list_3-5>
  li:before{content:"" counter(lst-ctn-kix_list_3-5,lower-roman) ". "}.lst-kix_list_3-4>li:before{content:"" counter(lst-ctn-kix_list_3-4,lower-latin) ". "}
  ol.lst-kix_list_1-5.start{counter-reset:lst-ctn-kix_list_1-5 0}.lst-kix_list_3-3>li:before{content:"" counter(lst-ctn-kix_list_3-3,decimal) ". "}
  ol.lst-kix_list_3-5{list-style-type:none}ol.lst-kix_list_3-6{list-style-type:none}ol.lst-kix_list_3-7{list-style-type:none}
  ol.lst-kix_list_3-8{list-style-type:none}.lst-kix_list_3-8>li:before{content:"" counter(lst-ctn-kix_list_3-8,lower-roman) ". "}
  .lst-kix_list_2-0>li{counter-increment:lst-ctn-kix_list_2-0}.lst-kix_list_2-3>li{counter-increment:lst-ctn-kix_list_2-3}
  .lst-kix_list_3-6>li:before{content:"" counter(lst-ctn-kix_list_3-6,decimal) ". "}.lst-kix_list_3-7>li:before{content:"" counter(lst-ctn-kix_list_3-7,lower-latin) ". "}
  .lst-kix_list_1-2>li{counter-increment:lst-ctn-kix_list_1-2}ol.lst-kix_list_3-7.start{counter-reset:lst-ctn-kix_list_3-7 0}
  .lst-kix_list_3-2>li{counter-increment:lst-ctn-kix_list_3-2}ol.lst-kix_list_2-2{list-style-type:none}ol.lst-kix_list_2-3{list-style-type:none}ol
  .lst-kix_list_2-4{list-style-type:none}ol.lst-kix_list_2-5{list-style-type:none}.lst-kix_list_1-4>li{counter-increment:lst-ctn-kix_list_1-4}ol
  .lst-kix_list_2-0{list-style-type:none}ol.lst-kix_list_1-6.start{counter-reset:lst-ctn-kix_list_1-6 0}ol.lst-kix_list_2-1{list-style-type:none}ol
  .lst-kix_list_3-3.start{counter-reset:lst-ctn-kix_list_3-3 0}ol.lst-kix_list_2-6{list-style-type:none}ol.lst-kix_list_2-7{list-style-type:none}ol
  .lst-kix_list_2-8{list-style-type:none}ol.lst-kix_list_1-0.start{counter-reset:lst-ctn-kix_list_1-0 0}.lst-kix_list_3-0>li{counter-increment:lst-ctn-kix_list_3-0}
   .lst-kix_list_3-3>li{counter-increment:lst-ctn-kix_list_3-3}.lst-kix_list_3-6>li{counter-increment:lst-ctn-kix_list_3-6}.lst-kix_list_2-5>li{counter-increment:lst-ctn-kix_list_2-5}
  .lst-kix_list_2-8>li{counter-increment:lst-ctn-kix_list_2-8}ol.lst-kix_list_3-2.start{counter-reset:lst-ctn-kix_list_3-2 0}.lst-kix_list_2-2>li{counter-increment:lst-ctn-kix_list_2-2}ol
 .lst-kix_list_2-4.start{counter-reset:lst-ctn-kix_list_2-4 0}ol.lst-kix_list_1-3{list-style-type:none}ol.lst-kix_list_1-4{list-style-type:none}
 .lst-kix_list_2-6>li:before{content:"" counter(lst-ctn-kix_list_2-6,decimal) ". "}
 .lst-kix_list_2-7>li:before{content:"" counter(lst-ctn-kix_list_2-7,lower-latin) ". "}.lst-kix_list_2-7>li{counter-increment:lst-ctn-kix_list_2-7}
  .lst-kix_list_3-7>li{counter-increment:lst-ctn-kix_list_3-7}ol.lst-kix_list_1-5{list-style-type:none}ol.lst-kix_list_1-6{list-style-type:none}ol.lst-kix_list_1-0{list-style-type:none}
  .lst-kix_list_2-4>li:before{content:"" counter(lst-ctn-kix_list_2-4,lower-latin) ". "}.lst-kix_list_2-5>li:before{content:"" counter(lst-ctn-kix_list_2-5,lower-roman) ". "}
 .lst-kix_list_2-8>li:before{content:"" counter(lst-ctn-kix_list_2-8,lower-roman) ". "}ol.lst-kix_list_1-1{list-style-type:none}ol.lst-kix_list_1-2{list-style-type:none}ol
 .lst-kix_list_3-0.start{counter-reset:lst-ctn-kix_list_3-0 0}ol.lst-kix_list_1-7{list-style-type:none}.lst-kix_list_1-7>li{counter-increment:lst-ctn-kix_list_1-7}ol
 .lst-kix_list_1-8{list-style-type:none}ol.lst-kix_list_3-8.start{counter-reset:lst-ctn-kix_list_3-8 0}ol.lst-kix_list_2-5.start{counter-reset:lst-ctn-kix_list_2-5 0}
  .lst-kix_list_2-6>li{counter-increment:lst-ctn-kix_list_2-6}.lst-kix_list_3-8>li{counter-increment:lst-ctn-kix_list_3-8}ol.lst-kix_list_1-7.start{counter-reset:lst-ctn-kix_list_1-7 0}ol
  .lst-kix_list_2-2.start{counter-reset:lst-ctn-kix_list_2-2 0}.lst-kix_list_1-5>li{counter-increment:lst-ctn-kix_list_1-5}.lst-kix_list_1-8>li{counter-increment:lst-ctn-kix_list_1-8}ol
  .lst-kix_list_1-4.start{counter-reset:lst-ctn-kix_list_1-4 0}.lst-kix_list_3-5>li{counter-increment:lst-ctn-kix_list_3-5}ol.lst-kix_list_1-1.start{counter-reset:lst-ctn-kix_list_1-1 0}
  .lst-kix_list_3-4>li{counter-increment:lst-ctn-kix_list_3-4}.lst-kix_list_2-4>li{counter-increment:lst-ctn-kix_list_2-4}ol.lst-kix_list_3-6.start{counter-reset:lst-ctn-kix_list_3-6 0}ol
  .lst-kix_list_1-3.start{counter-reset:lst-ctn-kix_list_1-3 0}ol.lst-kix_list_2-8.start{counter-reset:lst-ctn-kix_list_2-8 0}ol.lst-kix_list_1-2.start{counter-reset:lst-ctn-kix_list_1-2 0}
   .lst-kix_list_1-0>li:before{content:"" counter(lst-ctn-kix_list_1-0,decimal) ") "}.lst-kix_list_1-1>li:before{content:"" counter(lst-ctn-kix_list_1-1,lower-latin) ". "}
    .lst-kix_list_1-2>li:before{content:"" counter(lst-ctn-kix_list_1-2,lower-roman) ". "}ol.lst-kix_list_2-0.start{counter-reset:lst-ctn-kix_list_2-0 0}
   .lst-kix_list_1-3>li:before{content:"" counter(lst-ctn-kix_list_1-3,decimal) ". "}.lst-kix_list_1-4>li:before{content:"" counter(lst-ctn-kix_list_1-4,lower-latin) ". "}ol
   .lst-kix_list_3-5.start{counter-reset:lst-ctn-kix_list_3-5 0}.lst-kix_list_1-0>li{counter-increment:lst-ctn-kix_list_1-0}.lst-kix_list_1-6>li{counter-increment:lst-ctn-kix_list_1-6}
   .lst-kix_list_1-7>li:before{content:"" counter(lst-ctn-kix_list_1-7,lower-latin) ". "}ol.lst-kix_list_2-7.start{counter-reset:lst-ctn-kix_list_2-7 0}
   .lst-kix_list_1-3>li{counter-increment:lst-ctn-kix_list_1-3}.lst-kix_list_1-5>li:before{content:"" counter(lst-ctn-kix_list_1-5,lower-roman) ". "}
   .lst-kix_list_1-6>li:before{content:"" counter(lst-ctn-kix_list_1-6,decimal) ". "}.lst-kix_list_2-0>li:before{content:"" counter(lst-ctn-kix_list_2-0,decimal) ") "}
   .lst-kix_list_2-1>li:before{content:"" counter(lst-ctn-kix_list_2-1,lower-latin) ". "}ol.lst-kix_list_2-1.start{counter-reset:lst-ctn-kix_list_2-1 0}.lst-kix_list_1-8>
    li:before{content:"" counter(lst-ctn-kix_list_1-8,lower-roman) ". "}.lst-kix_list_2-2>li:before{content:"" counter(lst-ctn-kix_list_2-2,lower-roman) ". "}
    .lst-kix_list_2-3>li:before{content:"" counter(lst-ctn-kix_list_2-3,decimal) ". "}ol{margin:0;padding:0}
   table td,table th{padding:0}.c16{margin-left:36pt;padding-top:0pt;padding-left:0pt;padding-bottom:0pt;line-height:1.0666666666666667;orphans:2;widows:2;text-align:left}
                               .c15{margin-left:36pt;padding-top:0pt;padding-left:0pt;padding-bottom:8pt;line-height:1.0666666666666667;orphans:2;widows:2;text-align:left}
                               .c2{margin-left:36pt;padding-top:0pt;padding-bottom:0pt;line-height:1.0666666666666667;orphans:2;widows:2;text-align:left;height:11pt}
                               .c11{margin-left:288pt;padding-top:0pt;text-indent:36pt;padding-bottom:0pt;line-height:1.0;orphans:2;widows:2;text-align:justify}
                               .c12{margin-left:36pt;padding-top:0pt;padding-left:0pt;padding-bottom:0pt;line-height:1.0;orphans:2;widows:2;text-align:justify}
                               .c5{color:#000000;font-weight:400;text-decoration:none;vertical-align:baseline;font-size:11pt;font-family:"Arial";font-style:normal}
                               .c13{color:#000000;font-weight:700;text-decoration:none;vertical-align:baseline;font-size:14pt;font-family:"Arial";font-style:normal}
                               .c7{color:#000000;font-weight:400;text-decoration:none;vertical-align:baseline;font-size:12pt;font-family:"Cambria";font-style:normal}
                               .c10{color:#000000;font-weight:400;text-decoration:none;vertical-align:baseline;font-size:11pt;font-family:"Tahoma";font-style:normal}
                               .c4{color:#000000;font-weight:400;text-decoration:none;vertical-align:baseline;font-size:12pt;font-family:"Arial";font-style:normal}
                               .c0{color:#000000;font-weight:700;text-decoration:none;vertical-align:baseline;font-size:11pt;font-family:"Calibri";font-style:normal}
                               .c8{color:#000000;font-weight:700;text-decoration:none;vertical-align:baseline;font-size:12pt;font-family:"Arial";font-style:normal}
                               .c14{padding-top:0pt;padding-bottom:0pt;line-height:1.0;orphans:2;widows:2;text-align:left}
                               .c6{padding-top:0pt;padding-bottom:10pt;line-height:1.1500000000000001;orphans:2;widows:2;text-align:left}
                               .c1{background-color:#ffffff;max-width:432pt;padding:72pt 90pt 72pt 90pt}
                               .c3{padding:0;margin:0}.c9{height:11pt}.title{padding-top:24pt;color:#000000;font-weight:700;font-size:36pt;padding-bottom:6pt;
                                font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}.subtitle{padding-top:18pt;color:#666666;
                               font-size:24pt;padding-bottom:4pt;font-family:"Georgia";line-height:1.1500000000000001;page-break-after:avoid;font-style:italic;orphans:2;widows:2;text-align:left}
 li{color:#000000;font-size:11pt;font-family:"Calibri"}p{margin:0;color:#000000;font-size:11pt;font-family:"Calibri"}
  h1{padding-top:24pt;color:#000000;font-weight:700;font-size:24pt;padding-bottom:6pt;font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}
  h2{padding-top:18pt;color:#000000;font-weight:700;font-size:18pt;padding-bottom:4pt;font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}
  h3{padding-top:14pt;color:#000000;font-weight:700;font-size:14pt;padding-bottom:4pt;font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}
  h4{padding-top:12pt;color:#000000;font-weight:700;font-size:12pt;padding-bottom:2pt;font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}
  h5{padding-top:11pt;color:#000000;font-weight:700;font-size:11pt;padding-bottom:2pt;font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}
  h6{padding-top:10pt;color:#000000;font-weight:700;font-size:10pt;padding-bottom:2pt;font-family:"Calibri";line-height:1.1500000000000001;page-break-after:avoid;orphans:2;widows:2;text-align:left}
    </style></head>

<body class="c1">
    <div style ="align-content:center;"><p class="c14"><span style="overflow: hidden; display: inline-block; margin: 0.00px 0.00px; border: 0.00px solid #000000; 
transform: rotate(0.00rad) translateZ(0px); -webkit-transform: rotate(0.00rad) translateZ(0px); width: 816.00px; height: 143.93px;">
    
        <img alt="" src="Telemed_consent form/images/image2.jpg" style="width: 816.00px; height: 143.93px; margin-left: 0.00px; margin-top: 0.00px; transform: rotate(0.00rad) translateZ(0px); 
-webkit-transform: rotate(0.00rad) translateZ(0px);" title=""></span></p></div>
    
    <p class="c6 c9"><span class="c0"></span></p><p class="c6">
    <span style="overflow: hidden; display: inline-block; margin: 0.00px 0.00px; border: 0.00px solid #000000; transform: rotate(0.00rad) translateZ(0px); 
-webkit-transform: rotate(0.00rad) translateZ(0px); width: 271.33px; height: 43.00px;">
    <img alt="" src="Telemed_consent form/images/image1.png" style="width: 271.33px; height: 43.00px; margin-left: 0.00px; margin-top: 0.00px; transform: rotate(0.00rad) translateZ(0px); 
-webkit-transform: rotate(0.00rad) translateZ(0px);" title=""></span></p><p class="c6 c9"><span class="c13"></span></p><p class="c6 c9"><span class="c13"></span></p>
    <ol class="c3 lst-kix_list_3-0 start" start="1"><li class="c12"><span class="c4">I hereby authorize </span><span class="c10">BrightCare Assist Philippines, Inc. </span>
        <span class="c4">to use telehealth practice for the telecommunication for evaluating and diagnosing my medical condition.</span></li></ol><p class="c2"><span class="c4"></span></p>
    <ol class="c3 lst-kix_list_3-0" start="2"><li class="c16"><span class="c4">I understand that technical difficulties may occur before or during the telehealth sessions and my appointment cannot be started or ended as intended.</span></li>
    </ol><p class="c2"><span class="c4"></span></p><ol class="c3 lst-kix_list_3-0" start="3"><li class="c15">
    <span class="c4">I accept that the professionals can contact interactive sessions via regular voice communication and video call.</span></li></ol><p class="c6 c9">
    <span class="c4"></span></p><ol class="c3 lst-kix_list_3-0" start="4"><li class="c12">
    <span class="c10">I understand that my records may contain information regarding the diagnosis or treatment of my medical condition and by signing this form, I acknowledge that I have read and understood the same and I freely agreed to disclose my health information and medical records to BrightCare Assist Philippines, Inc.</span></li></ol>
    <p class="c6 c9"><span class="c4"></span></p><p class="c6 c9" id="h.gjdgxs"><span class="c4"></span></p><p class="c6"><span class="c8">Name: <asp:Label ID="lblPatientName" runat="server" Text="Label"></asp:Label></span></p><p class="c6 c9"><span class="c8"></span></p>
    <p class="c6"><span class="c8">Signature:</span></p><p class="c6 c9"><span class="c8"></span></p><p class="c6"><span class="c8">Date:<asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></span></p>
    <p class="c6 c9"><span class="c5"></span></p><p class="c6 c9"><span class="c5"></span></p><p class="c9 c11"><span class="c5"></span></p><p class="c11 c9"><span class="c5"></span></p>
    <p class="c11 c9"><span class="c8"></span></p></body></html>
