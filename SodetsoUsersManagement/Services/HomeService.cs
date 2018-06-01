﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SodetsoUsersManagement.Models;
using System.Configuration;
using System.Data.SqlClient;


using System.Net;
using System.Web.Mvc;
using System.IO;

namespace SodetsoUsersManagement.Services
{
    public class HomeService
    {
        //Db Connection string
        string DBCon = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        SystemTools _SystemTools = new SystemTools();

        public LoginResultModel UserAuthenticate(LoginModel model)
        {
            LoginResultModel __LoginResultModel = new LoginResultModel();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AuthenticateUser", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", _SystemTools.EncryptPass(model.Password));
                //int rs = cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    __LoginResultModel.UserID = int.Parse(reader["UserID"].ToString());
                    __LoginResultModel.Firstname = reader["Firstname"].ToString();
                    __LoginResultModel.Position = reader["Position"].ToString();
                    __LoginResultModel.Email = reader["Email"].ToString();
                }

                return __LoginResultModel;

            }

           
        }

        public DashboardModels DashboardStats()
        {
            DashboardModels _DashboardModels = new DashboardModels();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DashboardStats", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _DashboardModels.UsersList = reader["UsersList"].ToString();
                    _DashboardModels.ActiveUsers = reader["ActiveUsers"].ToString();
                    _DashboardModels.InActiveUsers = reader["InActiveUsers"].ToString();
                    _DashboardModels.ArchivedUsers = reader["ArchivedUsers"].ToString();
                }

                return _DashboardModels;

            }
        }

    }
}