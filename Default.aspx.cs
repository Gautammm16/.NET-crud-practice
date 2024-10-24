using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection("Data Source=GAUTAMM\\SQLEXPRESS;Initial Catalog=retest;User ID=sa;Password=sa123");
        cn.Open();
        SqlCommand cmd = new SqlCommand("insert into student values(@username,@email,@password,@dob,@hobby,@gender,@city)",cn);
        cmd.Parameters.AddWithValue("@username", TextBox1.Text);
        cmd.Parameters.AddWithValue("@email", TextBox2.Text);
        cmd.Parameters.AddWithValue("@password", TextBox3.Text);
        cmd.Parameters.AddWithValue("@dob", TextBox4.Text);
        cmd.Parameters.AddWithValue("@hobby", CheckBoxList1.SelectedValue);
        cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
        cmd.Parameters.AddWithValue("@city", DropDownList1.SelectedValue);
        cmd.ExecuteNonQuery();
        cn.Close();

        ScriptManager.RegisterStartupScript(this, GetType(),"script", "alert('added successfully')", true);


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection("Data Source=GAUTAMM\\SQLEXPRESS;Initial Catalog=retest;User ID=sa;Password=sa123");
        cn.Open();
        SqlCommand cmd = new SqlCommand("select * from student", cn);
        //cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
        cn.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filename = Path.GetFileName(FileUpload1.FileName);
            string folderpath = Server.MapPath("~/uploads/");

            string filepath = Path.Combine(folderpath, filename);
            FileUpload1.SaveAs(filepath);

            ScriptManager.RegisterStartupScript(this, GetType(),"script", "alert('file uploaded')", true);
          
        }
    }
}