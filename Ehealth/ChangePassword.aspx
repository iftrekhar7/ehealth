<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Ehealth.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style="width:350px;">
    <legend>Change password</legend>
    <table>

    <tr>
    <td>User Name:</td>
    <td>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
            ErrorMessage="Please enter User Name" ControlToValidate="txtUserName"
            Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </td>
    </tr>

    <tr>
    <td>Old Password:</td>
    <td>
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server"
            ErrorMessage="Please enter old password" ControlToValidate="txtOldPassword"
            Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>

     <tr>
    <td>New Password:</td>
    <td>
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server"
            ErrorMessage="Please enter new password" ControlToValidate="txtNewPassword"
            Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
         </td>
    </tr>

         <tr>
    <td>Confirm new Password: </td>
    <td>
        <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvConfirmNewPassword" runat="server"
            ErrorMessage="Please re-enter password to confirm"
            ControlToValidate="txtConfirmNewPassword" Display="Dynamic" ForeColor="Red"
            SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmvConfirmPassword" runat="server"
            ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNewPassword"
            Display="Dynamic" ErrorMessage="New and confirm password didn't match"
            ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
    </td>
    </tr>

     <tr>
    <td> &nbsp;</td>
         <td>
             <asp:Button ID="btnSubmit" runat="server" Text="Change Password"
             onclick="btnSubmit_Click" />
         </td>
    </tr>
     <tr>
    <td colspan="2">
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
         </td>
    </tr>
    </table>
    </fieldset>   
    </div>
    </form>
</body>
</html>
