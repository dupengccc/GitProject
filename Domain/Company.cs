using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyTel { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContectUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
