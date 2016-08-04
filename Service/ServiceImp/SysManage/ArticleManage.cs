using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace Service.ServiceImp.SysManage
{
    public class ArticleManage : RepositoryBase<Domain.Articles>, IArticleManage
    {
    }
}
