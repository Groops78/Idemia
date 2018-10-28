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
    public class CustomerDao: OracleDao
    {
        public List<Customer> GetCustomers(int? Id = null, string name=null, int? StartIndex=0, int PageSize=50)
        {
            List<Customer> dtos = new List<Customer>();
            try
            {
                OracleDao dao = new OracleDao(Configs.ConnectionString);
                OracleCommand command = dao.GetSprocCommand("idemia.SP_GETCUSTOMERS");
                command.Parameters.Add(dao.CreateParameter("pID", Id));
                command.Parameters.Add(dao.CreateParameter("PNAME", name));
                command.Parameters.Add(dao.CreateParameter("pSTARTINDEX", StartIndex));
                command.Parameters.Add(dao.CreateParameter("pPageSize", PageSize));
                command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                dtos = dao.GetCBOList<Customer>(command);
            }//end try
            catch (Exception ex)
            {
            }
            return dtos;
        }
    }
}
