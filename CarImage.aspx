<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarImage.aspx.cs" Inherits="CarImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Image ID="carImage" runat="server" Width="50%" Height="50%" />
                    <asp:HiddenField id="hiddenField" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>New Car Image:</td>
                <td><asp:FileUpload id="fileUpload"  runat="server" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" /></td>
            </tr>
            
        </table>
    </div>
    </form>
</body>
</html>
