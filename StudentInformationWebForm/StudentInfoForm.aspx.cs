using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentInformationWebForm
{
    public partial class StudentInfoForm : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["HomeTaskConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_DDLBind";
                connection.Open();
                sectionDropDownList.DataSource = command.ExecuteReader();
                sectionDropDownList.DataTextField = "SectionName";
                sectionDropDownList.DataValueField = "SectionName";
                sectionDropDownList.DataBind();
                connection.Close();
                sectionDropDownList.Items.Insert(0, new ListItem("---Select Section---"));
            }

            

        }  //Done
        private void BindGrid()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand("SP_GridviewDataBind", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = command.Parameters.Add("@p_StudentId", SqlDbType.VarChar);
                parameter.Value = 0;

                SqlDataAdapter sda = new SqlDataAdapter(command);

                sda.Fill(ds);

                showAllStudentGridView.DataSource = ds;
                showAllStudentGridView.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        } //Done

        protected void saveButton_Click(object sender, EventArgs e)
        {

            #region SP Call
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_SaveStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@p_StudentId", SqlDbType.VarChar).Value = idTextBox.Text;
                    command.Parameters.Add("@p_Name", SqlDbType.VarChar).Value = nameTextBox.Text;
                    command.Parameters.Add("@p_Section", SqlDbType.VarChar).Value = sectionDropDownList.Text;
                    command.Parameters.Add("@p_FatherName", SqlDbType.VarChar).Value = fatherNameTextBox.Text;
                    command.Parameters.Add("@p_MotherName", SqlDbType.VarChar).Value = motherNameTextBox.Text;
                    command.Parameters.Add("@p_PhoneNo", SqlDbType.VarChar).Value = phoneNoTextBox.Text;

                    connection.Open();
                    
                    string rowAffected = command.ExecuteNonQuery().ToString();
                    connection.Close();

                    if (rowAffected.Length > 0)
                    {
                        BindGrid();
                        messageLabel.Text = "Data Save Successfully.";
                    }
                    else
                    {
                        messageLabel.Text = "Data Save Failed.";
                    }

                }
            }
            #endregion
        } //Done

        protected void deleteButton_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_DeleteRecord", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // add parameter
                command.Parameters.Add("@p_StudentId", SqlDbType.VarChar);
                command.Parameters["@p_StudentId"].Value = searchIdTextBox.Text;
                

                // open connection, execute command, close connection
                connection.Open();
                string rowAffected = command.ExecuteNonQuery().ToString();
                connection.Close();

                if (rowAffected.Length > 0)
                {
                    BindGrid();

                    messageLabel.Text = "Data has been Deleted Successfully.";


                }
                else
                {
                    messageLabel.Text = "Data Deleted Failed.";
                }
                searchIdTextBox.Text = "";
            }

        } //Done

        protected void findButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@p_StudentId", searchIdTextBox.Text);

                    connection.Open();
                    
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = command;
                    command.ExecuteNonQuery();

                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        messageLabel.Text = "Data Found.";
                        idTextBox.Text = ds.Tables[0].Rows[0]["studentId"].ToString();
                        sectionDropDownList.Text = ds.Tables[0].Rows[0]["section"].ToString();
                        nameTextBox.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        fatherNameTextBox.Text = ds.Tables[0].Rows[0]["fatherName"].ToString();
                        motherNameTextBox.Text = ds.Tables[0].Rows[0]["motherName"].ToString();
                        phoneNoTextBox.Text = ds.Tables[0].Rows[0]["phoneNo"].ToString();
                    }
                    else
                    {
                        messageLabel.Text = "Data not found!";
                    }
                    connection.Close();

                    showAllStudentGridView.DataSource = ds;
                    showAllStudentGridView.DataBind(); // only showing the found data from gridview 
                }
                
            }

        } //Done

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateStudentInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@p_StudentId", idTextBox.Text);
                    command.Parameters.AddWithValue("@p_Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("@p_Section", sectionDropDownList.Text);
                    command.Parameters.AddWithValue("@p_FatherName", fatherNameTextBox.Text);
                    command.Parameters.AddWithValue("@p_MotherName", motherNameTextBox.Text);
                    command.Parameters.AddWithValue("@p_PhoneNo", phoneNoTextBox.Text);

                    connection.Open();
                    string rowAffected = command.ExecuteNonQuery().ToString();
                    connection.Close();

                    if (rowAffected.Length > 0)
                    {
                        BindGrid();

                        messageLabel.Text = "Data Updated Successfully.";


                    }
                    else
                    {
                        messageLabel.Text = "Data Update Failed.";
                    }
                }
            
            }

        } //Done

        protected void newButton_Click(object sender, EventArgs e)
        {
            sectionDropDownList.Text = "---Select Section---";
            idTextBox.Text = "";
            nameTextBox.Text = "";
            fatherNameTextBox.Text = "";
            motherNameTextBox.Text = "";
            phoneNoTextBox.Text = "";
            searchIdTextBox.Text = "";
        }   //Done using ASP.Net C#

        protected void showAllStudentGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionDropDownList.Text = showAllStudentGridView.SelectedRow.Cells[1].Text;
            idTextBox.Text = showAllStudentGridView.SelectedRow.Cells[2].Text;
            nameTextBox.Text = showAllStudentGridView.SelectedRow.Cells[3].Text;
            fatherNameTextBox.Text = showAllStudentGridView.SelectedRow.Cells[4].Text;
            motherNameTextBox.Text = showAllStudentGridView.SelectedRow.Cells[5].Text;
            phoneNoTextBox.Text = showAllStudentGridView.SelectedRow.Cells[6].Text;

            #region
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand("SP_SelectStudent", connection))
            //{
            //    command.CommandType = CommandType.StoredProcedure;

            //    connection.Open();
            //    command.ExecuteNonQuery();

            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    sda.SelectCommand = command;

            //    DataSet ds = new DataSet();
            //    sda.Fill(ds);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        messageLabel.Text = "Data Found.";
            //        sectionDropDownList.Text = ds.Tables[0].Rows[0]["@p_Section"].ToString();
            //        idTextBox.Text = ds.Tables[0].Rows[0]["@p_StudentId"].ToString();
            //        nameTextBox.Text = ds.Tables[0].Rows[0]["@p_Name"].ToString();
            //        fatherNameTextBox.Text = ds.Tables[0].Rows[0]["@p_FatherName"].ToString();
            //        motherNameTextBox.Text = ds.Tables[0].Rows[0]["@p_MotherName"].ToString();
            //        phoneNoTextBox.Text = ds.Tables[0].Rows[0]["@p_PhoneNo"].ToString();

            //    }
            //    else
            //    {
            //        messageLabel.Text = "Data not found!";
            //    }
            //    connection.Close();
            //}
            #endregion

        }  //Done Using ASP.Net

        protected void printButton_Click(object sender, EventArgs e)
        {

        }
    }
}