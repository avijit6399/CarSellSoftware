<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBrand.aspx.cs" Inherits="AddCar" %>
<%@ Register TagName="HeaderTag" TagPrefix="HeaderPrefix" Src="~/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Car</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="page">
    <form id="form1" runat="server">
    <HeaderPrefix:HeaderTag ID="HeaderId" runat="server" />
    <div style="width:100%;">
        <br />
        <br />
        <table class="tableClass" cellpadding="5" cellspacing="5">
            <tr>
                <td colspan="2"><asp:Label ID="msg" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
                <td>Add New Brand of Car</td>
            <td><asp:TextBox ID="txtBrand" runat="server"></asp:TextBox></td>
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
