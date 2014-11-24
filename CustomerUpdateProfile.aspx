<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerUpdateProfile.aspx.cs" Inherits="CustomerUpdateProfile" %>
<%@ Register TagName="HeaderTag" TagPrefix="HeaderPrefix" Src="~/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Search</title>
    <style>
        /* css for timepicker */
        .ui-timepicker-div .ui-widget-header { margin-bottom: 8px; }
        .ui-timepicker-div dl { text-align: left; }
        .ui-timepicker-div dl dt { float: left; clear:left; padding: 0 0 0 5px; }
        .ui-timepicker-div dl dd { margin: 0 10px 10px 45%; }
        .ui-timepicker-div td { font-size: 90%; }
        .ui-tpicker-grid-label { background: none; border: none; margin: 0; padding: 0; }

        .ui-timepicker-rtl{ direction: rtl; }
        .ui-timepicker-rtl dl { text-align: right; padding: 0 5px 0 0; }
        .ui-timepicker-rtl dl dt{ float: right; clear: right; }
        .ui-timepicker-rtl dl dd { margin: 0 45% 10px 10px; }
    </style>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.custom.js"></script>
    <script src="Scripts/jquery-ui-timepicker-addon.js"></script>
    
    
</head>
<body>
    <div class="page">
    <form id="form1" runat="server">
    <HeaderPrefix:HeaderTag ID="HeaderId" runat="server" />
    <h2 style="text-align:left">
        &nbsp;Car Details/Schedule Appointment
    </h2>
        <script type="text/javascript">
            $(function () {
                $('#txtDateTime').datetimepicker();
            });

        </script>
    <div>
        <div style="text-align:center">
             <div style="margin:0 auto">
                 <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true" EnableViewState="false" />
             </div>
         </div>
        <br /> <br />
        <table class="tableClass">
            <tr>
                <td>FirstName</td>
                <td><asp:TextBox ID="txtFirstName" runat="server" /></td>
            </tr>
            <tr>
                <td>LastName</td>
                <td><asp:TextBox ID="txtLastName" runat="server" /></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:TextBox ID="txtEmail" runat="server" /></td>
            </tr>
            <tr>
                <td>DOB (MM/DD/YYYY)</td>
                <td><asp:TextBox ID="txtDob" runat="server" />
                    <asp:CompareValidator ControlToValidate="txtDob" Type="Date" Operator="LessThan" 
                        ID="validateDob" ErrorMessage="Enter Valid Date" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Sex</td>
                <td>
                    <asp:DropDownList ID="listGender" runat="server">
                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td><asp:TextBox ID="txtAddress" runat="server" /></td>
            </tr>
            <tr>
                <td>City</td>
                <td><asp:TextBox ID="txtCity" runat="server" /></td>
            </tr>
            <tr>
                <td>State</td>
                <td><asp:TextBox ID="txtState" runat="server" /></td>
            </tr>
            <tr>
                <td>Country</td>
                <td><asp:TextBox ID="txtCountry" runat="server" /></td>
            </tr>
            <tr>
                <td>Pin</td>
                <td><asp:TextBox ID="txtPin" runat="server" /></td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td><asp:TextBox ID="txtPhoneNumber" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="Update" OnClick="btnSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="sqlDataSource" runat="server" />
        <br />
        <br />
    </div>
    </form>
    </div>
</body>
</html>
