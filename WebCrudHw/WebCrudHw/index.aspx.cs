using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCrudHw
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //畫面讀取時的事件
            if (!IsPostBack)
            {
                this.GridView1.DataSource = HwDBExecutor.ReadTable1Data();
                this.GridView1.DataBind();
            }
        }

        //點選新增鈕時的事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            string newStuID = this.Text_Student_ID.Text;
            string newName = this.Text_Name.Text;
            Calendar newBir = this.Calendar_Birthday;
            string newBir2 = newBir.SelectedDate.ToString("yyyy/MM/dd");
            string newAddr = this.Text_Address.Text;
            string newEmail = this.Text_Email.Text;
            string newCell = this.Text_CellPhone.Text;
            string newPass = this.Text_Password.Text;
            string newExp = this.RadioButtonList2.Text;
            string newEud = this.RadioButtonList1.Text;
            string newSch = this.DropDownList_School.Text;

            HwDBExecutor.Insert(newStuID, newName, newBir2, newAddr, newEmail, newCell, newPass, newExp, newEud, newSch);
        }

        //點選刪除鈕時的事件
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Response.Write("");
            string newStuID = this.Text_Student_ID.Text;
            HwDBExecutor.Delete(newStuID);

        }
        //點選更新鈕時的事件
        protected void Button3_Click(object sender, EventArgs e)
        {
            string newStuID = this.Text_Student_ID.Text;
            string newName = this.Text_Name.Text;
            Calendar newBir = this.Calendar_Birthday;
            string newBir2 = newBir.SelectedDate.ToString("yyyy/MM/dd");
            string newAddr = this.Text_Address.Text;
            string newEmail = this.Text_Email.Text;
            string newCell = this.Text_CellPhone.Text;
            string newPass = this.Text_Password.Text;
            string newExp = this.RadioButtonList2.Text;
            string newEud = this.RadioButtonList1.Text;
            string newSch = this.DropDownList_School.Text;

            HwDBExecutor.Update(newStuID, newName, newBir2, newAddr, newEmail, newCell, newPass, newExp, newEud, newSch);

        }

        //點選查詢鈕時的事件
        protected void Button4_Click(object sender, EventArgs e)
        {

            string newStuID = this.Text_Student_ID.Text;
            this.GridView1.DataSource = HwDBExecutor.ReadStudent(newStuID);
            this.GridView1.DataBind();


        }

        //點選切換頁面鈕時的事件
        protected void TableChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListData.aspx");
        }
    }
}