<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="HealthAssist.WebForm5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:DropDownList id="myDropDownlistID" width="300px" runat="server">
                <asp:listitem text="Select Color"></asp:listitem>
                <asp:listitem text="Red"></asp:listitem>
                <asp:listitem text="Green"></asp:listitem>
                <asp:listitem text="Blue"></asp:listitem>
                <asp:listitem text="Pink"></asp:listitem>
                <asp:listitem text="Yellow"></asp:listitem>
                <asp:listitem text="Lime"></asp:listitem>
                <asp:listitem text="Black"></asp:listitem>
                <asp:listitem text="Purple"></asp:listitem>
                <asp:listitem text="Deep Pink"></asp:listitem>
                <asp:listitem text="Orange"></asp:listitem>
                <asp:listitem text="Light Pink"></asp:listitem>
            </asp:DropDownList>


     <select id="myDropDownlistID2" name="myDropDownlistID2" runat="server">
                    <option value="IPD">IPD</option>
                    <option value="OPD">OPD</option>                   
                  </select>

     <label>Minimal</label>
                <select class="form-control select2" style="width: 100%;">
                  <option selected="selected">Alabama</option>
                  <option>Alaska</option>
                  <option>California</option>
                  <option>Delaware</option>
                  <option>Tennessee</option>
                  <option>Texas</option>
                  <option>Washington</option>
                </select>

         <script>
             $(function ()
             {
                 $("#myDropDownlistID").select2();
             });

                      
        </script>

    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
</asp:Content>
