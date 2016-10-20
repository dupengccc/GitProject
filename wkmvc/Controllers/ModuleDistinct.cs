using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wkmvc.Controllers
{
    public class ModuleDistinct: IEqualityComparer<SYS_MODULE>
    {
        public bool Equals(SYS_MODULE x, SYS_MODULE y)
        {
            return (x.ID == y.ID);
        }

        public int GetHashCode(SYS_MODULE obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}