<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Test" %>
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
        <div style="border:10px;width:100%;height:700px;background-color:Black;text-align:center;margin:0 auto">
             <br />
              <asp:Image ID="Image4" runat="server" ImageUrl="~/CarImages/CR-V.jpg" Height="201px" Width="371px"/>
              <asp:Image ID="Image1" runat="server" ImageUrl="~/CarImages/scorpio2.jpg" Height="201px" Width="371px"/>
              <br />
              <div class="tablestyle">
              There are so many websites are available in the internet market for buying car. Online car search and buy is now a days very 
              important to every busy person for saving time. This sites provides you to search different brand,model of cars and get
              appointment of your own choice to buy your selected car at the lowest rate. 
              </div>
              <div class="tablestyle">
                Benefits to customer:-<br />
                1.Time saving<br />
                2.Search all car of available brand<br />
                3.Error free search and get appointment with us to buy your selected car<br />
                4.search car without registration<br />
              </div> 
              <div style="border:10px;width:100%;height:700px;font-size:x-large;background-color:Black;text-align:left;margin:0 auto">
                How it works?<br />
                Using Searcar button you can easily find out your choicable cars. If you want to buy a car from us then you
                can register and take appointment with your choicable date
              </div>
          </div>          
    </form>
    </div>
</body>
</html>
