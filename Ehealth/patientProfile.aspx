<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patientProfile.aspx.cs" Inherits="Ehealth.patientProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Welcome...."></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Logout"  />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            
            <table  style="width:100%;">
                <tr>
                    <td style="width:20%;">Upload History</td>
                    <td>
                       
                        <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                       
                    </td>
                </tr>
            </table> 
    </form>
</body>
</html>
