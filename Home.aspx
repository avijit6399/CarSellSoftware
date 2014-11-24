<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Test" %>
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
        <div style="border:10px;width:50%;height:200px;background-color:Red;text-align:right;margin:0 auto">
            <div style="width:100%;height:20px;background-color:Yellow;float:left">
            </div>
             <div style="border:10px;width:40%;height:100px;background-color:Green;float:left">
            </div>
            <div style="border:10px;width:40%;height:100px;background-color:Blue;float:right">
            </div>
        </div>
        <div>
             <br />
              <asp:Image ID="Image4" runat="server" ImageUrl="~/CarImages/CR-V.jpg" Height="201px" Width="371px"/>             
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
        </div>
    </form>
    </div>
</body>
</html>
