<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarDetails.aspx.cs" Inherits="CarSearch" %>
<%@ Register TagName="HeaderTag" TagPrefix="HeaderPrefix" Src="~/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Search</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
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

        <asp:DetailsView CssClass="tableClassThin" ID="DetailsView1" runat="server" class="tableClass" cellpadding="5" cellspacing="5"
            DataSourceID="sqlDataSource" DataKeyNames="CarId" AutoGenerateRows="false" Width="80%" ForeColor="Blue" BorderWidth="0px">
            <Fields>
                <asp:ImageField ItemStyle-Wrap="true" DataImageUrlField="ImageName" ControlStyle-Height="70%" DataImageUrlFormatString="~/CarImages/{0}" />
                <asp:BoundField HeaderText="Car Brand" DataField="BrandName" />
                <asp:BoundField HeaderText="Car Model" DataField="ModelName" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="sqlDataSource" runat="server" />

        <table width="100%">
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
    </div>
</body>
</html>
