using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SodetsoUsersManagement.Models;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using System.IO;


namespace SodetsoUsersManagement.Services
{
    public class UsersManagementService
    {
        //Db Connection string
        string DBCon = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;

        SystemTools _SystemTools = new SystemTools();
        
        //Save use to the database
        public int CreateUser(HttpPostedFileBase file, AddUserModel entity)
        {
            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                entity.Image = _SystemTools.ConvertToBytes(file);

                conn.Open();
                SqlCommand cmd = new SqlCommand("SaveUser", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", entity.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                cmd.Parameters.AddWithValue("@Position", entity.Position);
                cmd.Parameters.AddWithValue("@Password", _SystemTools.EncryptPass(entity.Password));
                cmd.Parameters.AddWithValue("@Image", entity.Image);
                int rs = cmd.ExecuteNonQuery();

                return rs;

            }
        }

        //View users list
        public List<UsersListModel> UsersList()
        {
            List<UsersListModel> _UsersListModel = new List<UsersListModel>();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                using (SqlCommand cmd = new SqlCommand("GetUsers", conn))//call Stored Procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersListModel __UsersListModel = new UsersListModel();
                        __UsersListModel.UserID = reader["UserID"].ToString();
                        __UsersListModel.Firstname = reader["Firstname"].ToString();
                        __UsersListModel.Middlename = reader["Middlename"].ToString();
                        __UsersListModel.Lastname = reader["Lastname"].ToString();
                        __UsersListModel.Gender = reader["Gender"].ToString();
                        __UsersListModel.Email = reader["Email"].ToString();
                        __UsersListModel.Phone = reader["Phone"].ToString();
                        __UsersListModel.Position = reader["Position"].ToString();
                        __UsersListModel.Image = (byte[])reader["Image"];
                        __UsersListModel.DateCreated = reader["DateCreated"].ToString();
                        __UsersListModel.IsActive = int.Parse(reader["IsActive"].ToString());
                        __UsersListModel.IsArchived = int.Parse(reader["IsActive"].ToString());

                        _UsersListModel.Add(__UsersListModel);
                    }
                }
            }

            return _UsersListModel;

        }

        //Deactivate User
        public int DeactivateActivateUser(UsersListModel model)
        {
            using (SqlConnection conn = new SqlConnection(DBCon))
            {               
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeactivateActivateUser", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", model.UserID);
                cmd.Parameters.AddWithValue("@Operation", model.Operation);                
                int rs = cmd.ExecuteNonQuery();

                return rs;

            }
        }

        //View Active users list
        public List<UsersListModel> ActiveUsersList()
        {
            List<UsersListModel> _UsersListModel = new List<UsersListModel>();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                using (SqlCommand cmd = new SqlCommand("GetActiveUsers", conn))//call Stored Procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersListModel __UsersListModel = new UsersListModel();
                        __UsersListModel.UserID = reader["UserID"].ToString();
                        __UsersListModel.Firstname = reader["Firstname"].ToString();
                        __UsersListModel.Middlename = reader["Middlename"].ToString();
                        __UsersListModel.Lastname = reader["Lastname"].ToString();
                        __UsersListModel.Gender = reader["Gender"].ToString();
                        __UsersListModel.Email = reader["Email"].ToString();
                        __UsersListModel.Phone = reader["Phone"].ToString();
                        __UsersListModel.Position = reader["Position"].ToString();
                        __UsersListModel.Image = (byte[])reader["Image"];
                        __UsersListModel.DateCreated = reader["DateCreated"].ToString();
                        __UsersListModel.IsActive = int.Parse(reader["IsActive"].ToString());
                        __UsersListModel.IsArchived = int.Parse(reader["IsActive"].ToString());

                        _UsersListModel.Add(__UsersListModel);
                    }
                }
            }

            return _UsersListModel;

        }

        //View InActive users list
        public List<UsersListModel> InActiveUsersList()
        {
            List<UsersListModel> _UsersListModel = new List<UsersListModel>();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                using (SqlCommand cmd = new SqlCommand("GetInActiveUsers", conn))//call Stored Procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersListModel __UsersListModel = new UsersListModel();
                        __UsersListModel.UserID = reader["UserID"].ToString();
                        __UsersListModel.Firstname = reader["Firstname"].ToString();
                        __UsersListModel.Middlename = reader["Middlename"].ToString();
                        __UsersListModel.Lastname = reader["Lastname"].ToString();
                        __UsersListModel.Gender = reader["Gender"].ToString();
                        __UsersListModel.Email = reader["Email"].ToString();
                        __UsersListModel.Phone = reader["Phone"].ToString();
                        __UsersListModel.Position = reader["Position"].ToString();
                        __UsersListModel.Image = (byte[])reader["Image"];
                        __UsersListModel.DateCreated = reader["DateCreated"].ToString();
                        __UsersListModel.IsActive = int.Parse(reader["IsActive"].ToString());
                        __UsersListModel.IsArchived = int.Parse(reader["IsActive"].ToString());

                        _UsersListModel.Add(__UsersListModel);
                    }
                }
            }

            return _UsersListModel;

        }

        //Remove User
        public int RemoveUser(UsersListModel model)
        {
            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("RemoveUser", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", model.UserID);
                int rs = cmd.ExecuteNonQuery();

                return rs;

            }
        }

        //View Archived users list
        public List<UsersListModel> ArchivedUsersList()
        {
            List<UsersListModel> _UsersListModel = new List<UsersListModel>();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                using (SqlCommand cmd = new SqlCommand("GetArchivedUsers", conn))//call Stored Procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersListModel __UsersListModel = new UsersListModel();
                        __UsersListModel.UserID = reader["UserID"].ToString();
                        __UsersListModel.Firstname = reader["Firstname"].ToString();
                        __UsersListModel.Middlename = reader["Middlename"].ToString();
                        __UsersListModel.Lastname = reader["Lastname"].ToString();
                        __UsersListModel.Gender = reader["Gender"].ToString();
                        __UsersListModel.Email = reader["Email"].ToString();
                        __UsersListModel.Phone = reader["Phone"].ToString();
                        __UsersListModel.Position = reader["Position"].ToString();
                        __UsersListModel.Image = (byte[])reader["Image"];
                        __UsersListModel.DateCreated = reader["DateCreated"].ToString();
                        __UsersListModel.IsActive = int.Parse(reader["IsActive"].ToString());
                        __UsersListModel.IsArchived = int.Parse(reader["IsActive"].ToString());

                        _UsersListModel.Add(__UsersListModel);
                    }
                }
            }

            return _UsersListModel;

        }

        //View user details list
        public List<EditUserModel> ViewUserDetailsList()
        {
            List<EditUserModel> _EditUserModel = new List<EditUserModel>();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                using (SqlCommand cmd = new SqlCommand("GetUsers", conn))//call Stored Procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EditUserModel __EditUserModel = new EditUserModel();
                        __EditUserModel.UserID = int.Parse(reader["UserID"].ToString());
                        __EditUserModel.Firstname = reader["Firstname"].ToString();
                        __EditUserModel.Middlename = reader["Middlename"].ToString();
                        __EditUserModel.Lastname = reader["Lastname"].ToString();
                        __EditUserModel.Gender = reader["Gender"].ToString();
                        __EditUserModel.Email = reader["Email"].ToString();
                        __EditUserModel.Phone = reader["Phone"].ToString();
                        __EditUserModel.Position = reader["Position"].ToString();
                        __EditUserModel.Image = (byte[])reader["Image"];

                        _EditUserModel.Add(__EditUserModel);
                    }
                }
            }

            return _EditUserModel;

        }

        //Update user to the database
        public int UpdateUser(HttpPostedFileBase file, EditUserModel entity)
        {
            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                entity.Image = _SystemTools.ConvertToBytes(file);

                conn.Open();
                SqlCommand cmd = new SqlCommand("EditUser", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", entity.UserID);
                cmd.Parameters.AddWithValue("@Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", entity.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                cmd.Parameters.AddWithValue("@Position", entity.Position);
                cmd.Parameters.AddWithValue("@Password", _SystemTools.EncryptPass(entity.Password));
                cmd.Parameters.AddWithValue("@Image", entity.Image);
                int rs = cmd.ExecuteNonQuery();

                return rs;

            }
        }
    }
}