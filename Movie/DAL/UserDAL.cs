using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Movie.modal;

namespace Movie.DAL
{
    public class UserDAL
    {
       
        public JsonResult GetData(string search,IConfiguration _configuration)
        {
            string query = @"select imbID,Title,Year,Type,Poster from dbo.MovieBrowser where Title like '%" + search+"%'";//@"select first_Name,last_Name,email_Id,password,address from  dbo.user_Details where first_Name LIKE '%"+search+@"%'";
            string img="";
            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserDetailsCon");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    dataReader = 
                        sqlCommand.ExecuteReader();
                   /* if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {

                            img = "http://localhost:5000/Photos/" + dataReader.GetString(4);
                            //reader.GetString(1));
                        }
                    }*/

                    dataTable.Load(dataReader);
                   
                    dataReader.Close();
                    connection.Close();

                }
            }
            return new JsonResult(dataTable);
        }

        public JsonResult GetDetails(int id,IConfiguration _configuration)
        {
            string query = "select * from dbo.MovieBrowser where imbID='" + id+@"'";// @"select first_Name,last_Name,email_Id,password,address from  dbo.user_Details where id = '" + id + @"'";
            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserDetailsCon");
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    dataReader = sqlCommand.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataReader.Close();
                    connection.Close();

                }
            }

            return new JsonResult(dataTable);
        }
       
       
    }
}
/*public void PostData(User_Details user, IConfiguration _configuration)
        {

            string query = @"insert into dbo.user_Details 
               (first_Name,last_Name,email_Id,password,address)
                 values (
                     '" + user.first_Name + @"'
                     ,'" + user.last_Name + @"'
                     ,'" + user.email_Id + @"'
                     ,'" + user.password + @"'
                     ,'" + user.address + @"'
                    )
                     ";
            //DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserDetailsCon");
            //SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    /*dataReader =*/
//sqlCommand.ExecuteReader();
//  dataTable.Load(dataReader);
// dataReader.Close();
/*connection.Close();
                }
            }*/
       // }*/