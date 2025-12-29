using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskManagement_application.Models;

namespace TaskManagement_application.DAL
{
    public class TaskDAL
    {
        SqlConnection con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);

        public DataTable GetTask()
        {
            SqlCommand cmd = new SqlCommand("sp_GetTasks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAllTasks()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT
                T.TaskId,
                T.TaskTitle,
                T.TaskDescription,
                T.TaskDueDate,
                T.TaskStatus,
                T.TaskRemarks,
                T.CreatedOn,
                T.LastUpdatedOn,

                U1.UserId AS CreatedById,
                U1.UserName AS CreatedByName,

                U2.UserId AS LastUpdatedById,
                U2.UserName AS LastUpdatedByName

            FROM Tasks T
            LEFT JOIN Users U1 ON T.CreatedBy = U1.UserId
            LEFT JOIN Users U2 ON T.LastUpdatedBy = U2.UserId
            ORDER BY T.CreatedOn DESC";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.Fill(dt);
            }

            return dt;
        }


        public void InsertTask(TaskModel task)
        {
            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["dbms"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskTitle", SqlDbType.NVarChar, 200).Value = task.TaskTitle;
                    cmd.Parameters.Add("@TaskDescription", SqlDbType.NVarChar).Value = task.TaskDescription;
                    cmd.Parameters.Add("@TaskDueDate", SqlDbType.Date).Value = task.TaskDueDate;
                    cmd.Parameters.Add("@TaskStatus", SqlDbType.NVarChar, 50).Value = task.TaskStatus;
                    cmd.Parameters.Add("@TaskRemarks", SqlDbType.NVarChar, 500).Value = task.TaskRemarks;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = 1;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateTask(TaskModel task)
        {
            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["dbms"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TaskId", SqlDbType.Int).Value = task.TaskId;
                    cmd.Parameters.Add("@TaskTitle", SqlDbType.NVarChar, 200).Value = task.TaskTitle;
                    cmd.Parameters.Add("@TaskDescription", SqlDbType.NVarChar).Value = task.TaskDescription;
                    cmd.Parameters.Add("@TaskDueDate", SqlDbType.Date).Value = task.TaskDueDate;
                    cmd.Parameters.Add("@TaskStatus", SqlDbType.NVarChar, 50).Value = task.TaskStatus;
                    cmd.Parameters.Add("@TaskRemarks", SqlDbType.NVarChar, 500).Value = task.TaskRemarks;
                    cmd.Parameters.Add("@LastUpdatedBy", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@LastUpdatedOn", SqlDbType.DateTime).Value = DateTime.Now;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public DataTable SearchTasks(string searchText)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["dbms"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SearchTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SearchText", SqlDbType.NVarChar).Value = searchText;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public TaskModel GetTaskById(int id)
        {
            TaskModel task = new TaskModel();

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["dbms"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetTaskById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TaskId", SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    task.TaskId = Convert.ToInt32(dr["TaskId"]);
                    task.TaskTitle = dr["TaskTitle"].ToString();
                    task.TaskDescription = dr["TaskDescription"].ToString();
                    task.TaskDueDate = Convert.ToDateTime(dr["TaskDueDate"]);
                    task.TaskStatus = dr["TaskStatus"].ToString();
                    task.TaskRemarks = dr["TaskRemarks"].ToString();
                }
            }
            return task;
        }


        public void DeleteTask(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteTask", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskId", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}