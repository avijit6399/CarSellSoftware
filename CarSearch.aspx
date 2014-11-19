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
    <div>
        <table border="10px">
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
                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" Width="80%">
                        <RowStyle BackColor = "#E7E7FF" ForeColor = "#4A3C8C" />
                        <HeaderStyle BackColor = "#4A3C8C" Font-Bold = "True" ForeColor = "#F7F7F7" />
                        <Columns>
                            <asp:BoundField HeaderText="Car Brand" DataField="BrandName" />
                            <asp:BoundField HeaderText="Car Model"  DataField="ModelName" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <img src='carimages/<%# Eval("ImageName") %>' height="50%" width="50%">
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
    </div>
</body>
</html>
