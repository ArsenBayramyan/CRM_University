using CRM_University.Data.Repositories;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.IO;

namespace CRM_University.BLL
{
    public class TestBL:BaseBL
    {
        public TestBL(UnitOfWorkRepository unitOfWork) : base(unitOfWork) { }
        
        public void GetMatanalizResult()
        {
            string sqlConnectionString = @"Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            string script = File.ReadAllText(@"C:\Users\arsen\OneDrive\Documents\SQL Server Management Studio\CRM\Query_MOG.sql");

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            var x = server.ConnectionContext.ExecuteNonQuery(script);
        }

    }
}
