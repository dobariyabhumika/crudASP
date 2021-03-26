using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class User : System.Web.UI.Page
    {
        private string strconstring = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        DataSet _dtSet;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsersData();
            }
            submitBtn.Visible = true;
            updateBtn.Visible = false;
        }

        public void ClearControls()
        {
            name.Text = "";
            address.Text = "";
            mobileno.Text = "";
            email.Text = "";
        }

        public void ShowAlertMessage(string error)
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }

        public void CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(strconstring);
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = sqlConnection;
        }

        public void OpenConnection()
        {
            _sqlCommand.Connection.Open();
        }

        public void CloseConnection()
        {
            _sqlCommand.Connection.Close();
        }

        public void DisposeConnection()
        {
            _sqlCommand.Connection.Dispose();
        }

        public void BindUsersData()
        {
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "user1";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@op_type", "select");
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                usersList.DataSource = _dtSet;
                usersList.DataBind();
            }
            catch (Exception ex)
            {
                ShowAlertMessage("Error :" + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "user1";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@op_type", "insert");

                _sqlCommand.Parameters.AddWithValue("@name", Convert.ToString(name.Text.ToString().Trim()));
                _sqlCommand.Parameters.AddWithValue("@address", Convert.ToString(address.Text.ToString().Trim()));
                _sqlCommand.Parameters.AddWithValue("@mobileno", Convert.ToString(mobileno.Text.ToString().Trim()));
                _sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(email.Text.ToString().Trim()));

                int result = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
                if (result > 0)
                {
                    ShowAlertMessage("Data inserted Successfully.");
                    BindUsersData();
                    ClearControls();
                }
                else
                {
                    ShowAlertMessage("Failed");
                }
            }
            catch (Exception ex)
            {
                ShowAlertMessage("Error :" + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "user1";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@op_type", "update");

                _sqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(Session["id"]));
                _sqlCommand.Parameters.AddWithValue("@name", Convert.ToString(name.Text.ToString().Trim()));
                _sqlCommand.Parameters.AddWithValue("@address", Convert.ToString(address.Text.ToString().Trim()));
                _sqlCommand.Parameters.AddWithValue("@mobileno", Convert.ToString(mobileno.Text.ToString().Trim()));
                _sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(email.Text.ToString().Trim()));

                int result = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
                if (result > 0)
                {
                    ShowAlertMessage("Data updated Successfully.");
                    usersList.EditIndex = -1;
                    BindUsersData();
                    ClearControls();
                }
                else
                {
                    ShowAlertMessage("Failed");
                }
            }
            catch (Exception ex)
            {
                ShowAlertMessage("Error :" + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void usersList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            submitBtn.Visible = false;
            updateBtn.Visible = true;

            int RowIndex = e.NewEditIndex;
            Label usrId = (Label)usersList.Rows[RowIndex].FindControl("lblId");
            Session["id"] = usrId.Text;

            name.Text = ((Label)usersList.Rows[RowIndex].FindControl("lblName")).Text.ToString().Trim();
            address.Text = ((Label)usersList.Rows[RowIndex].FindControl("lblAddress")).Text.ToString().Trim();
            mobileno.Text = ((Label)usersList.Rows[RowIndex].FindControl("lblMobileno")).Text.ToString().Trim();
            email.Text = ((Label)usersList.Rows[RowIndex].FindControl("lblEmail")).Text.ToString().Trim();
        }

        protected void usersList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "user1";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@op_type", "delete");

                Label usrId = (Label)usersList.Rows[e.RowIndex].FindControl("lblId");
                _sqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(usrId.Text));

                int result = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
                if (result > 0)
                {
                    ShowAlertMessage("Data deleted Successfully.");
                    usersList.EditIndex = -1;
                    BindUsersData();
                    ClearControls();
                }
                else
                {
                    ShowAlertMessage("Failed");
                }
            }
            catch (Exception ex)
            {
                ShowAlertMessage("Error :" + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void usersList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            usersList.PageIndex = e.NewPageIndex;
            BindUsersData();
        }
    }
}