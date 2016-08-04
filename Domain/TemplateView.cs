using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TemplateView
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime CreateDate { get; set; }
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
        /// 文章列表
        /// </summary>
        public virtual ICollection<Articles> Articles { get; set; }

    }
}
