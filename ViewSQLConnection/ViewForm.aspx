<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewForm.aspx.cs" Inherits="ViewSQLConnection.ViewForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="ViewForm.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCategoryName" runat="server" Text="Category Name" CssClass ="label"></asp:Label>
            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="txtBox" OnTextChanged="txtCategoryName_TextChanged"></asp:TextBox>
        </div>
        <asp:Label ID="lblCheck" runat="server" Text="" CssClass ="lblCheck"></asp:Label>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="button" />
        <asp:GridView PageSize="5" AllowPaging="true" OnPageIndexChanging="grdView_PageIndexChanging" ID="grdView" runat="server" CssClass ="grdView">
        </asp:GridView>
    </form>
</body>
</html>
