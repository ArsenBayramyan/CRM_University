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
    public static class StoredProcedure
    {
        public static List<BaseModel> GetExamResult(string subjectName,int examResult )
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                DataTable dt = new DataTable();
                List<BaseModel> entityes = new List<BaseModel>();

                SqlCommand cmd = new SqlCommand("GetExamResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Subject",subjectName);
                cmd.Parameters.AddWithValue("@Exam",examResult);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    BaseModel entity = new BaseModel();
                    entity.StudentId = (int)dr["StudentId"];
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.FacultyName = dr["FacultyName"].ToString();
                    entity.GroupName = dr["GroupName"].ToString();
                    entity.SubjectName = dr["SubjectName"].ToString();
                    entity.ExaminationResult = Convert.ToByte(dr["Result"]);
                    entityes.Add(entity);
                }

                return entityes;
            }
        }

        public static List<BaseModel> GetFrequenciesResult(string faculty,string group,string subject)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                
                DataTable dt = new DataTable();
                List<BaseModel> entityes = new List<BaseModel>();

                SqlCommand cmd = new SqlCommand("GetFrequenciesResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Faculty", faculty);
                cmd.Parameters.AddWithValue("@Group", group);
                cmd.Parameters.AddWithValue("@Subject", subject);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    BaseModel entity = new BaseModel();
                    entity.StudentId = (int)dr["StudentId"];
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.Email = dr["Email"].ToString();
                    entity.FacultyName = dr["FacultyName"].ToString();
                    entity.GroupName = dr["GroupName"].ToString();
                    entity.SubjectName = dr["SubjectName"].ToString();
                    entity.Frequency = (int)dr["Frequency"];
                    entityes.Add(entity);
                }

                return entityes;
            }
        }   

        public static List<BaseModel> GetFrequenciesFacultyResult(string faculty)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                DataTable dt = new DataTable();
                List<BaseModel> entityes = new List<BaseModel>();

                SqlCommand cmd = new SqlCommand("GetFrequenciesFacultyResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Faculty", faculty);
            

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    BaseModel entity = new BaseModel();
                    entity.StudentId = (int)dr["StudentId"];
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.FacultyName = dr["FacultyName"].ToString();
                    entity.GroupName = dr["GroupName"].ToString();
                    entity.Frequency = (int)dr["Frequency"];
                    entityes.Add(entity);
                }

                return entityes;
            }
        }

        public static List<BaseModel> GetFrequenciesGroupResult(string group)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                DataTable dt = new DataTable();
                List<BaseModel> entityes = new List<BaseModel>();

                SqlCommand cmd = new SqlCommand("GetFrequenciesGroupResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Group", group);
                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    BaseModel entity = new BaseModel();
                    entity.StudentId = (int)dr["StudentId"];
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.FacultyName = dr["FacultyName"].ToString();
                    entity.GroupName = dr["GroupName"].ToString();
                    entity.Frequency = (int)dr["Frequency"];
                    entityes.Add(entity);
                }

                return entityes;
            }
        }

        public static List<BaseModel> GetNonPaidResult()
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                DataTable dt = new DataTable();
                List<BaseModel> entityes = new List<BaseModel>();

                SqlCommand cmd = new SqlCommand("GetPaidFacultyResult", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    BaseModel entity = new BaseModel();
                    entity.StudentId = (int)dr["StudentId"];
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.Email = dr["Email"].ToString();
                    entity.FacultyName = dr["FacultyName"].ToString();
                    entity.GroupName = dr["GroupName"].ToString();
                    entity.FacultyFee = (int)dr["Fee"];
                    entity.Paid= dr["Paid"].ToString();
                    entityes.Add(entity);
                }

                return entityes;
            }
        }

        public static List<BaseModel> GetFrequenciesAllResult()
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                DataTable dt = new DataTable();
                List<BaseModel> entityes = new List<BaseModel>();

                SqlCommand cmd = new SqlCommand("GetFrequenciesAllResult", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    BaseModel entity = new BaseModel();
                    entity.StudentFirstName = dr["FirstName"].ToString();
                    entity.StudentLastName = dr["LastName"].ToString();
                    entity.Email = dr["Email"].ToString();
                    entity.FacultyName = dr["FacultyName"].ToString();
                    entity.GroupName = dr["GroupName"].ToString();
                    entity.Frequency = (int)dr["Frequency"];
                    entityes.Add(entity);
                }

                return entityes;
            }
        }

    }
}
