using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProcedureCollection
{
    public class StoredProcedureCollection
    {
        //string connectionString = @"Server=LAPTOP-G9SE5H6F\SQLEXPRESS;Database=PrimeDgFoodMigration;User id=sa;Password=123456;";
        //string connectionString = @"Server=103.192.157.58;Database=PrimeDgFood_Test;User id=sa;Password=asd123@"; //Test server
        public (bool success, DataTable entity, string Message) GetProcedureData(string procedureName, List<SqlParameter> parameters, string ConnectionString) { 
         
             
             DataTable dtData = new DataTable();
            (bool success, DataTable entity, string Message) entityObject;
            entityObject.success = false;
            entityObject.entity = new DataTable();
            entityObject.Message = "Faild";
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 120;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
                    }
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dtData);
                    }
                    //SqlDataReader reader = ;

                    //sqlCommand.Connection.Open();
                    //using SqlDataReader reader = sqlCommand.ExecuteReader();
                    //dtData.Load(reader);
                    //sqlCommand.Connection.Close();
                }
                entityObject.success = true;
                entityObject.entity = dtData;
                entityObject.Message = "Data Loaded Successfullly";
            }
            return entityObject;
        }
    }

}
