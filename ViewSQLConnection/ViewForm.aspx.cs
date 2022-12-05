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
        bool TextChanged = false;
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True");
        SqlCommand cmd;
        DataTable DT = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (TextChanged)
            {
                Session["data"] = null;
            }
            BindMethod();
            TextChanged = false;
            

        }

        private void BindMethod()
        {
            if (Session["data"] == null)
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

                    Session["data"] = DT;
                }

                else
                {
                    lblCheck.Visible = true;
                    lblCheck.Text = "THERE IS NO DATA SUCH AS !!!";
                    this.grdView.Visible = false;
                }

                conn.Close();
            }


            grdView.DataSource = Session["data"];
            grdView.DataBind();
            grdView.Visible = true;
            lblCheck.Visible = false;
        }

        protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            BindMethod();
        }

        protected void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            TextChanged = true;
        }
    }
}