using AutoMapper;
using CRM_University.BLL;
using CRM_University.Core;
using CRM_University.Core.Interfaces;
using CRM_University.Data.ExecuteComand;
using CRM_University.Models;
using CRM_University.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRM_University.Data.Models;
using CRM_University.Models.ViewModels;

namespace CRM_University.Controllers
{
    public class HomeController : Controller
    {
       
        private UnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;
        public HomeController(IUnitOfWorkRepository unitOfWork,IMapper mapper)
        {
            _unitOfWork = (UnitOfWorkRepository)unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult DownloadExcel(int id)
        {
            byte[] array = CacheDictionary.dictioanry[key: id];
            return File(array,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
           
        }
        
    }
}
