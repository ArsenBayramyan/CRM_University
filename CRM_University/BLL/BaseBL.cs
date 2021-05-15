using AutoMapper;
using CRM_University.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CRM_University.BLL
{
    public class BaseBL
    {
        protected UnitOfWorkRepository UOW { get; private set; }
        protected IMapper Mapper { get; private set; }
        public BaseBL(UnitOfWorkRepository unitOfWork,IMapper mapper)
        {
            UOW = unitOfWork;
            Mapper = mapper;
        }
    }
}
