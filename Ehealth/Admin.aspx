<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Ehealth.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
        <asp:Button ID="btnViewAlbum" runat="server" Text="View History" OnClick="btnViewAlbum_Click" />
    <div>
        <table>
            <tr>
                    <td colspan="2">
                       <asp:DataList ID="dlImages" runat="server" RepeatColumns="4"
                             RepeatDirection="Horizontal" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                           <AlternatingItemStyle BackColor="#DCDCDC" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <ItemTemplate>
                            <table border="0" style="border-bottom-color:#60BAEA;border-top-color:#60BAEA;border-left-color:#60BAEA;border-left-color:#60BAEA;">
                                <tr>
                                    <td>
                                        <asp:Image  ID="img" runat="server" BorderStyle="Solid" BorderColor="#e0ddd7" BorderWidth="2" Height="150" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>'
                                        Width="150px" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                       </asp:DataList>
                   </td>
               </tr>
        </table>
        </div>
    </form>
</body>
</html>
