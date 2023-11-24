<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ShowHeaderWhenEmpty="true" ID="GrdUser" runat="server" AutoGenerateColumns="false">
            <HeaderStyle CssClass="kt-shape-bg-color-3" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" SortExpression="MobileNo" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
            </Columns>
        </asp:GridView>
        </div>
        <br />
        <div>
            <asp:Button ID="btnPDF" runat="server" Text="Export To PDF" OnClick="btnPDF_Click" />
        </div>
    </form>
</body>
</html>
