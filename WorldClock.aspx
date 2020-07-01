<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorldClock.aspx.cs" Inherits="KaffaTestApplication.WorldClock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnShowTime" runat="server" Text="Show" OnClick="btnShowTime_Click" />

            <span id="spanCurrentDateTime" runat="server"></span>
        </div>
    </form>
</body>
</html>
