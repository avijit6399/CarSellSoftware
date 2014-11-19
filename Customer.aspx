<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" %>
<%@ Register TagName="HeaderTag" TagPrefix="HeaderPrefix" Src="~/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers's Information</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="page">
    <form id="form1" runat="server">
    <HeaderPrefix:HeaderTag ID="HeaderId" runat="server" />
    <div>
        <table border="10px">
            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                <td>Last Name:</td>
                <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td> 
            </tr>
            <tr>
                 <td>Password:</td>
                <td><asp:TextBox ID="txtPassword" runat="server" Textmode="Password"></asp:TextBox></td>
            </tr>
             <tr>
                 <td>Date Of Birth:</td>
                 <td>Day</td>
                 <td>Month</td>
                 <td>Year</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList></td>
                <td><asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList></td>
                <td><asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Sex:</td>
                <td><asp:DropDownList ID="ddlSex" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>City:</td>
                <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>State:</td>
                <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Country:</td>
                <td><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Pin:</td>
                <td><asp:TextBox ID="txtPin" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Phone Number:</td>
                <td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></td>
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
