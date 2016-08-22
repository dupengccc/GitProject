using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public partial class UserOnlie
    {
        public int ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int FK_Userid    { get; set; }

        //上线时间
        public System.DateTime OnlineDate { get; set; }

        //登录IP
        public string UserIP { get; set; }

        /// <summary>
        /// 下线时间
        /// </summary>
        public Nullable<DateTime> OffineDate { get; set; }


        /// <summary>
        /// 连接ConnectID
        /// </summary>
        public string ConnectId { get; set; }


    }
}
