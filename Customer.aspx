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
    <h2 style="text-align:left">
        &nbsp;Customer Sign Up
    </h2>
    <div>
        <br /><br />
        <table class="tableClass" cellpadding="5" cellspacing="5">
            <tr>
                <td colspan="2"><asp:Label ID="msg" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtFirstName" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtLastName" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Enter a valid email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td> 
            </tr>
            <tr>
                 <td>Password:</td>
                <td><asp:TextBox ID="txtPassword" runat="server" Textmode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>Date Of Birth:</td>
                <td colspan="3">Day: <asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>
                    Month: <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
                    Year: <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                </td>
             </tr>
            <tr>
                <td>Sex:</td>
                <td><asp:DropDownList ID="ddlSex" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtAddress" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>City:</td>
                <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtCity" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>State:</td>
                <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtState" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>Country:</td>
                <td><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtCountry" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>Pin:</td>
                <td><asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtPin" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>Phone Number:</td>
                <td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtPhoneNumber" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
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
