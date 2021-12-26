using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using HR;
using HR.BLL;
using HR.BLL.DTO;
using HR.Tables.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HRApp.Areas.Api
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class AppSettingController : ControllerBase
    {
        private readonly AppSettingBll Service;
        public AppSettingController(AppSettingBll service)
        {
            Service = service;
        }

        //public object Find(string productKey, string LangKey="ar")
        //{
        //    var result = Service.Find(productKey, LangKey);
        //    return result;
        //}

        //public object Find(string productKey, string LangKey = "ar")
        //{
        //    var result = Service.Find(productKey, LangKey);
        //    return result;
        //}

        public object Find(string productKey, string LangKey = "ar")
        {
            string conLocal = "Data Source=DESKTOP-S02Q4PR\\SQL2014;Initial Catalog=AppUrl;User Id=softgo;Password=A271185b;MultipleActiveResultSets=true",
                conOnline = "Data Source=SQL5079.site4now.net;Initial Catalog=db_a44da5_apphrurl;User Id=db_a44da5_apphrurl_admin;Password=A271185b; MultipleActiveResultSets = true",
                sql = "select * from AppSetting where AppSetting.ProductKey = '"+ productKey + "'";

            BaseDataAccess dataAccess = new BaseDataAccess(conOnline);
            var connection = dataAccess.GetConnection();
            try
            {
                AppSetting app = dataAccess.GetResult(sql, connection);
                if(app == null)
                {
                    sql = "select * from AppSetting where AppSetting.IsDefault = " + 1 + "";
                    app = dataAccess.GetResult(sql, connection);
                }

                return new
                {
                    Status = 200,
                    message = app == null ? (LangKey == "ar" ? "لا توجد بيانات لهذه البيانات" : "There is no data for this data")
                    : LangKey == "ar" ? "تمت العمليه بنجاح" : "operation accomplished successfully",
                    Url = app?.Url
                };
            }
            catch
            {
                return new
                {
                    Status = 500,
                    message = LangKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred",
                    Url = "",
                };
            }
        }
    }
}


public class BaseDataAccess
{
    protected string ConnectionString { get; set; }

    public BaseDataAccess()
    {
    }

    public BaseDataAccess(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(this.ConnectionString);
        if (connection.State != ConnectionState.Open)
            connection.Open();
        return connection;
    }

    public DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType)
    {
        SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
        command.CommandType = commandType;
        return command;
    }

    public SqlParameter GetParameter(string parameter, object value)
    {
        SqlParameter parameterObject = new SqlParameter(parameter, value != null ? value : DBNull.Value);
        parameterObject.Direction = ParameterDirection.Input;
        return parameterObject;
    }

    public SqlParameter GetParameterOut(string parameter, SqlDbType type, object value = null, ParameterDirection parameterDirection = ParameterDirection.InputOutput)
    {
        SqlParameter parameterObject = new SqlParameter(parameter, type); ;

        if (type == SqlDbType.NVarChar || type == SqlDbType.VarChar || type == SqlDbType.NText || type == SqlDbType.Text)
        {
            parameterObject.Size = -1;
        }

        parameterObject.Direction = parameterDirection;

        if (value != null)
        {
            parameterObject.Value = value;
        }
        else
        {
            parameterObject.Value = DBNull.Value;
        }

        return parameterObject;
    }

    public int ExecuteNonQuery(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
    {
        int returnValue = -1;

        try
        {
            using (SqlConnection connection = this.GetConnection())
            {
                DbCommand cmd = this.GetCommand(connection, procedureName, commandType);

                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                returnValue = cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            //LogException("Failed to ExecuteNonQuery for " + procedureName, ex, parameters);
            throw;
        }

        return returnValue;
    }

    public object ExecuteScalar(string procedureName, List<SqlParameter> parameters)
    {
        object returnValue = null;

        try
        {
            using (DbConnection connection = this.GetConnection())
            {
                DbCommand cmd = this.GetCommand(connection, procedureName, CommandType.StoredProcedure);

                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                returnValue = cmd.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
            //LogException("Failed to ExecuteScalar for " + procedureName, ex, parameters);
            throw;
        }

        return returnValue;
    }

    public DbDataReader GetDataReader(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
    {
        DbDataReader ds;

        try
        {
            DbConnection connection = this.GetConnection();
            {
                DbCommand cmd = this.GetCommand(connection, procedureName, commandType);
                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                ds = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        catch (Exception ex)
        {
            //LogException("Failed to GetDataReader for " + procedureName, ex, parameters);
            throw;
        }

        return ds;
    }

    public AppSetting GetResult(string sql, SqlConnection connection)
    {
        using (var command = new SqlCommand(sql, connection))
        {
            AppSetting app = null;
            try
            {
                SqlDataReader rdr = command.ExecuteReader();  // vs also alternatives, command.ExecuteReader();  or await command.ExecuteNonQueryAsync();
                while (rdr.Read())
                {
                    app = new AppSetting();
                    app.Url = rdr["Url"].ToString();
                    app.ProductKey = rdr["ProductKey"].ToString();
                    app.IsDefault = bool.Parse(rdr["IsDefault"].ToString());
                }
                rdr.Close();
            }
            catch (Exception Ex)
            {
                app = null;
                connection.Close();
                string msg = Ex.Message.ToString();
            }
            return app;
        }
    }
}