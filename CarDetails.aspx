<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarDetails.aspx.cs" Inherits="CarSearch" %>
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
    
    <script type="text/javascript">
        $(function () {
            $('#txtDateTime').datetimepicker();
        });
        
    </script>
</head>
<body>
    <div class="page">
    <form id="form1" runat="server">
    <HeaderPrefix:HeaderTag ID="HeaderId" runat="server" />
    <h2 style="text-align:left">
        &nbsp;Car Details/Schedule Appointment
    </h2>
    <div>
        <br />
        <br />
        <table width="80%"  border="0" style="margin:0 auto;text-align:center">
            <tr>
                <td><asp:TextBox ID="txtDateTime" Text="Click to Select Date/Time" runat="server" />
                    &nbsp;<asp:Button ID="btnSchedule" runat="server" Text="Schedule Appointment" Enabled="true" OnClick="btnSchedule_Click" /></td>
            </tr>
        </table>
        <br /> <br />
        <asp:DetailsView CssClass="tableClassThin" ID="DetailsView1" runat="server" class="tableClass" cellpadding="5" cellspacing="5"
            DataSourceID="sqlDataSource" DataKeyNames="CarId" AutoGenerateRows="false" Width="80%" ForeColor="Blue" BorderWidth="0px">
            <Fields>
                <asp:ImageField ItemStyle-Wrap="true" DataImageUrlField="ImageName" ControlStyle-Height="60%" DataImageUrlFormatString="~/CarImages/{0}" />
                <asp:BoundField HeaderText="Car Brand" DataField="BrandName" />
                <asp:BoundField HeaderText="Car Model" DataField="ModelName" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="sqlDataSource" runat="server" />
        <asp:HiddenField ID="txtCarId" runat="server" />
    </div>
    </form>
    </div>
</body>
</html>
