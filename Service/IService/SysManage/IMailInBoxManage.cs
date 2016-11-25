using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;

namespace Service.IService.SysManage
{
    public interface IMailInBoxManage: IRepository<Domain.MAIL_INBOX>
    {
  
    }
}
