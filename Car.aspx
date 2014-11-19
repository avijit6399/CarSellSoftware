<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Car.aspx.cs" Inherits="Car" %>
<%@ Register TagName="HeaderTag" TagPrefix="HeaderPrefix" Src="~/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car's information</title>
     <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <div class="page">
    <form id="form1" runat="server">
    <HeaderPrefix:HeaderTag ID="HeaderId" runat="server" />
    <div>
        <table border="10px" >
           
             <tr>
                <td>Car Color:</td>
                <td><asp:TextBox ID="txtCarColor" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Car Price:</td>
                <td><asp:TextBox ID="txtCarPrice" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Car Engine Type:</td>
                <td><asp:DropDownList ID="ddlEngineType" runat="server"></asp:DropDownList></td>
            </tr>
             <tr>
                <td>Car Mileage:</td>
                <td><asp:TextBox ID="txtMileage" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Car Image:</td>
                <td><asp:FileUpload id="fileUpload"  runat="server" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" /></td>
            </tr>
            
        </table>
    
    </div>
    </form>
    </div>
</body>
</html>
