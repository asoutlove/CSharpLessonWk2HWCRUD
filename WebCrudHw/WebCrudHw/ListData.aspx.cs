using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCrudHw
{
    public partial class ListData : System.Web.UI.Page
    {
        //畫面讀取時的事件
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = HwDBExecutor.ReadTable2Data();
            this.GridView1.DataBind();

        }

        //點選新增鈕時的事件
        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            string newRecID = this.TextBoxRecordID.Text;
            string newStuID = this.TextBoxStudentID.Text;
            string newCouID = this.TextBoxCourseID.Text;

            HwDBExecutor.InsertToRegister(newRecID, newStuID, newCouID);

        }

        //點選刪除鈕時的事件
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            this.Response.Write("");
            string newRecID = this.TextBoxRecordID.Text;
            HwDBExecutor.DeleteFromRegister(newRecID);
        }

        //點選更新鈕時的事件
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string newRecID = this.TextBoxRecordID.Text;
            string newStuID = this.TextBoxStudentID.Text;
            string newCouID = this.TextBoxCourseID.Text;

            HwDBExecutor.UpdateToRegister(newRecID, newStuID, newCouID);

        }

        //點選查詢鈕時的事件
        protected void ButtonRead_Click(object sender, EventArgs e)
        {
            string newRecID = this.TextBoxRecordID.Text;
            this.GridView1.DataSource = HwDBExecutor.ReadRegister(newRecID);
            this.GridView1.DataBind();
        }

        //點選切換頁面鈕時的事件
        protected void TableChange2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}