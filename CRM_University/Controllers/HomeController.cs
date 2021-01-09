using CRM_University.BLL;
using CRM_University.Core.Interfaces;
using CRM_University.Data.Repositories;
using CRM_University.Models;
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
            //var textBL = new TestBL(_unitOfWork);
            //textBL.GetMatanalizResult();
            return View();
        }

        [HttpPost]
        public IActionResult Index(int a)
        {
            var textBL = new TestBL(_unitOfWork);
            textBL.GetMatanalizResult();
            return null;
        }

        public IActionResult GetMatanaliz()
        {
            
            return View();
        }
       
    }
}
