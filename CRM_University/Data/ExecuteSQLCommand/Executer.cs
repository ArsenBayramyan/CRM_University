using CRM_University.Data.Context;
using CRM_University.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.ExecuteComand
{
    public static class Executer
    {
        public static BaseModel GetExamResult()
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                DataTable dt = new DataTable();
                BaseModel entity = new BaseModel();

                SqlCommand cmd = new SqlCommand("GetExamResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Subject","Matanaliz");
                cmd.Parameters.AddWithValue("@Exam","100");


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.SubjectName = dr["SubjectName"].ToString();
                    entity.ExaminationResult = Convert.ToByte(dr["Result"]);
                }

                return entity;
            }

        }
    }
}
