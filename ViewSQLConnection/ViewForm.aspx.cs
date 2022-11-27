using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ViewSQLConnection
{
    public partial class ViewForm : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True");
        SqlCommand cmd;
        DataTable DT = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("DataSearch", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CatgName", txtCategoryName.Text);
            cmd.Parameters.Add(new SqlParameter()
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@finalvalue",
                SqlDbType = SqlDbType.Int
            });
            cmd.ExecuteNonQuery();
            if (cmd.Parameters["@finalvalue"].Value.ToString() == "1")
            {
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                grdView.DataSource = DT;
                grdView.DataBind();
                lblCheck.Visible = false;
            }
            
            else 
            {
                lblCheck.Visible = true;
                lblCheck.Text = "THERE IS NO DATA SUCH AS !!!";
                this.grdView.Visible = false;
            }
            
            conn.Close();
        }
    }
}