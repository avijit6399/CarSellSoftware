<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Header" %>
<div class="header">
            <div class="title">
                <h1>
                    CarSell.com 
                </h1>
            </div>
            <div class="loginDisplay">
                    <div id="divLinkInfo" runat="server">
                        <a href="~/Login.aspx" ID="HeadLoginStatusLink" runat="server">Customer Log In</a> | 
                        <a href="~/AdminLogin.aspx" ID="A1" runat="server"> Admin Log In</a>
                    </div>
                    <br />
                    <div id="divLoginInfo" runat="server" visible="False">
                        Welcome <span class="bold"><asp:Label ID="HeadLoginName" runat="server" /></span>!
                        <asp:HyperLink ID="logout" Text="Logout" NavigateUrl="Logout.aspx" runat="server" />
                    </div>
            </div>
            <div class="clear hideSkiplink">
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        
                       </Items>                      
                </asp:Menu>
            </div>
 </div>