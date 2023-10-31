using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using HR;
using HR.BLL;
using HR.BLL.DTO;
using HR.DAL.Smtp;
using HR.Static;
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
        //private readonly AppSettingBll Service;
        //public AppSettingController(AppSettingBll service)
        //{
        //    Service = service;
        //}
        
        string conn = SmtpConfig.GetConnectionString();
        string dconn = SmtpConfig.DynamicConnection();

        public object ActivisionSystem(bool isActive)
        {
            try
            {
                int active = isActive ? 1 : 0;
                string checkActivisionSystemIsExistsSql = @"if not exists (select * from sysobjects where name='ActivisionSystem' and xtype='U')
                    create table ActivisionSystem ( IsActive bit not null )
                    if not exists (select * from ActivisionSystem) 
                    INSERT INTO ActivisionSystem (IsActive) VALUES (0)",
                    updateActivisionSystemSql = @"update ActivisionSystem set IsActive = " + active;

                BaseDataAccess dataAccess = new BaseDataAccess(conn);
                var connection = dataAccess.GetConnection();

                int createAndInsert = dataAccess.ActivisionSystem(checkActivisionSystemIsExistsSql, connection),
                updateActivisionSystem = dataAccess.ActivisionSystem(updateActivisionSystemSql, connection);

                return new
                {
                    Status = 200,
                    IsActive = isActive
                };
            }
            catch
            {
                return new
                {
                    Status = 500,
                    IsActive = isActive
                };
            }
        }

        public object Activision()
        {
            try
            {
                BaseDataAccess dataAccess = new BaseDataAccess(conn);
                var connection = dataAccess.GetConnection();
                string sql = @"select * from ActivisionSystem";
                ActivisionSystem activisionSystem = dataAccess.CheckActivisionSystem(sql, connection);
                
                return new { Status = 200, IsActive = activisionSystem?.IsActive };
            }
            catch { return new {  Status = 500, IsActive = false }; }
        }

        public object Find(string productKey, string LangKey = "ar")
        {
                string sql = "select * from AppSetting where AppSetting.ProductKey = '" + productKey + "'",
                message = LangKey == "ar" ? "تمت العمليه بنجاح" : "operation accomplished successfully";

            BaseDataAccess dataAccess = new BaseDataAccess(dconn);
            var connection = dataAccess.GetConnection();
            try
            {
                ApiAppSetting app = dataAccess.GetResult(sql, connection);
                if(app == null)
                {
                    sql = "select * from AppSetting where AppSetting.IsDefault = " + 1 + "";
                    app = dataAccess.GetResult(sql, connection);
                    message = LangKey == "ar" ? "لم يتم العثور على بيانات وتم ارجاع اللينك الاساسي" : "No data was found and the original link was returned";
                }

                return new { Status = 200, message = message, Url = app?.Url };
            }
            catch
            {
                return new { Status = 500, message = LangKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred",
                    Url = ""};
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

    public ApiAppSetting GetResult(string sql, SqlConnection connection)
    {
        using (var command = new SqlCommand(sql, connection))
        {
            ApiAppSetting app = null;
            try
            {
                SqlDataReader rdr = command.ExecuteReader();   
                while (rdr.Read())
                {
                    app = new ApiAppSetting();
                    app.Url = rdr["Url"].ToString();
                    app.ProductKey = rdr["ProductKey"].ToString();
                    app.IsDefault = bool.Parse(rdr["IsDefault"].ToString());
                }
                rdr.Close();
            }
            catch (Exception Ex)
            {
                app = null;
                string msg = Ex.Message.ToString();
            }
            connection.Close();
            return app;
        }
    }

    public int ActivisionSystem(string sql, SqlConnection connection)
    {
        using (var command = new SqlCommand(sql, connection))
        {
            var res = command.ExecuteNonQuery();
            return res;
        }
    }

    public ActivisionSystem CheckActivisionSystem(string sql, SqlConnection connection)
    {
        using (var command = new SqlCommand(sql, connection))
        {
            ActivisionSystem app = null;
            try
            {
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    app = new ActivisionSystem();
                    app.IsActive = bool.Parse(rdr["IsActive"].ToString());
                }
                rdr.Close();
            }
            catch (Exception Ex)
            {
                app = null;
                string msg = Ex.Message.ToString();
            }
            connection.Close();
            return app;
        }
    }
}