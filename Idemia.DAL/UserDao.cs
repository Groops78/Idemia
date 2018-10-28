using Idemia.Common.Helpers;
using Idemia.DAL.Base;
using Idemia.DTO;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.DAL
{
    public class UserDao: OracleDao
    {
        public List<User> GetUsers(int? Id = null, string name=null, int? StartIndex=0, int PageSize=50)
        {
            List<User> dtos = new List<User>();
            try
            {
                OracleDao dao = new OracleDao(Configs.ConnectionString);
                OracleCommand command = dao.GetSprocCommand("idemia.SP_GETUsers");
                command.Parameters.Add(dao.CreateParameter("pID", Id));
                command.Parameters.Add(dao.CreateParameter("PNAME", name));
                command.Parameters.Add(dao.CreateParameter("pSTARTINDEX", StartIndex));
                command.Parameters.Add(dao.CreateParameter("pPageSize", PageSize));
                command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                dtos = dao.GetCBOList<User>(command);
            }//end try
            catch (Exception ex)
            {
            }
            return dtos;
        }

        public User LoginUser(string username, string password)
        {
            User dto = null;
            try
            {
                OracleDao dao = new OracleDao(Configs.ConnectionString);
                OracleCommand command = dao.GetSprocCommand("idemia.SP_LoginUser");
                command.Parameters.Add(dao.CreateParameter("pUserName", username));
                command.Parameters.Add(dao.CreateParameter("pPassword", password));

                command.Parameters.Add(dao.CreateOutputParameter("RESULTSET", OracleDbType.RefCursor));
                dto = dao.GetCBOSingle<User>(command);
            }//end try
            catch (Exception ex)
            {
            }
            return dto;
        }
    }
}
