<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Symptom_1.aspx.cs" Inherits="Ehealth.Symptom_1" %>

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
                <td>
                    For
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1">me</asp:ListItem>
                        <asp:ListItem Value="2">someone else</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Gender
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                       <asp:ListItem Value="1">Male</asp:ListItem>
                       <asp:ListItem Value="2">Female</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList1"  Display="Dynamic"
                         SetFocusOnError="true"  ForeColor="Red" ErrorMessage="Select your gender"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Age
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Value="-1">choose one</asp:ListItem>
                        <asp:ListItem Value="1">Check for someone 0-2 years</asp:ListItem>
                        <asp:ListItem Value="2">Check for someone 3- 6 years</asp:ListItem>
                        <asp:ListItem Value="3">Check for someone 7-12 years</asp:ListItem>
                        <asp:ListItem Value="4">13-17  years</asp:ListItem>
                        <asp:ListItem Value="5">18-24  years</asp:ListItem>
                        <asp:ListItem Value="6">25-34  years</asp:ListItem>
                        <asp:ListItem Value="7">35-44  years</asp:ListItem>
                        <asp:ListItem Value="8">45-54  years</asp:ListItem>
                        <asp:ListItem Value="9">55-64  years</asp:ListItem>
                        <asp:ListItem Value="10">Over 65  years</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Zip Code
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="10">optional</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email Address
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" ControlToValidate="TextBox2" MaxLength="20">optional</asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="" ControlToValidate="TextBox2" Display="Dynamic"
                         ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Male.png" />
    </div>
    </form>
</body>
</html>
