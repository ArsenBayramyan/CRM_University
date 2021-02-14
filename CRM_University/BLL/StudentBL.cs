using ClosedXML.Excel;
using CRM_University.Core;
using CRM_University.Data.ExecuteComand;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;

namespace CRM_University.BLL
{
    public class StudentBL : BaseBL
    {
        public StudentBL(UnitOfWorkRepository unitOfWork) : base(unitOfWork) { }

        public DataTable ExportToExcel(List<BaseModel> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Faculty Name", typeof(string));
            table.Columns.Add("Group Name", typeof(string));
            table.Columns.Add("Subject Name", typeof(string));
            table.Columns.Add("Result", typeof(byte));
            foreach (var student in list)
            {
                table.Rows.Add(student.StudentFirstName,
                               student.StudentLastName,
                               student.FacultyName,
                               student.GroupName,
                               student.SubjectName,
                               student.ExaminationResult);
            }
            return table;
        }

        public FilterModel GetExamResult(string subject, int result)
        {
            var students = StoredProcedure.GetExamResult(subject, result);
            var table = ExportToExcel(students);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(table, "Students");
                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var id = CacheDictionary.Instance.Add(stream.ToArray());
                stream.Close();
                return new FilterModel { FilterList = students, Id = id };
            }
        }
    }

}

