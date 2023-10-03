using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Drawing;
using System.Data.Common;



namespace OrganizasyonProjem.Models
{
    public class Dap
    {

        public static string connectionString = @"Server=DESKTOP-1PBLKBH\SQLEXPRESS; initial Catalog=CalismaOrganizasyon; user Id=sa; password=12345;";






        public static void ExecuteReturn(string procAdi, DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {

                db.Open();
                db.Execute(procAdi, param, commandType: CommandType.StoredProcedure);

            }

        }

        public static IEnumerable<T> Listeleme<T>(string procAdi, DynamicParameters param = null)
        {

            using (SqlConnection db = new SqlConnection(connectionString))
            {

                db.Open();
                return db.Query<T>(procAdi, param, commandType: CommandType.StoredProcedure);

            }




        }
    }
}