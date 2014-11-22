<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarSearch.aspx.cs" Inherits="CarSearch" %>
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
        &nbsp;Search a Car
    </h2>
    <div>
        <br />
        <br />
        <table class="tableClass" cellpadding="5" cellspacing="5">
            <tr>
                <td>Brand Name Of The Car:</td>
                <td><asp:DropDownList ID="ddlBrandName" OnSelectedIndexChanged="onchange_ddlBrandName" autoPostBack="True"  runat="server"></asp:DropDownList></td>
            </tr>
             <tr>
                <td>Model Of The Car:</td>
                <td><asp:DropDownList ID="ddlModel" runat="server"></asp:DropDownList></td>
            </tr>
             <tr>
                <td>Engine Type Of The Car:</td>
                <td><asp:DropDownList ID="ddlEngineType" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" /></td>
            </tr>
        
        </table>
        <table width="100%">
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
         <table width="100%">
            <tr>
                <td>
                    <div class="rounded_corners" style="width:80%;margin:0 auto" id="divGridView" runat="server">
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#3AC0F2"
                            HeaderStyle-ForeColor="White" RowStyle-BackColor="white" AlternatingRowStyle-BackColor="White"
                            RowStyle-ForeColor="#3A3A3A">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Car Brand" DataTextField="BrandName" DataNavigateUrlFields="CarId" DataNavigateUrlFormatString="CarDetails.aspx?carid={0}" />
                                <asp:BoundField HeaderText="Car Model"  DataField="ModelName" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <img src='carimages/<%# Eval("ImageName") %>' height="50%" width="50%">
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
    </div>
</body>
</html>
