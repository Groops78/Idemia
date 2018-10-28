using Idemia.Common.Entities;
using Idemia.Common.Helpers;
using Idemia.DAL.Base;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.DAL
{
    public class RequestDao: OracleDao
    {

        public bool SaveEmailNotification(EmailNotification notification) 
        {
            bool result = true;
            try
            {
                OracleDao dao = new OracleDao(Configs.ConnectionString);
                OracleCommand command = dao.GetSprocCommand("idemia.SP_INSERTEMAIL");
                command.Parameters.Add(dao.CreateParameter("PREQUESTID",notification.RequestId ));
                command.Parameters.Add(dao.CreateParameter("PSTATUSID", notification.StatusId));
                command.Parameters.Add(dao.CreateParameter("PSUBJECT", notification.Subject));
                command.Parameters.Add(dao.CreateParameter("PBODY", notification.Body));
                command.Parameters.Add(dao.CreateParameter("PTO", notification.To));
                if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
      
        }

        public bool SaveRequest(Request request) 
        {
            bool result = true;
            try
            {
                  OracleDao dao = new OracleDao(Configs.ConnectionString);
                OracleCommand command = dao.GetSprocCommand("idemia.SP_SaveRequest");
                command.Parameters.Add(dao.CreateParameter("pID",request.Id ));
                command.Parameters.Add(dao.CreateParameter("PSTATUSID", request.StatusId));
                command.Parameters.Add(dao.CreateParameter("pCustomerId", request.CustomerId));
                command.Parameters.Add(dao.CreateParameter("PREQUESTTYPEID", request.RequestTypeId));
                command.Parameters.Add(dao.CreateParameter("pSTATEPROGRESS", 0));
                command.Parameters.Add(dao.CreateParameter("pOVERALLPROGRESS", 0));
                command.Parameters.Add(dao.CreateParameter("pPRIORITY", request.Priority));
                command.Parameters.Add(dao.CreateParameter("pOrder", request.Order));
                command.Parameters.Add(dao.CreateParameter("pREQUESTDETAILS", request.RequestDetails));
                command.Parameters.Add(dao.CreateParameter("PCREATED", request.Created));
                command.Parameters.Add(dao.CreateParameter("PCREATEDBY", request.CreatedBy));
                command.Parameters.Add(dao.CreateParameter("PMODIFIED", request.Modified));
                command.Parameters.Add(dao.CreateParameter("PMODIFIEDBY", request.ModifiedBy));
                if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
      
        }

         public List<Request> GetRequests(int? Id = null, int? customerId = null, int? statusId = null, int? startIndex=1, int? pageSize = 50)
        {
            List<Request> dtos = new List<Request>();
            try
            {
                OracleDao dao = new OracleDao(Configs.ConnectionString);
                OracleCommand command = dao.GetSprocCommand("idemia.SP_GetRequests");
                command.Parameters.Add(dao.CreateParameter("pID", Id));
                command.Parameters.Add(dao.CreateParameter("pCustomerId", customerId));
                command.Parameters.Add(dao.CreateParameter("pStatusId", statusId));
                command.Parameters.Add(dao.CreateParameter("pStartIndex", startIndex));
                command.Parameters.Add(dao.CreateParameter("pPageSize", pageSize));
                command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();
                OracleDataReader reader = command.ExecuteReader();

                DateTime now = DateTime.Now;
                while (reader.Read()) {
                    Request request = new Request();
                    request.Id = int.Parse(reader["ID"].ToString());
                    if (reader["STATUSID"] != null && reader["STATUSID"].ToString() != "") request.StatusId = int.Parse(reader["STATUSID"].ToString());
                    if (reader["CUSTOMERID"] != null && reader["CUSTOMERID"].ToString() != "") request.CustomerId = int.Parse(reader["CUSTOMERID"].ToString());
                    if (reader["REQUESTTYPEID"] != null && reader["REQUESTTYPEID"].ToString() != "") request.RequestTypeId = int.Parse(reader["REQUESTTYPEID"].ToString());
                    if (reader["CREATEDBY"] != null) request.CreatedBy = int.Parse(reader["CREATEDBY"].ToString());
                    if (reader["MODIFIEDBY"] != null) request.ModifiedBy = int.Parse(reader["MODIFIEDBY"].ToString());
                    if (reader["CREATED"] != null && reader["CREATED"].ToString() != "") request.Created = DateTime.Parse(reader["CREATED"].ToString());
                    if (reader["MODIFIED"] != null && reader["MODIFIED"].ToString() != "") request.Modified = DateTime.Parse(reader["MODIFIED"].ToString());
                    if (reader["CUSTOMER"] != null && reader["CUSTOMER"].ToString() != "") request.Customer =reader["CUSTOMER"].ToString();
                    if (reader["STATUS"] != null && reader["STATUS"].ToString() != "") request.Status = reader["STATUS"].ToString();
                    if (reader["EMAIL"] != null && reader["EMAIL"].ToString() != "") request.Email = reader["EMAIL"].ToString();
                    if (reader["ADDRESS"] != null && reader["ADDRESS"].ToString() != "") request.Address = reader["ADDRESS"].ToString();
                    if (reader["PRIORITY"] != null && reader["PRIORITY"].ToString() != "") request.Priority = reader["PRIORITY"].ToString();
                    if (reader["REQUESTORDER"] != null && reader["REQUESTORDER"].ToString() != "") request.Order = int.Parse(reader["REQUESTORDER"].ToString());
                    dtos.Add(request);
                }
                DateTime now2 = DateTime.Now;
                TimeSpan span = now.Subtract(now2);
                //takingtoo long why?
                //dtos = dao.GetCBOList<Request>(command);
            }//end try
            catch (Exception ex)
            {
                dtos.Add(new Request() { Address="Address 1", Created= DateTime.Now, CreatedBy=1, Customer="Mohammad", CustomerId= 1, Email="mkhiami@gmail.com", Id=1, Order=1, Priority="High", RequestDetails="xyz", Modified=DateTime.Now, ModifiedBy=1, StatusId=1, RequestTypeId=1, Status="New"  });
            }
            return dtos;
        }

         public List<RequestType> GetRequestTypes(int? Id = null, string name = null, int? StartIndex = 0, int PageSize = 50)
         {
             List<RequestType> dtos = new List<RequestType>();
             try
             {
                 OracleDao dao = new OracleDao(Configs.ConnectionString);
                 OracleCommand command = dao.GetSprocCommand("idemia.SP_GETRequestTypes");
                 command.Parameters.Add(dao.CreateParameter("pID", Id));
                 command.Parameters.Add(dao.CreateParameter("PNAME", name));
                 command.Parameters.Add(dao.CreateParameter("pSTARTINDEX", StartIndex));
                 command.Parameters.Add(dao.CreateParameter("pPageSize", PageSize));
                 command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                 if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();

                 dtos = dao.GetCBOList<RequestType>(command);
             }//end try
             catch (Exception ex)
             {
             }
             return dtos;
         }

         public List<RequestStatus> GetRequestStatuses(int? Id = null, string name = null, int? StartIndex = 0, int PageSize = 50)
         {
             List<RequestStatus> dtos = new List<RequestStatus>();
             try
             {
                 OracleDao dao = new OracleDao(Configs.ConnectionString);
                 OracleCommand command = dao.GetSprocCommand("idemia.SP_GETRequestStatuses");
                 command.Parameters.Add(dao.CreateParameter("pID", Id));
                 command.Parameters.Add(dao.CreateParameter("PNAME", name));
                 command.Parameters.Add(dao.CreateParameter("pSTARTINDEX", StartIndex));
                 command.Parameters.Add(dao.CreateParameter("pPageSize", PageSize));
                 command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                 if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();

                 dtos = dao.GetCBOList<RequestStatus>(command);
             }//end try
             catch (Exception ex)
             {
             }
             return dtos;
         }

         public Request GetNextRequest()
         {
             Request dto = new Request();
             try
             {
                 OracleDao dao = new OracleDao(Configs.ConnectionString);
                 OracleCommand command = dao.GetSprocCommand("idemia.SP_GETNextRequest");
                 command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                 if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();

                 dto = dao.GetCBOSingle<Request>(command);
             }//end try
             catch (Exception ex)
             {
             }
             return dto;
         }
         public void ClearInProgress()
         {
             try
             {
                 OracleDao dao = new OracleDao(Configs.ConnectionString);
                 OracleCommand command = dao.GetSprocCommand("idemia.SP_CLEARITEMINPROGRESS");
                 if (command.Connection.State == System.Data.ConnectionState.Closed) command.Connection.Open();

                 command.ExecuteNonQuery();
             }//end try
             catch (Exception ex)
             {
             }
         }

         public List<FactoryStatistic> GetFactoryStatistics(DateTime? from = null, DateTime? to=null) {
             List<FactoryStatistic> result = new List<FactoryStatistic>();
             if (!from.HasValue) from = DateTime.Now.AddDays(-1);
             if (!to.HasValue) to = DateTime.Now.AddDays(1);

             try
             {
                 OracleDao dao = new OracleDao(Configs.ConnectionString);
                 OracleCommand command = dao.GetSprocCommand("idemia.SP_GETFactoryStats");
                 command.Parameters.Add(dao.CreateParameter("PFROM",from));
                 command.Parameters.Add(dao.CreateParameter("PTO", to));

                 command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                 result = dao.GetCBOList<FactoryStatistic>(command);
             }
             catch (Exception ex)
             {
                 
             }
             return result;
         }

    }
}
