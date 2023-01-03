<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication10.WebUserControl1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        height: 26px;
    }
    .auto-style3 {
        height: 26px;
        width: 128px;
    }
</style>
<table id="table1" class="auto-style1">
    <tr>
        <td class="auto-style3">

<asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="135px">
    <asp:ListItem>Excellent </asp:ListItem>
    <asp:ListItem>Very Good</asp:ListItem>
    <asp:ListItem>Good</asp:ListItem>
    <asp:ListItem>Accceptable</asp:ListItem>
    <asp:ListItem>Poor</asp:ListItem>
</asp:RadioButtonList>
        </td>
        <td class="auto-style2">
            <br />
            <asp:Label ID="Label2" runat="server" Text="Excellent:"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Ver Good:"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Good:"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Acceptable:"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Poor:"></asp:Label>
        </td>
    </tr>
</table>
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Vote" />
<br />


