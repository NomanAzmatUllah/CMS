using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace coachingSystem.Models
{
    public class db
    {

        private string connection = ConfigurationManager.ConnectionStrings["cmsEntities"].ConnectionString;


        public DataTable getiddatabase(string Query)
        {
            SqlConnection connectionstr = new SqlConnection(connection);
            connectionstr.Open();
            SqlDataAdapter dr = new SqlDataAdapter(Query, connectionstr);
            DataTable data = new DataTable();
            dr.Fill(data);
            connectionstr.Close();
            return data;
        }
    }
}