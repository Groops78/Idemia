using Idemia.Common.Entities;
using Idemia.Common.Helpers;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.DAL.Base
{
    public class OracleDao
    {   
            #region "Database Helper Methods"
            private OracleConnection _sharedConnection;
            public OracleConnection SharedConnection
            {
                get
                {
                    if (_sharedConnection == null)
                    {
                        _sharedConnection = new OracleConnection(Configs.ConnectionString);
                    }
                    return _sharedConnection;
                }
                set
                {
                    _sharedConnection = value;
                }
            }
            // Constructors
            public OracleDao() { }
            public OracleDao(OracleConnection connection)
            {
                this.SharedConnection = connection;
            }
            public OracleDao(string connectionstring)
            {
                this.SharedConnection = new OracleConnection(connectionstring);
            }
            // GetDbOracleCommand
            public OracleCommand GetOracleCommand(string sqlQuery)
            {
                OracleCommand command = new OracleCommand();
                command.Connection = SharedConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                return command;
            }
            // GetDbSprocCommand
            public OracleCommand GetSprocCommand(string sprocName)
            {
                OracleCommand command = new OracleCommand(sprocName);
                command.Connection = SharedConnection;
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
            // CreateNullParameter
            public OracleParameter CreateNullParameter(string name, OracleDbType paramType)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = paramType;
                parameter.ParameterName = name;
                parameter.Value = null;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            // CreateNullParameter - with size for nvarchars
            public OracleParameter CreateNullParameter(string name, OracleDbType paramType, int size)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = paramType;
                parameter.ParameterName = name;
                parameter.Size = size;
                parameter.Value = null;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            // CreateOutputParameter
            public OracleParameter CreateOutputParameter(string name, OracleDbType paramType)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = paramType;
                parameter.ParameterName = name;
                parameter.Direction = ParameterDirection.Output;
                return parameter;
            }
            // CreateOuputParameter - with size for nvarchars
            public OracleParameter CreateOutputParameter(string name, OracleDbType paramType, int size)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = paramType;
                parameter.Size = size;
                parameter.ParameterName = name;
                parameter.Direction = ParameterDirection.Output;
                return parameter;
            }
            // CreateParameter - uniqueidentifier
            public OracleParameter CreateParameter(string name, Guid value)
            {
                if (value.Equals(NullValues.NullGuid))
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.Varchar2);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.Varchar2;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            // CreateParameter - int
            public OracleParameter CreateParameter(string name, int value)
            {
                if (value == NullValues.NullInt)
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.Int16);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.Int32;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            public OracleParameter CreateParameter(string name, int? value)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Int32;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            public OracleParameter CreateParameter(string name, char value)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Char;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            // CreateParameter - decimal
            public OracleParameter CreateParameter(string name, decimal value)
            {
                if (value == NullValues.NullInt)
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.Decimal);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.Decimal;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            public OracleParameter CreateParameter(string name, decimal? value)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Decimal;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            // CreateParameter - Number
            public OracleParameter CreateParameter(string name, double value)
            {
                if (value == NullValues.NullInt)
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.Double);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.Double;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            // CreateParameter - datetime
            public OracleParameter CreateParameter(string name, DateTime value)
            {
                if (value == NullValues.NullDateTime)
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.Date);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.Date;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            public OracleParameter CreateParameter(string name, DateTime? value)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.Date;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            // CreateParameter - nvarchar
            public OracleParameter CreateParameter(string name, string value)
            {
                if (String.IsNullOrEmpty(value))
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.NVarchar2);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.NVarchar2;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            // CreateParameter - nvarchar
            public OracleParameter CreateParameter(string name, string value, int size)
            {
                if (String.IsNullOrEmpty(value))
                {
                    // If value is null then create a null parameter
                    return CreateNullParameter(name, OracleDbType.NVarchar2);
                }
                else
                {
                    OracleParameter parameter = new OracleParameter();
                    parameter.OracleDbType = OracleDbType.NVarchar2;
                    parameter.Size = size;
                    parameter.ParameterName = name;
                    parameter.Value = value;
                    parameter.Direction = ParameterDirection.Input;
                    return parameter;
                }
            }
            public OracleParameter CreateParameter(string name, byte[] value)
            {
                OracleParameter parameter = new OracleParameter();
                parameter.OracleDbType = OracleDbType.BFile;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
            #endregion
            #region "Data Projection Methods"
            // ExecuteNonQuery
            public void ExecuteNonQuery(OracleCommand command)
            {
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error executing query", e);
                }
                finally
                {
                    command.Connection.Close();
                }
            }
            // ExecuteScalar
            public Object ExecuteScalar(OracleCommand command)
            {
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    return command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw new Exception("Error executing query", e);
                }
                finally
                {
                    command.Connection.Close();
                }
            }
            // GetSingleValue
            public T GetSingleValue<T>(OracleCommand command)
            {
                T returnValue = default(T);
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (!reader.IsDBNull(0)) { returnValue = (T)reader[0]; }
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error populating data", e);
                }
                finally
                {
                    command.Connection.Close();
                }
                return returnValue;
            }
            // GetSingleString
            public Int32 GetSingleInt32(OracleCommand command)
            {
                Int32 returnValue = default(int);
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (!reader.IsDBNull(0)) { returnValue = reader.GetInt32(0); }
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error populating data", e);
                }
                finally
                {
                    command.Connection.Close();
                }
                return returnValue;
            }
            // GetSingleString
            public string GetSingleString(OracleCommand command)
            {
                string returnValue = null;
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (!reader.IsDBNull(0)) { returnValue = reader.GetString(0); }
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error populating data", e);
                }
                finally
                {
                    command.Connection.Close();
                }
                return returnValue;
            }
            // GetStringList
            public List<string> GetStringList(OracleCommand command)
            {
                List<string> returnList = null;
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        returnList = new List<string>();
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) { returnList.Add(reader.GetString(0)); }
                        }
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error populating data", e);
                }
                finally
                {
                    command.Connection.Close();
                }
                return returnList;
            }
            #endregion
            #region CBO Methods
            public T GetCBOSingle<T>(OracleCommand command) where T : class, new()
            {
                T dto = null;
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dto = CBO.FillObject<T>(typeof(T), reader);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error populating data", e);
                }
                finally
                {
                    command.Connection.Close();
                }
                // return the DTO, it's either populated with data or null.
                return dto;
            }
            // GetList
            public List<T> GetCBOList<T>(OracleCommand command) where T : class, new()
            {
                List<T> dtoList = null;
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //DateTime now = DateTime.Now;
                        dtoList = CBO.FillCollection<T>(typeof(T), reader);
                       // DateTime now2 = DateTime.Now;
                        //TimeSpan span = now.Subtract(now2);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error populating data", e);
                }
                finally
                {
                    command.Connection.Close();
                }
                // We return either the populated list if there was data,
                // or if there was no data we return an empty list.
                return dtoList;
            }
            #endregion
        }//end  class
    }
