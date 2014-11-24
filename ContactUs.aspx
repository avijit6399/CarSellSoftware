<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Test" %>
<%@ Register TagName="HeaderTag" TagPrefix="HeaderPrefix" Src="~/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="page">
    <form id="form1" runat="server">
    <HeaderPrefix:HeaderTag ID="HeaderId" runat="server" />
    
    <div class="tablestyle">
    <div>
          Those people who are interested about our project and for any kind of problem the can contact us. We are very greatful to every
          user for visiting this project. For any further details please contact with us at
    </div>
    <div style="border:10px;width:50%;height:600px;background-color:#0099CC;text-align:left;margin:0 auto">
        <table class="tablestyle">
            <tr>
                
                <td><asp:Label ID="Label1" runat="server" Text="NAME:"></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text="Arnab Charan"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text="arnab1234.a@gmail.com"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label5" runat="server" Text="Phone Number:"></asp:Label></td>
                <td><asp:Label ID="Label6" runat="server" Text="9474815679"></asp:Label></td>
            </tr>
        </table>
         <table class="tablestyle">
            <tr>
               
                <td><asp:Label ID="Label7" runat="server" Text="NAME:"></asp:Label></td>
                <td><asp:Label ID="Label8" runat="server" Text="Souvik Paul"></asp:Label></td>
            </tr>
            <tr>
               
                <td><asp:Label ID="Label9" runat="server" Text="Email:"></asp:Label></td>
                <td><asp:Label ID="Label10" runat="server" Text="souvikpaul5@gmail.com"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label11" runat="server" Text="Phone Number:"></asp:Label></td>
                <td><asp:Label ID="Label12" runat="server" Text="8927466350"></asp:Label></td>
            </tr>
        </table>
         <table class="tablestyle">
            <tr>
                
                <td><asp:Label ID="Label13" runat="server" Text="NAME:"></asp:Label></td>
                <td><asp:Label ID="Label14" runat="server" Text="Debasish Sasmal"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label15" runat="server" Text="Email:"></asp:Label></td>
                <td><asp:Label ID="Label16" runat="server" Text="deb.sasmal0000@gmail.com"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label17" runat="server" Text="Phone Number:"></asp:Label></td>
                <td><asp:Label ID="Label18" runat="server" Text="8647928493"></asp:Label></td>
            </tr>
        </table>
         <table class="tablestyle">
            <tr>
                
                <td><asp:Label ID="Label19" runat="server" Text="NAME:"></asp:Label></td>
                <td><asp:Label ID="Label20" runat="server" Text="Tamalika Pattanayak"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label21" runat="server" Text="Email:"></asp:Label></td>
                <td><asp:Label ID="Label22" runat="server" Text="tamalika@gmail.com"></asp:Label></td>
            </tr>
            <tr>
                
                <td><asp:Label ID="Label23" runat="server" Text="Phone Number:"></asp:Label></td>
                <td><asp:Label ID="Label24" runat="server" Text="9775550471"></asp:Label></td>
            </tr>
        </table>
    </div>
    </div>
   
    </form>
    </div>
    
</body>
</html>
