<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListData.aspx.cs" Inherits="WebCrudHw.ListData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <%--設定標題、建TextBox以輸入值--%>
        <h1>===== 選課紀錄 =====</h1><br />
        Record_ID <asp:TextBox ID="TextBoxRecordID" runat="server"></asp:TextBox><br />
        Student_ID <asp:TextBox ID="TextBoxStudentID" runat="server"></asp:TextBox><br />
        Course_ID <asp:TextBox ID="TextBoxCourseID" runat="server"></asp:TextBox><br />

        <%--建立Button 用來增、刪、修、查和切換表--%>
        <asp:Button ID="ButtonInsert" runat="server" Text="INSERT" OnClick="ButtonInsert_Click" />&nbsp;
        <asp:Button ID="ButtonDelete" runat="server" Text="DELETE" OnClick="ButtonDelete_Click" />&nbsp;
        <asp:Button ID="ButtonUpdate" runat="server" Text="UPDATE" OnClick="ButtonUpdate_Click" />&nbsp;
        <asp:Button ID="ButtonRead" runat="server" Text="READ" OnClick="ButtonRead_Click" />&nbsp;
        <asp:Button ID="TableChange2" runat="server" Text="切換至學生資料表" OnClick="TableChange2_Click" />
         <br /><br />

        <%--用GridView來顯示資料表--%>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
