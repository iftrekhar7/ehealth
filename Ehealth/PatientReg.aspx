<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientReg.aspx.cs" Inherits="Ehealth.PatientReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            height: 273px;
        }
        .auto-style2 {
            width: 45px;
        }
        .auto-style4 {
            width: 145px;
        }
        .auto-style5 {
            width: 120px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">Name :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" Display="Dynamic"
                             ForeColor="Red" ErrorMessage="First name is required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style5">User Name :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="20"></asp:TextBox>    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" Display="Dynamic"
                             ForeColor="Red" ErrorMessage="User name is required" SetFocusOnError="True"></asp:RequiredFieldValidator>      
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style5">Password :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" Display="Dynamic"
                            ForeColor="Red" ErrorMessage="Password is required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Confirm Password :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" Display="Dynamic"
                            ForeColor="Red" ErrorMessage="Rewrite your password" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4" Display="Dynamic"
                            ForeColor="Red" ErrorMessage="Password is not match" SetFocusOnError="true"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Gender :</td>
                    <td class="auto-style2">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="RadioButtonList1"  Display="Dynamic"
                           SetFocusOnError="true"  ForeColor="Red" ErrorMessage="Select your gender"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Current Address :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox5" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox5" Display="Dynamic"
                            SetFocusOnError="true" ForeColor="Red" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Email Address :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox6" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox6" Display="Dynamic"
                             SetFocusOnError="true" ForeColor="Red" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="Please write valid Email"
                            SetFocusOnError="true" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Mobile number :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox7" runat="server" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox7" Display="Dynamic"
                             ForeColor="Red" SetFocusOnError="true" ErrorMessage="Mobile number is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Date of Birth:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" TextMode="Date" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox8" Display="Dynamic"
                            ForeColor="Red" SetFocusOnError="true" ErrorMessage="Birthday is require"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                    </td>
                    <td>
                        <input id="Reset1" type="reset" value="reset" />
                    </td>
                </tr>

            </table>
    </div>
    </form>
</body>
</html>
