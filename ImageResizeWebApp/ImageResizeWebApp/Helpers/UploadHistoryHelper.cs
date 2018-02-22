using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageResizeWebApp.Controllers;
using ImageResizeWebApp.Data;
using ImageResizeWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ImageResizeWebApp.Models;

namespace ImageResizeWebApp.Helpers
{
    public class UploadHistoryHelper
    {

       
        public void Insert(string url, string IP, string SQLConnection)
        {


                var sql = "INSERT INTO uploadHistory (url, ip) VALUES(@url, @ip)";

                using (SqlConnection cn = new SqlConnection(SQLConnection))
                    using(SqlCommand cmd = new SqlCommand(sql,cn))
                    {
                    cmd.Parameters.Add("@url", System.Data.SqlDbType.NVarChar,500).Value=  url;
                    cmd.Parameters.Add("@ip", System.Data.SqlDbType.NVarChar,30).Value= IP;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

        }

    }
}
