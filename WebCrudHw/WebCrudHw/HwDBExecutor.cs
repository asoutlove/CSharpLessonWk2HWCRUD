using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebCrudHw
{
    public class HwDBExecutor
    {
        //查詢學生資料表
        public static DataTable ReadTable1Data()
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";
            
            //SQL語法 WHERE結果讓畫面先呈現查不到資料的狀態
            string queryString =
             $@" SELECT * FROM Student
                 WHERE Student_ID ='0';";


            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創立新的空表
                    DataTable dt = new DataTable();

                    //填入值
                    dt.Load(reader);

                    //關閉資料庫連線
                    reader.Close();

                    //回傳
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        } 

        //將資料存入學生資料表的方法
        public static void Insert(string Student_ID, string Name, string Birthday, string Address, string Email, string CellPhone, string Password, string Experience, string Education, string School)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 新增資料
            string queryString =
                $@" INSERT INTO Student
                       (Student_ID , Name, Birthday, Address, Email , CellPhone, Experience, Education , School)
                    VALUES
                       ( @Student_ID , @Name, @Birthday, @Address, @Email , @CellPhone , @Experience, @Education , @School)";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Student_ID", Student_ID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Birthday", Birthday);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@CellPhone", CellPhone);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Experience", Experience);
                command.Parameters.AddWithValue("@Education", Education);
                command.Parameters.AddWithValue("@School", School);

                try
                {
                    connection.Open();
                    int totalChangeRows = command.ExecuteNonQuery();
                    Console.WriteLine("Total change" + totalChangeRows + "Rows.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();


            }
        }

        //將資料從學生資料表刪除的方法  (以Student_ID判斷)
        public static void Delete(string Student_ID)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 以Student_ID判斷 刪除資料
            string queryString =
                $@"DELETE FROM Student WHERE Student_ID  = @Student_ID";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Student_ID", Student_ID);

                try
                {
                    connection.Open();
                    int totalChangeRows = command.ExecuteNonQuery();
                    // Console.WriteLine("Total change" + totalChangeRows + "Rows.");
                    HttpContext.Current.Response.Write("Total change " + totalChangeRows + "Rows.");

                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex.Message);
                }
                Console.ReadLine();
            }
        }

        //從學生資料表更新資料的方法  (以Student_ID判斷)
        public static void Update(string Student_ID, string Name, string Birthday, string Address, string Email, string CellPhone, string Password, string Experience, string Education, string School)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 以Student_ID判斷更新資料
            string queryString =
                $@" UPDATE Student
                      SET
                         Name= @Name, Birthday=@Birthday, Address=@Address, Email=@Email , CellPhone=@CellPhone, Experience= @Experience, Education=@Education , School=@School
                      WHERE
                         Student_ID= @Student_ID ";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@Student_ID", Student_ID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Birthday", Birthday);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@CellPhone", CellPhone);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Experience", Experience);
                command.Parameters.AddWithValue("@Education", Education);
                command.Parameters.AddWithValue("@School", School);

                try
                {
                    connection.Open();

                    int totalChangRows = command.ExecuteNonQuery();
                    Console.WriteLine("Total chang" + totalChangRows + " Rows.");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        //從學生資料表讀取資料的方法  (以Student_ID判斷)
        public static DataTable ReadStudent(string Student_ID)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 以Student_ID判斷 查詢資料
            string queryString =
             $@" SELECT * FROM Student
                WHERE Student_ID = @Student_ID;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Student_ID", Student_ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }



        //查詢選課紀錄表
        public static DataTable ReadTable2Data()
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 WHERE結果讓畫面先呈現查不到資料的狀態
            string queryString =
             $@" SELECT * FROM Registration_Record 
                WHERE Record_ID ='0';";


            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Record_ID ", "R000000001");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        //將資料存入選課紀錄表的方法
        public static void InsertToRegister(string Record_ID, string Student_ID, string Course_ID)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 新增資料
            string queryString =
                $@" INSERT INTO Registration_Record
                       (Record_ID, Student_ID ,Course_ID)
                    VALUES
                       (@Record_ID, @Student_ID ,@Course_ID)";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Record_ID", Record_ID);
                command.Parameters.AddWithValue("@Student_ID", Student_ID);
                command.Parameters.AddWithValue("@Course_ID", Course_ID);

                try
                {
                    connection.Open();
                    int totalChangeRows = command.ExecuteNonQuery();
                    Console.WriteLine("Total change" + totalChangeRows + "Rows.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();


            }
        }

        //將資料從選課紀錄表刪除的方法  (以Record_ID)
        public static void DeleteFromRegister(string Record_ID)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            string queryString =
                $@"DELETE FROM Registration_Record  WHERE Record_ID  = @Record_ID";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Record_ID", Record_ID);

                try
                {
                    connection.Open();
                    int totalChangeRows = command.ExecuteNonQuery();
                    // Console.WriteLine("Total change" + totalChangeRows + "Rows.");
                    HttpContext.Current.Response.Write("Total change " + totalChangeRows + "Rows.");

                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex.Message);
                }
                Console.ReadLine();
            }
        }

        //從選課紀錄表更新資料的方法  (以Record_ID判斷)
        public static void UpdateToRegister(string Record_ID, string Student_ID, string Course_ID)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 以Record_ID判斷更新資料
            string queryString =
            $@" UPDATE Registration_Record
                      SET
                         Student_ID=@Student_ID,Course_ID=@Course_ID
                      WHERE
                         Record_ID=@Record_ID";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Record_ID", Record_ID);
                command.Parameters.AddWithValue("@Student_ID", Student_ID);
                command.Parameters.AddWithValue("@Course_ID", Course_ID);

                try
                {
                    connection.Open();
                    int totalChangeRows = command.ExecuteNonQuery();
                    Console.WriteLine("Total change" + totalChangeRows + "Rows.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();


            }
        }

        //從選課紀錄表讀取資料的方法  (以Record_ID判斷)
        public static DataTable ReadRegister(string Record_ID)
        {
            //連接資料庫路徑
            string connectionString =
                "Data Source=localhost\\SQLExpress;Initial Catalog=CSharpLessionHWwk2; Integrated Security=true";

            //SQL語法 以Record_ID判斷 查詢資料
            string queryString =
             $@" SELECT * FROM Registration_Record
                WHERE Record_ID = @Record_ID;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Record_ID", Record_ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

    }
}