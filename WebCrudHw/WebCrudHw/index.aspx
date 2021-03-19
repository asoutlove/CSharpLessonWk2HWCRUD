<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebCrudHw.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <%--設定標題、建TextBox,Calendar,RadioButtonList,DropDownList等以輸入值--%>
        <h1>===== 學生資料 =====</h1><br />
        Student_ID <asp:TextBox ID="Text_Student_ID" runat="server"></asp:TextBox><br />
        Name <asp:TextBox ID="Text_Name" runat="server"></asp:TextBox><br />
        Birthday <asp:Calendar ID="Calendar_Birthday" runat="server"></asp:Calendar><br />
        Address <asp:TextBox ID="Text_Address" runat="server"></asp:TextBox><br />
        Email <asp:TextBox ID="Text_Email" runat="server"></asp:TextBox><br />
        CellPhone <asp:TextBox ID="Text_CellPhone" runat="server"></asp:TextBox><br />
        Password <asp:TextBox ID="Text_Password" runat="server"></asp:TextBox><br />
        Experience<asp:RadioButtonList ID="RadioButtonList2" runat="server">
                    <asp:ListItem value ="1" Text="無 "></asp:ListItem>
                    <asp:ListItem value ="2" Text="有 "></asp:ListItem>
        </asp:RadioButtonList>
       Education <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem value ="1" Text="國小 "></asp:ListItem>
                    <asp:ListItem value ="2" Text="國中 "></asp:ListItem>
                    <asp:ListItem value ="3" Text="高中 "></asp:ListItem>
                    <asp:ListItem value ="4" Text="大學 "></asp:ListItem>
                    <asp:ListItem value ="5" Text="研究所 "></asp:ListItem>
                 </asp:RadioButtonList>
        School <asp:DropDownList ID="DropDownList_School" runat="server">
                    <asp:ListItem Value="1" Text ="學校A"></asp:ListItem>
                    <asp:ListItem Value="2" Text ="學校B"></asp:ListItem>
                    <asp:ListItem Value="3" Text ="學校C"></asp:ListItem>
               </asp:DropDownList><br /><br />

        <%--建立Button 用來增、刪、修、查和切換表--%>
        <asp:Button ID="Button1" runat="server" Text="INSERT" OnClick="Button1_Click" /> &nbsp;
        <asp:Button ID="Button2" runat="server" Text="DELETE" OnClick="Button2_Click" /> &nbsp;
        <asp:Button ID="Button3" runat="server" Text="UPDATE" OnClick="Button3_Click" /> &nbsp;
        <asp:Button ID="Button4" runat="server" Text="READ" OnClick="Button4_Click" />&nbsp;
        <asp:Button ID="TableChange" runat="server" Text="切換至選課紀錄表" OnClick="TableChange_Click" />
        <br /><br />

        <%--用GridView來顯示資料表--%>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    </form>
</body>
</html>
