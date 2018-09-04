using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DunlyStad_Web.Code;


using Advantage.Data.Provider;

namespace DunlyStad_Web
{
    public static class AdsHelper
    {
        public static CallbackObject GetMappedObject<T>(object obj)
                where T : class
        {
            AdsConnection connection = CreateConnection();
            connection.Open();

            var cbo = new CallbackObject();

            var context = new AdsDataContext(connection);

            try
            {
                cbo.obj = context.Get<T>(obj);

                cbo.success = true;
            }
            catch (Exception e)
            {
                cbo.success = false;
                cbo.info = e.Message + ", SQL: " + context.LastSqlCommandText;
            }
            finally
            {
                connection.Close();
            }

            return cbo;
        }

        public static Callback SaveMappedObject(object obj)
        {
            AdsConnection connection = CreateConnection();
            connection.Open();

            Callback cb = new Callback();
            cb.success = false;

            AdsDataContext context = new AdsDataContext(connection);

            try
            {
                context.SaveOrUpdate(obj);

                cb.tknkey = (uint)context.GetAutoIncPrimaryKeyValue(obj);
                cb.success = true;
            }
            catch (Exception e)
            {
                cb.success = false;
                cb.info = e.Message + ", SQL: " + context.LastSqlCommandText;
            }
            finally
            {
                connection.Close();
            }

            return cb;
        }

        public static CallbackDataset GetMappedObjects<T>(string sqlFilterExpression, string sqlOrderExpression) where T : class
        {
            return GetMappedObjects<T>(null, sqlFilterExpression, sqlOrderExpression);
        }

        public static CallbackDataset GetMappedObjects<T>(int? topCount, string sqlFilterExpression, string sqlOrderExpression) where T : class
        {
            AdsConnection connection = CreateConnection();

            CallbackDataset cbd = new CallbackDataset();

            AdsDataContext context = new AdsDataContext(connection);

            try
            {
                cbd.ds = new DataSet();

                context.Fill<T>(cbd.ds, topCount, sqlFilterExpression, sqlOrderExpression);

                cbd.success = true;
            }
            catch (Exception e)
            {
                cbd.success = false;
                cbd.info = e.Message + ", SQL: " + context.LastSqlCommandText;
            }
            finally
            {
                connection.Close();
            }

            return cbd;
        }

        public static Callback DeleteMappedObjects<T>(string sqlFilterExpression) where T : class
        {
            AdsConnection connection = CreateConnection();
            connection.Open();

            Callback cb = new Callback();
            cb.success = false;

            AdsDataContext context = new AdsDataContext(connection);

            try
            {
                context.Delete<T>(sqlFilterExpression);

                cb.success = true;
            }
            catch (Exception e)
            {
                cb.success = false;
                cb.info = e.Message + ", SQL: " + context.LastSqlCommandText;
            }
            finally
            {
                connection.Close();
            }

            return cb;
        }

        public static AdsConnection CreateConnection()
        {
            return new AdsConnection(Cachen.settings.dbConn);
        }

        public static DataTable GetSqlTable(string Sql, string tableName)
        {
            DataTable dt = GetSqlTable(Sql).Copy();
            dt.TableName = tableName;
            return dt;

        }

        public static DataTable GetSqlTable(string Sql)
        {
            try
            {
                DataSet dsTemp = GetSqlResult(Sql);
                return dsTemp.Tables[0];
            }
            catch (Exception ee)
            {
                return null;
            }

        }

        public static DataSet GetSqlResult(string sql)
        {
            return GetSqlResult(sql, null);
        }

        public static DataSet GetSqlResult(string sql, AdsParameterCollection parameters)
        {
            AdsConnection connection = CreateConnection();

            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                AdsCommand selectCommand = new AdsCommand(sql, connection);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        selectCommand.Parameters.Add(parameter);
                }

                AdsDataAdapter adapter = new AdsDataAdapter(selectCommand);
                adapter.Fill(ds, "RESULT");
            }
            finally
            {
                connection.Close();
            }

            return ds;
        }

        public static void _executeScalar(String sSql)
        {
            AdsConnection connection = CreateConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                AdsCommand command = new AdsCommand(sSql, connection);
                command.ExecuteScalar();
                command.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }

}