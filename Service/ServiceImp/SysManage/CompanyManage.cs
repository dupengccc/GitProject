﻿using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp.SysManage
{
    public class CompanyManage:RepositoryBase<Domain.Company>,ICompanyManage 
    {
    }
}
