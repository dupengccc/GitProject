using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Column
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章列表
        /// </summary>

        public virtual ICollection<Articles> Articles { get; set; }


    }
}
