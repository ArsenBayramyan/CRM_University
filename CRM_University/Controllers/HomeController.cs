using CRM_University.BLL;
using CRM_University.Core;
using CRM_University.Core.Interfaces;
using CRM_University.Data.ExecuteComand;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using CRM_University.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Controllers
{
    public class HomeController : Controller
    {
       
        private UnitOfWorkRepository _unitOfWork;
        public HomeController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = (UnitOfWorkRepository)unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Action(int a)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var filter = studentBL.GetExamResult("Matanaliz",100);
            return View(filter);
        }
        public ActionResult DownloadExcel(int id)
        {
            byte[] array = CacheDictionary.dictioanry[key: id];
            return File(array,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
           
        }
        
    }
}
